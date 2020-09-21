using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto.Models;
using Projeto.Api;

namespace Projeto.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGitHub _Api;

        public HomeController(IGitHub api)
        {
            _Api = api;
        
        }

      

        public async Task<IActionResult> Index()
        {
            using (var proxy=await _Api.GetRepositories())
            {
                switch(proxy.ResponseMessage.StatusCode){
                    case System.Net.HttpStatusCode.OK:
                    return View (proxy.GetContent());
                    default:
                    return RedirectToAction("Error");

                }

            }          
            
        }

        [HttpGet("Detail/{repo}")]
        public async Task<IActionResult> Detail(string repo){
             using (var proxy=await _Api.GetRepository(repo))
            {
                switch(proxy.ResponseMessage.StatusCode){
                    case System.Net.HttpStatusCode.OK:
                    return View (proxy.GetContent());
                    default:
                    return RedirectToAction("Error");

                }

            }  

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
