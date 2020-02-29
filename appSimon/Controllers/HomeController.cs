using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using appSimon.Models;

namespace appSimon.Controllers
{
    public class HomeController : Controller
    {
       public IActionResult Index(HomeModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Chat) )
            {
                model.Chat = "lets start the chat";
            }
           
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SendChat(HomeModel model)
        {
            model.Chat += "\n I am Simon \n";
            model.Chat += model.Message;
            //using (var client = new HttpClient())
            //{
                
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    HttpResponseMessage response = client.GetAsync("http://localhost:32769/api/values").Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var r = response.Content.ReadAsStringAsync();
            //    }
            //}
            return View("Index",model);
        }
    }

    public class HomeModel
    {
        public string Chat { get; set; }
        public string Message { get; set; }
    }
}
