using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.QuanHam;

namespace QLSQ.AdminApp.Controllers
{
    public class QuanHamController : Controller
    {
        public readonly IConfiguration _configuration;
        public readonly IQuanHamApiClient _quanHamApiClient;
        public QuanHamController(IQuanHamApiClient quanHamApiClient,IConfiguration configuration )
        {
            _quanHamApiClient = quanHamApiClient;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize  = 10)
        {
            var request = new GetQuanHamPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            if (TempData["result"] != null)
            {
                ViewBag.Success = true;
                ViewBag.SuccessMessage = TempData["result"];
            }
            var result = await _quanHamApiClient.GetAllWithPaging(request);
            return View(result.ResultObj);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int IDQH)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _quanHamApiClient.Details(IDQH);
            if (result.IsSuccessed)
            {
                return View(result.ResultObj);
            }
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuanHamCreateRequest request)
        {
            var result = await _quanHamApiClient.Create(request);
            if (result.IsSuccessed)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Eror","Home");
        }
    }
}