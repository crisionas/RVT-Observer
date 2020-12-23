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
    public class ResultsController : Controller
    {
        IUser results;
        private static ResultsResponse resultsResponse;

        public ResultsController()
        {
            var bl = new BusinessManager();
            results = bl.GetResults();
        }


        public async Task<IActionResult> Index()
        {
            try
            {
                resultsResponse = await results.ResultsStatus("0");
                ViewBag.Population = resultsResponse.Population;
                ViewBag.Votants = resultsResponse.Votants;
                ViewBag.Percentage = (resultsResponse.Votants * 100) / resultsResponse.Population;
            }
            catch
            {
                return View("Error");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }


        [Route("{controller}/RM/{origin}")]
        public async Task<ActionResult> RM([FromRoute] string origin)
        {
            try
            {
                resultsResponse = await results.ResultsStatus(origin);
                ViewBag.Name = resultsResponse.Name;
                ViewBag.Population = resultsResponse.Population;
                ViewBag.Votants = resultsResponse.Votants;
                ViewBag.Percentage = (resultsResponse.Votants * 100) / resultsResponse.Population;
            }
            catch
            {
                return View("Error");
            }
            return View();
        }

        /// <summary>
        /// Method Get Status for Vote Chart
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Getstatus()
        {
            return Json(resultsResponse.TotalVotes);
        }

        /// <summary>
        /// Method Get Gender for Gender Chart
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Getgenderstatistic()
        {
            return Json(resultsResponse.GenderStatistics);
        }
    }
}
