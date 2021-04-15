using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.QLNghiPhep;
using QLSQ.ViewModel.Catalogs.QLNghiPHep;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLNghiPhepsController : ControllerBase
    {
        public readonly IQLNghiPhepServices _qLNghiPhepServices;
        public QLNghiPhepsController(IQLNghiPhepServices qLNghiPhepServices)
        {
            _qLNghiPhepServices = qLNghiPhepServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery] GetQLNghiPhepPagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLNghiPhepServices.GetAllWithPaging(request);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
    }
}