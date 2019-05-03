using Microsoft.AspNetCore.Mvc;
using SimpleCalculatorClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleCalculatorClient.Controllers
{
    [Route("api/[controller]")]
    public class FormController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(FormModel model)
        {
            using (var client = new HttpClient())
            {
                // Call *mywebapi*, and display its response in the page
                var request = new HttpRequestMessage();
                var uri = new Uri($"http://default.simplecalculator.z26kl7w9th.weu.azds.io/api/calculator/add?x={model.NumbOne}&y={model.NumbTwo}");
                request.RequestUri = uri;
                if (this.Request.Headers.ContainsKey("azds-route-as"))
                {
                    // Propagate the dev space routing header
                    request.Headers.Add("azds-route-as", this.Request.Headers["azds-route-as"] as IEnumerable<string>);
                }
                var response = await client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                ViewData["Message"] += " and " + content;
            }

            return Content($"First: {model.NumbOne}\nSecond: {model.NumbTwo}");
        }
    }
}
