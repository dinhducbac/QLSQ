using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.QLGiaDinhSQ;

namespace QLSQ.AdminApp.Controllers
{
    public class QLGiaDinhSQController : Controller
    {
        public readonly IQLGiaDinhApiClient _qLGiaDinhApiClient;
        public QLGiaDinhSQController(IQLGiaDinhApiClient qLGiaDinhApiClient)
        {
            _qLGiaDinhApiClient = qLGiaDinhApiClient;
        }
        public async Task<IActionResult> Index(string keyword,int pageIndex = 1, int pageSize = 5)
        {
            var qlgdsqPagingRequest = new GetQLGiaDinhSQPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _qLGiaDinhApiClient.GetAllWithPaging(qlgdsqPagingRequest);
            if (result.IsSuccessed)
            {
                if (TempData["result"] != null)
                {
                    ViewBag.Success = true;
                    ViewBag.SuccessMessage = TempData["result"];
                }
                return View(result.ResultObj);
            }
            return View(result);
        }
    }
}