using System;
using System.Net.Http;
using System.Threading.Tasks;
using hm8;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

namespace hm8test
{
    public class UnitTest1
    {
        private Claculator claculllator = new Claculator();

        [Theory]
        [InlineData("1", "2", "+", 3)]
        [InlineData("1", "2", "-", -1)]
        [InlineData("1", "2", "*", 2)]
        [InlineData("1", "2", "/", 0.5)]

        public void Test1(string num1, string num2, string oper, double result)
        {
            Assert.Equal(claculllator.Calllculate(num1, num2, oper), result);

        }
    }

    public class IntegrationTests
    {
        private HttpClient client;

        public IntegrationTests()
        {
            client = new WebApplicationFactory<Startup>().CreateClient();
        }

        public async Task Urltestsum()
        {
            var a = await client.GetAsync("http://localhost:5000/claculator/Claculate?num1=1&num2=2&oper=+");
            var b = await a.Content.ReadAsStringAsync();
            var c = Double.Parse(b);
            Assert.Equal(3,c);
        }
        public async Task Urltestminus()
        {
            var a = await client.GetAsync("http://localhost:5000/claculator/Claculate?num1=2&num2=1&oper=-");
            var b = await a.Content.ReadAsStringAsync();
            var c = Double.Parse(b);
            Assert.Equal(1,c);
        }
        public async Task Urltestmulty()
        {
            var a = await client.GetAsync("http://localhost:5000/claculator/Claculate?num1=1&num2=2&oper=*");
            var b = await a.Content.ReadAsStringAsync();
            var c = Double.Parse(b);
            Assert.Equal(2,c);
        }
        public async Task UrltestDivide()
        {
            var a = await client.GetAsync("http://localhost:5000/claculator/Claculate?num1=2&num2=1&oper=/");
            var b = await a.Content.ReadAsStringAsync();
            var c = Double.Parse(b);
            Assert.Equal(2,c);
        }
        
        
        
      
        
        

    }
    
}