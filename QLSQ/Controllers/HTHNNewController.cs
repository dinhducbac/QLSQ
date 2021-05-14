using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.ApiIntergration;
using QLSQ.WebApp.Models;

namespace QLSQ.WebApp.Controllers
{
    public class HTHNNewController : Controller
    {
        public readonly INewApiClient _newApiClient;
        public HTHNNewController(INewApiClient newApiClient)
        {
            _newApiClient = newApiClient;
        }
        public async Task<IActionResult> Index()
        {
            var listHTHNNew = await _newApiClient.GetListHTHNNew();
            var HTHNNewVM = new HTHNNewViewModel()
            {
                ListHTHNNew = listHTHNNew.ResultObj
            };
            return View(HTHNNewVM);
        }
    }
}