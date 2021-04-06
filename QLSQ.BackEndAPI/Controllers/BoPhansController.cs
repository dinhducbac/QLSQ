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
        [HttpPost("create")]
        public async Task<IActionResult> Create(BoPhanCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _boPhanServices.Create(request);
            if (result.IsSuccessed)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("{IDBP}/details")]
        public async Task<IActionResult> Details(int IDBP)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _boPhanServices.Details(IDBP);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("{IDBP}/edit")]
        public async Task<IActionResult> Edit(int IDBP, BoPhanUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _boPhanServices.Edit(IDBP, request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("{IDBP}/delete")]
        public async Task<IActionResult> Delete(int IDBP) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _boPhanServices.Delete(IDBP);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
    }  
}