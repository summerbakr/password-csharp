using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Password.Models;
using Microsoft.AspNetCore.Http;

namespace Password.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
    {
        if(HttpContext.Session.GetInt32("Count") == null)

            {
                HttpContext.Session.SetInt32("Count", 0);
            }        
        int? count=HttpContext.Session.GetInt32("Count");
        count ++;
        HttpContext.Session.SetInt32("Count", (int)count);
        ViewBag.Count=count;
        string pass="";
            Random random=new Random();
            int randInt=random.Next();
            List<string> alphabet=new List<string>{"A", "B", "C", "D", "E","F", "G", "H", "I", "J","K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
            
            for(var i=0; i<5; i++)
            {
                int randIndex=random.Next(1,26);
                pass +=alphabet[randIndex];

            }
            pass+=randInt;
            
        
            HttpContext.Session.SetString("Password", pass);
            ViewBag.Password=pass;

            return View();
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
    }
}
