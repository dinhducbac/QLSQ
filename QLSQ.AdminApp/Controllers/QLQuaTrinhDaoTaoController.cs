using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.QLQuaTrinhDaoTao;

namespace QLSQ.AdminApp.Controllers
{
    public class QLQuaTrinhDaoTaoController : Controller
    {
        public readonly IQLQuaTrinhDaoTaoApiClient _qLQuaTrinhDaoTaoApiClient;
        public readonly ISiQuanApiClient _siQuanApiClient;
        public QLQuaTrinhDaoTaoController(IQLQuaTrinhDaoTaoApiClient qLQuaTrinhDaoTaoApiClient,ISiQuanApiClient siQuanApiClient)
        {
            _qLQuaTrinhDaoTaoApiClient = qLQuaTrinhDaoTaoApiClient;
            _siQuanApiClient = siQuanApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex=1,int pageSize = 5)
        {
            var qlqtdtPagingRequest = new GetQLQuaTrinhDaoTaoPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _qLQuaTrinhDaoTaoApiClient.GetAllWithPaging(qlqtdtPagingRequest);
            if(result.ResultObj != null)
            {
                if(TempData["result"] != null)
                {
                    ViewBag.Success = true;
                    ViewBag.SuccessMessage = TempData["result"];
                }
                return View(result.ResultObj);
            }
            return View(result);
        }
        [HttpGet]
        public async Task<JsonResult> GetListSiQuanAutoComplete(string preconfix)
        {
            var result = await _siQuanApiClient.GetFullListSiQuanAutocomplete(preconfix);
            return Json(result.ResultObj);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(QLQuaTrinhDaoTaoCreateRequest request)
        {
            var result = await _qLQuaTrinhDaoTaoApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Tạo quá trình đào tạo thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
       
    }
}