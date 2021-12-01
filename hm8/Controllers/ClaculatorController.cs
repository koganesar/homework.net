using Microsoft.AspNetCore.Mvc;

namespace hm8.Controllers
{
    public class ClaculatorController: Controller
    {
        public ActionResult Claculate([FromServices]IClaculator calculator, string num1, string num2, string oper)
        {
            return Ok(calculator.Calllculate(num1, num2, oper));
        }
    }
}