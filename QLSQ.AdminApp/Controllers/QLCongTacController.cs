using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.QLCongTac;

namespace QLSQ.AdminApp.Controllers
{
    public class QLCongTacController : Controller
    {
        public readonly IQLCongTacApiClient _qLCongTacApiClient;
        public readonly ISiQuanApiClient _siQuanApiClient;
        public QLCongTacController(IQLCongTacApiClient qLCongTacApiClient, ISiQuanApiClient siQuanApiClient)
        {
            _qLCongTacApiClient = qLCongTacApiClient;
            _siQuanApiClient = siQuanApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetQLCongTacPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _qLCongTacApiClient.GetAll(request);
            if (TempData["result"] != null)
            {
                ViewBag.Success = true;
                ViewBag.SuccessMessage = TempData["result"];
            }
            return View(result.ResultObj);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var qlctCreateRequest = new QLCongTacCreateRequest()
            {
                siQuanViewModels = new List<ViewModel.Catalogs.SiQuan.SiQuanViewModel>()
            };
            var listsq = await _siQuanApiClient.GetAllWithoutPaging();
            if (listsq.IsSuccessed)
            {
                qlctCreateRequest.siQuanViewModels = listsq.ResultObj;
                return View(qlctCreateRequest);
            }
            return View(listsq);
        }
        [HttpPost]
        public async Task<IActionResult> Create(QLCongTacCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            var result = await _qLCongTacApiClient.Create(request);
            if (result.IsSuccessed)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Eror", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int IDCT)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _qLCongTacApiClient.Details(IDCT);
            if (result.IsSuccessed)
            {
                return View(result.ResultObj);
            }
            return View(result);
        }
    }
}