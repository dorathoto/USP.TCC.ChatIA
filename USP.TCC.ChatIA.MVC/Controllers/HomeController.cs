using Azure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using USP.TCC.ChatIA.MVC.Models;

namespace USP.TCC.ChatIA.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var retorno = VerificaCookie(Request, Response);

            return View();
        }

        public IActionResult Config()
        {
            var retorno = VerificaCookie(Request, Response);
            return View(retorno);
        }
        [HttpPost]
        public IActionResult Config(ChatOptions model)
        {
            var serializedModel = JsonConvert.SerializeObject(model);

            Response.Cookies.Append("TCC", serializedModel, new CookieOptions
            {
                Expires = DateTime.Now.AddHours(10)
            });
            return RedirectToAction(nameof(Index));
        }


        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ChatOptions VerificaCookie(HttpRequest request, HttpResponse response)
        {
            if (request.Cookies.TryGetValue("TCC", out string cookieValue))
            {
                var myModel = JsonConvert.DeserializeObject<ChatOptions>(cookieValue);
                return myModel;
            }
            else
            {
                var newSettings = new ChatOptions();

                var serializedModel = JsonConvert.SerializeObject(newSettings);

                response.Cookies.Append("TCC", serializedModel, new CookieOptions
                {
                    Expires = DateTime.Now.AddHours(10)
                });
                return newSettings;
            }

        }
    }
}