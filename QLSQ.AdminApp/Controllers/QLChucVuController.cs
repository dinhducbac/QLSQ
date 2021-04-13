using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.QLChucVu;

namespace QLSQ.AdminApp.Controllers
{
    public class QLChucVuController : Controller
    {
        public readonly IQLChucVuApiClient _qLChucVuApiClient;
        public QLChucVuController(IQLChucVuApiClient qLChucVuApiClient)
        {
            _qLChucVuApiClient = qLChucVuApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex =1, int pageSize = 10)
        {
            var qlcvPagingRequest = new GetQLChucVuPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _qLChucVuApiClient.GetAllWithPaging(qlcvPagingRequest);
            if (ViewData["result"] != null)
            {
                ViewBag.Success = true;
                ViewBag.SuccessMessage = ViewData["result"];
            }
            return View(result.ResultObj);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var qlcvCreateRequest = new QLChucVuCreateRequest()
            {
                quanHamViewModels = new List<ViewModel.Catalogs.QuanHam.QuanHamViewModel>(),
                boPhanViewModels = new List<ViewModel.Catalogs.BoPhan.BoPhanViewModel>(),
                chucVuViewModels = new List<ViewModel.Catalogs.ChucVu.ChucVuViewModel>()
            };
            return View();
        }
    }
}