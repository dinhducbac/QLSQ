using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.Slide;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidesController : ControllerBase
    {
        public readonly ISlideServices _slideServices;
        public SlidesController(ISlideServices slideServices)
        {
            _slideServices = slideServices;
        }
        [HttpGet("getallwithoutpaging")]
        public async Task<IActionResult> GetAllWithoutPaging()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _slideServices.GetAllWithoutPaging();
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
    }
}