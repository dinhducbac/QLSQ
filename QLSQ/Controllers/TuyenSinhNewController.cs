using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.ApiIntergration;
using QLSQ.WebApp.Models;

namespace QLSQ.WebApp.Controllers
{
    public class TuyenSinhNewController : Controller
    {
        public readonly INewApiClient _newApiClient;
        public TuyenSinhNewController(INewApiClient newApiClient)
        {
            _newApiClient = newApiClient;
        }
        public async Task<IActionResult> Index()
        {
            var listTuyenSinhNew = await _newApiClient.GetListTuyenSinhNew();
            var tuyenSinhVM = new TuyenSinhNewViewModel()
            {
                ListTuyenSinhNew = listTuyenSinhNew.ResultObj
            };
            return View(tuyenSinhVM);
        }
    }
}