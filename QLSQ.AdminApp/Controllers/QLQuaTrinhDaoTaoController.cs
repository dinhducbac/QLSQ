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
        public QLQuaTrinhDaoTaoController(IQLQuaTrinhDaoTaoApiClient qLQuaTrinhDaoTaoApiClient)
        {
            _qLQuaTrinhDaoTaoApiClient = qLQuaTrinhDaoTaoApiClient;
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
    }
}