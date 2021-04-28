using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QLSQ.Application.Catalog.QLQuanHam;
using QLSQ.ViewModel.Catalogs.QLQuanHam;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLQuanHamsController : ControllerBase
    {
        public readonly IQLQuanHamServices _qLQuanHamServices;
        public QLQuanHamsController(IQLQuanHamServices qLQuanHamServices)
        {
            _qLQuanHamServices = qLQuanHamServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery]GetQLQuanHamPagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLQuanHamServices.GetAllWithPaging(request);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("{IDQLQH}/details")]
        public async Task<IActionResult> Details(int IDQLQH)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLQuanHamServices.Details(IDQLQH);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]QLQuanHamCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLQuanHamServices.Create(request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("{IDQLQH}/edit")]
        public async Task<IActionResult> Edit(int IDQLQH,[FromBody] QLQuanHamUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLQuanHamServices.Edit(IDQLQH, request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("{IDQLQH}/delete")]
        public async Task<IActionResult> Delete(int IDQLQH)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLQuanHamServices.Delete(IDQLQH);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
    }
}