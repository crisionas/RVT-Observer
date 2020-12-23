using BusinessLayer;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RVTLibrary.Models.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RVTObserverCI.Controllers
{
    public class ParticipationController : Controller
    {
        IUser results;
        private static StatisticsResponse statistics;

        public ParticipationController()
        {
            var bl = new BusinessManager();
            results = bl.GetResults();
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                statistics = await results.StatisticsStatus("0");
                ViewBag.Name = statistics.Name;
                ViewBag.Time=statistics.Time;
                ViewBag.Voters=statistics.Voters;
                ViewBag.Population = statistics.Population;
                ViewBag.Percentage = (statistics.Voters* 100) / statistics.Population;

            }
            catch
            {
                return View("Error");
            }
            return View();
        }

        [Route("{controller}/RM/{origin}")]
        public async Task<ActionResult> RM([FromRoute]string origin)
        {
            try
            {
                statistics = await results.StatisticsStatus("0");
                ViewBag.Name = statistics.Name;
                ViewBag.Time = statistics.Time;
                ViewBag.Voters = statistics.Voters;
                ViewBag.Population = statistics.Population;
                ViewBag.Percentage = (statistics.Voters * 100) / statistics.Population;
            }
            catch
            {
                return View("Error");
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Getgenderstatistic()
        {
            return Json(statistics.GenderStatistics);
        }

        [HttpGet]
        public async Task<ActionResult> GetAges()
        {
            return Json(statistics.AgeVoters);
        }
    }
}
