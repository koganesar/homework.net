using System.ComponentModel.DataAnnotations;

#nullable enable
namespace hm7.Models
{
    public class UserProfile
    {
        [Display(Name = "Фамилия")]
        public string SurName { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string? Patronymic { get; set; }
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        [Display(Name = "Тема вопроса")]
        public Topic Topic_of_question { get; set; }
        
    }
    
    public enum Topic
    {
        Биология,
        География, 
        Алгебра, 
        Геометрия, 
        Русский_язык
    };
}