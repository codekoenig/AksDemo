using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return x + y;
        }

        [HttpGet]
        [Route("subtract")]
        public ActionResult<double> Subtract(double x, double y)
        {
            return x - y;
        }
    }
}
