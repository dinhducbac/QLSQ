using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.QuanHam;
using QLSQ.ViewModel.Catalogs.QuanHam;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanHamsController : ControllerBase
    {
        private readonly IQuanHamServices _quanHamServices;
        public QuanHamsController(IQuanHamServices quanHamServices)
        {
            _quanHamServices = quanHamServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery]GetQuanHamPagingRequest request) 
        {
            var qlqh = await _quanHamServices.GetAllWithPaging(request);
            return Ok(qlqh);
        }
        [HttpGet("{IDQH}/details")]
        public async Task<IActionResult> Details(int IDQH)
        {
            var qh = await _quanHamServices.Details(IDQH);
            return Ok(qh);
        }
    }
}