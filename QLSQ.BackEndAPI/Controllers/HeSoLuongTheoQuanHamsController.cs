using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.HeSoLuongTheoQuanHam;
using QLSQ.ViewModel.Catalogs.HeSoLuongTheoQuanHam;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeSoLuongTheoQuanHamsController : ControllerBase
    {
        public readonly IHeSoLuongTheoQuanHamServices _heSoLuongTheoQuanHamServices;
        public HeSoLuongTheoQuanHamsController(IHeSoLuongTheoQuanHamServices heSoLuongTheoQuanHamServices)
        {
            _heSoLuongTheoQuanHamServices = heSoLuongTheoQuanHamServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery]GetPagingRequestHeSoLuongTheoQuanHam request)
        {
            var result = await _heSoLuongTheoQuanHamServices.GetAllWithPaging(request);
            return Ok(result);
        }
    }
}