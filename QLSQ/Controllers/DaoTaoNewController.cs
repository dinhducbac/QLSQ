using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.ApiIntergration;
using QLSQ.WebApp.Models;

namespace QLSQ.WebApp.Controllers
{
    public class DaoTaoNewController : Controller
    {
        public readonly INewApiClient _newApiClient;
        public DaoTaoNewController(INewApiClient newApiClient)
        {
            _newApiClient = newApiClient;
        }
        public async Task<IActionResult> Index()
        {
            var listDaoTaoNew = await _newApiClient.GetListDaoTaoNew();
            var daoTaoNewVM = new DaoTaoNewViewModel()
            {
                ListDaoTaoNew = listDaoTaoNew.ResultObj
            };
            return View(daoTaoNewVM);
        }
    }
}