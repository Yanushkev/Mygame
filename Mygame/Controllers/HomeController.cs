using Microsoft.AspNetCore.Mvc;
using Mygame.Models;
using System.Diagnostics;
using System.Reflection;

namespace Mygame.Controllers
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
            if (Request.Cookies["Player_name"] != null)
            {

                Allplayerdata initPlayerData = new Allplayerdata();

                initPlayerData.Playername = Request.Cookies["Player_name"];

                if (Request.Cookies["Player_language"] == null)

                {
                    initPlayerData.languageplayer = new language("UA");
                }
                else
                {
                    initPlayerData.languageplayer = new language(Request.Cookies["Player_language"]);
                }

                if (Request.Cookies["Player_map"] == null)

                {
                    initPlayerData.Playermap = "0";
                }
                else
                {
                    initPlayerData.Playermap = Request.Cookies["Player_map"];
                }
                if (Request.Cookies["Player_car"] == null)

                {
                    initPlayerData.Playercar = "none";
                }
                else
                {
                    initPlayerData.Playercar = Request.Cookies["Player_car"];
                }
                initPlayerData.Allcars = new Allcars("forest").Allcar;

                return View("Index", initPlayerData);
            }
            else
            {
                return View("Registration");
            }
        }

        public IActionResult Privacy()
        {
            Allplayerdata initPlayerData = new Allplayerdata();
            if (Request.Cookies["Player_language"] == null)

            {
                initPlayerData.languageplayer = new language("UA");
            }
            else
            {
                initPlayerData.languageplayer = new language(Request.Cookies["Player_language"]);
            }
                return View(initPlayerData);
        }
        public IActionResult Garage()
        {
            Allplayerdata initPlayerData = new Allplayerdata();
            if (Request.Cookies["Player_language"] == null)

            {
                initPlayerData.languageplayer = new language("UA");
            }
            else
            {
                initPlayerData.languageplayer = new language(Request.Cookies["Player_language"]);

            }
            if (Request.Cookies["Player_map"] == null)
            {
                initPlayerData.Playermap = "0";
            }
            else
            {
                initPlayerData.Playercar = Request.Cookies["Player_map"];
            }
            if (Request.Cookies["Player_car"] == null)
            {
                initPlayerData.Playercar = "none";
            }
            else
            {
                initPlayerData.Playercar = Request.Cookies["Player_car"];
            }
            return View(initPlayerData);
        }

        public IActionResult Play()
        {
            Allplayerdata initPlayerData = new Allplayerdata();

            return View();
        }

        public IActionResult Settings()
        {
            Allplayerdata initPlayerData = new Allplayerdata();

            if (Request.Cookies["Player_language"] == null)

            {
                initPlayerData.languageplayer = new language("UA");
            }
            else
            {
                initPlayerData.languageplayer = new language(Request.Cookies["Player_language"]);

            }

            return View(initPlayerData);
        }


        [HttpPost]
        public IActionResult Settings(IFormCollection formConfig)
        {
            if (formConfig["language"].Count > 0)
            {
                Response.Cookies.Append("Player_language", formConfig["language"]);
            }
            return RedirectToAction("Settings", "Home");
        }


        [HttpPost]
        public IActionResult Garage(IFormCollection formConfig)
        {
            if (formConfig["map"].Count > 0)
            {
                Response.Cookies.Append("Player_map", formConfig["map"]);
            }
            if (formConfig["car"].Count > 0)
            {
                Response.Cookies.Append("Player_car", formConfig["car"]);
            }
            return RedirectToAction("Garage", "Home");
        }
    

        [HttpPost]
        public IActionResult Registration(IFormCollection fromRegistration)
        {
            if (fromRegistration["nickname"] != "")
            {
                Response.Cookies.Append("Player_name", fromRegistration["nickname"]);
            }
            return RedirectToAction("Index", "Home");
        }



















        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}