using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.ApiIntergration;
using QLSQ.WebApp.Models;

namespace QLSQ.WebApp.Controllers
{
    public class DetailNewController : Controller
    {
        public readonly INewApiClient _newApiClient;
        public DetailNewController(INewApiClient newApiClient)
        {
            _newApiClient = newApiClient;
        }
        public async Task<IActionResult> Index(int NewID)
        {
            var result = await _newApiClient.DetailNew(NewID);
            var listMostViewNew = await _newApiClient.GetMostViewNew();
            var detailNewVM = new DetailNewViewModel()
            {
                NewID = NewID,
                NewDatePost = result.ResultObj.NewDatePost,
                NewName = result.ResultObj.NewName,
                NewContent = result.ResultObj.NewContent,
                ImagePath = result.ResultObj.ImagePath,
                NewCatetoryID = result.ResultObj.NewCatetoryID,
                NewCatetoryName = result.ResultObj.NewCatetoryName,
                ListMostViewNew = listMostViewNew.ResultObj
            };
            var listRelatedNew = await _newApiClient.GetRelatedNew(detailNewVM.NewCatetoryID);
            detailNewVM.ListRelatedNew = listRelatedNew.ResultObj;
            return View(detailNewVM);
        }
    }
}