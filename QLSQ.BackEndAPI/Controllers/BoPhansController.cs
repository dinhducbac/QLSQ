using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.BoPhan;
using QLSQ.ViewModel.Catalogs.BoPhan;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoPhansController : ControllerBase
    {
        public readonly IBoPhanServices _boPhanServices;
        public BoPhansController(IBoPhanServices boPhanServices)
        {
            _boPhanServices = boPhanServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery]GetBoPhanPagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _boPhanServices.GetAllWithPaging(request);
            if (result.IsSuccessed)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}