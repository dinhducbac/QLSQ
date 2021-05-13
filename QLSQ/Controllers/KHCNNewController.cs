using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.ApiIntergration;
using QLSQ.WebApp.Models;

namespace QLSQ.WebApp.Controllers
{
    public class KHCNNewController : Controller
    {
        public readonly INewApiClient _newApiClient;
        public KHCNNewController(INewApiClient newApiClient)
        {
            _newApiClient = newApiClient;
        }
        
        public async Task<IActionResult> Index()
        {
            var result = await _newApiClient.GetListKHCNNew();
            var KHCNNewViewModel = new KHCNNewViewModel()
            {
                ListKHCNNews = result.ResultObj
            };
            return View(KHCNNewViewModel);
        }
    }
}