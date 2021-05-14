using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.ApiIntergration;
using QLSQ.WebApp.Models;

namespace QLSQ.WebApp.Controllers
{
    public class GDQPANNewController : Controller
    {
        public readonly INewApiClient _newApiClient;
        public GDQPANNewController(INewApiClient newApiClient)
        {
            _newApiClient = newApiClient;
        }
        public async Task<IActionResult> Index()
        {
            var listGDQPNew = await _newApiClient.GetListGDQPANNew();
            var gdqpNewVM = new GDQPANNewViewModel()
            {
                ListGDQPANNew = listGDQPNew.ResultObj
            };
            return View(gdqpNewVM);
        }
    }
}