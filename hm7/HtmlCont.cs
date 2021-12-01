using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hm7
{
    public static class HtmlContentExtensions
    {
        public static IHtmlContent MyEditorForModel(this IHtmlHelper helper)
        {
            var o = helper.ViewData.Model;
            if (o == null)
            {
                o = helper.ViewData.ModelMetadata.ModelType
                    .GetConstructor(Type.EmptyTypes)?.Invoke(Array.Empty<object>());
            }

            return new CreateFormContent(o);
        }

        private class CreateFormContent : IHtmlContent
        {
            private readonly string _resultContent;

            public CreateFormContent(object model) =>
                _resultContent = CreateContent(model.GetType().GetProperties(), model);

            private static string CreateContent(IEnumerable<PropertyInfo> propertyInfos, object model) =>
                propertyInfos
                    .Select(x =>
                        CreateHeaderForProperty(x) +
                        "<div class=\"creating-a-form-field\">" +
                        CreateBodyForProperty(x, model) +
                        "</div>")
                    .Aggregate(string.Concat);

            private static string CreateHeaderForProperty(PropertyInfo prop)
            {
                return $"<div class=\"creating-a-label\"><label for=\"{prop.Name}\">" +
                       $"{((DisplayAttribute) prop.GetCustomAttribute(typeof(DisplayAttribute)))?.Name ?? FromCamelCase(prop.Name)}" +
                       $"</label></div>";
            }

            private static string FromCamelCase(string str)
            {
                return str.Skip(1).Aggregate(str[0].ToString(),
                    (current, t) => current + (char.IsUpper(t) ? $" {char.ToLower(t)}" : t));
            }

            private static string CreateBodyForProperty(PropertyInfo prop, object model)
            {
                return CreateInput(prop) + CreateSpan(prop, model);
            }

            private static string CreateInput(PropertyInfo prop)
            {
                if (prop.PropertyType.IsAssignableTo(typeof(Enum)))
                    return "<select class=\"form-group\">"
                           + $"<option selected>{prop.Name}</option>"
                           + prop.PropertyType
                               .GetFields()
                               .Where(m => m.Name != "value__")
                               .Select(field => $"<option value=\"{field.Name}\">{field.Name}</option>")
                               .Aggregate(string.Concat)
                           + "</select>";
                else
                    return IsNumber(prop.PropertyType)
                        ? $"<input class=\"text-box single-line\" type=\"number\" name=\"{prop.Name}\">"
                        : $"<input class=\"text-box single-line\" type=\"text\" name=\"{prop.Name}\">";
            }

            private static string CreateSpan(PropertyInfo prop, object model)
            {
                var res =
                    $"<span class=\"field-validation-error\" data-valmsg-for=\"{prop.Name}\" data-valmsg-replace=\"true\">";
                var attr = (ValidationAttribute) prop.GetCustomAttribute(typeof(ValidationAttribute));
                if (attr != null && attr.IsValid(prop.GetValue(model)))
                {
                    if (attr.ErrorMessage != null)
                        res += attr.ErrorMessage;
                    else 
                        res += attr.FormatErrorMessage(prop.Name);
                }
                res += $"</span>";
                return res;
            }

            private static readonly Type[] numberTypesArray =
            {
                typeof(int), typeof(int?),
                typeof(uint), typeof(uint?),
                typeof(short), typeof(short?),
                typeof(ushort), typeof(ushort?),
                typeof(long), typeof(long?),
                typeof(ulong), typeof(ulong?),
                typeof(byte), typeof(byte?),
                typeof(float), typeof(float?),
                typeof(double), typeof(double?),
                typeof(decimal), typeof(decimal?)
            };

            private static bool IsNumber(Type type) => numberTypesArray.Any(type.IsAssignableTo);

            void IHtmlContent.WriteTo(TextWriter writer, HtmlEncoder encoder)
            {
                writer.WriteLine(_resultContent);
            }
        }
    }
}