using Microsoft.AspNetCore.Mvc;

namespace SimpleCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet]
        [Route("add")]
        public ActionResult<double> Add(double x, double y)
        {
            var result = x + y;
            System.IO.File.AppendAllText(@"calculator.log",$"{result.ToString()}\n");
            return result;
        }

        [HttpGet]
        [Route("subtract")]
        public ActionResult<double> Subtract(double x, double y)
        {
            return x - y;
        }
    }
}
