using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalog.QLKhenThuongKiLuat;

namespace QLSQ.AdminApp.Controllers
{
    public class QLKhenThuongKiLuatController : Controller
    {
        public readonly IQLKhenThuongKiLuatApiClient _qLKhenThuongKiLuatApiClient;
        public QLKhenThuongKiLuatController(IQLKhenThuongKiLuatApiClient qLKhenThuongKiLuatApiClient)
        {
            _qLKhenThuongKiLuatApiClient = qLKhenThuongKiLuatApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var pagingRequest = new GetQLKhenThuongKiLuatPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _qLKhenThuongKiLuatApiClient.GetAllWithPaging(pagingRequest);
            if (result.IsSuccessed)
            {
                if (TempData["result"] != null)
                {
                    ViewBag.Succsess = true;
                    ViewBag.SuccessMessage = TempData["result"];
                }
                return View(result.ResultObj);
            }
            return View(result);
        }
    }
}