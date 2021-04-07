using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.HeSoPhuCapTheoChucVu;

namespace QLSQ.AdminApp.Controllers
{
    public class HeSoPhuCapTheoChucVuController : Controller
    {
        public readonly IHeSoPhuCapTheoChucVuApiClient _heSoPhuCapTheoChucVuApiClient;
        public HeSoPhuCapTheoChucVuController(IHeSoPhuCapTheoChucVuApiClient heSoPhuCapTheoChucVuApiClient)
        {
            _heSoPhuCapTheoChucVuApiClient = heSoPhuCapTheoChucVuApiClient;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var cvPagingRequest = new GetHeSoPhuCapPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _heSoPhuCapTheoChucVuApiClient.GetAllWithPaging(cvPagingRequest);
            if (result.IsSuccessed)
            {
                if (ViewData["result"] != null)
                {
                    ViewBag.Success = true;
                    ViewBag.SuccessMessage = ViewData["result"];
                }
                return View(result.ResultObj);
            }
            return View(result);
        }
    }
}