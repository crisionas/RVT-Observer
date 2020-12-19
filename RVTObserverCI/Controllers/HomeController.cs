using BusinessLayer;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RVTLibrary.Models.Observer;
using RVTObserverCI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RVTObserverCI.Controllers
{
    public class HomeController : Controller
    {
        IResults results;
        protected ResultsResponse resultsResponse;

        public HomeController()
        {
            var bl = new BusinessManager();
            results = bl.GetResults();
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> VoteResults()
        {
            var response = GetResults("0");
            ViewBag.Population = response.Result.Population;
            ViewBag.Votants = response.Result.Votants;
            ViewBag.Percentage= (response.Result.Votants * 100) / response.Result.Population;
            return View();
        }

        public IActionResult Statistics()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ResultsResponse> GetResults(string id)
        {
            resultsResponse = await results.ResultsStatus(id);
            return resultsResponse;
        }

        /// <summary>
        /// Method Get Status for Vote Chart
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Getstatus()
        {
            var response=await results.ResultsStatus("0");
            return Json(response.TotalVotes);
        }

        /// <summary>
        /// Method Get Gender for Gender Chart
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Getgenderstatistic()
        {
            var response = await results.ResultsStatus("0");
            return Json(response.GenderStatistics);
        }
    }
}
