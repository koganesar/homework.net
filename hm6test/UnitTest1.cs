using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using hm6;



namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private WebApplicationFactory<Startup> factory;
        private HttpClient client;
        
        [TestInitialize]
        public void SetFactory()
        {
            factory = new WebApplicationFactory<Startup>();
            client = factory.CreateClient();
        }
        
        [TestMethod]
        public async Task TestMethodPlus()
        {
            var response = await client
                .GetAsync("http://localhost:5000/calculate?v1=1&v2=2&operation=Plus");

            var result =
                await response.Content.ReadAsStringAsync();
            var number = decimal.Parse(result, CultureInfo.InvariantCulture);
            Assert.AreEqual(3m, number);

        }
        [TestMethod]
        public async Task TestMethodMinus()
        {
            var response = await client
                .GetAsync("http://localhost:5000/calculate?v1=2&v2=1&operation=Minus");

            var result =
                await response.Content.ReadAsStringAsync();
            var number = decimal.Parse(result, CultureInfo.InvariantCulture);
            Assert.AreEqual(1m, number);

        }
        
        [TestMethod]
        public async Task TestMethodMultiply()
        {
            var response = await client
                .GetAsync("http://localhost:5000/calculate?v1=1&v2=2&operation=Multiply");

            var result =
                await response.Content.ReadAsStringAsync();
            var number = decimal.Parse(result, CultureInfo.InvariantCulture);
            Assert.AreEqual(2m, number);

        }
        [TestMethod]
        public async Task TestMethodDivide()
        {
            var response = await client
                .GetAsync("http://localhost:5000/calculate?v1=2&v2=1&operation=Divide");

            var result =
                await response.Content.ReadAsStringAsync();
            var number = decimal.Parse(result, CultureInfo.InvariantCulture);
            Assert.AreEqual(2m, number);

        }
        
    }
}