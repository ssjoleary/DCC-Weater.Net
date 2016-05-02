using DCC_Weather.Models;
using DCC_Weather.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DCC_Weather.Controllers
{
    public class HomeController : Controller
    {
        private IDailyForecastService _dailyForecastService;

        public HomeController(IDailyForecastService dailyForecastService)
        {
            _dailyForecastService = dailyForecastService;
        }

        public ActionResult Index()
        {  
            return this.View();
        }

        public async Task<JsonResult> Get3DayForecast()
        {
            return Json(await _dailyForecastService.Get3DayForecast(), JsonRequestBehavior.AllowGet);
        }        
    }
}