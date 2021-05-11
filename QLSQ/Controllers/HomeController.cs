using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QLSQ.ApiIntergration;
using QLSQ.Models;
using QLSQ.WebApp.Models;

namespace QLSQ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly ISlideApiClient _slideApiClient;

        public HomeController(ILogger<HomeController> logger, ISlideApiClient slideApiClient)
        {
            _logger = logger;
            _slideApiClient = slideApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var slides = await _slideApiClient.GetAllWithoutPaging();
            var homeViewModel = new HomeViewModel();
            homeViewModel.SlideViewModels = slides.ResultObj;
            return View(homeViewModel);
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
