using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.NewCatetory;
using QLSQ.ViewModel.Catalogs.NewCatetory;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewCatetorysController : ControllerBase
    {
        public readonly INewCatetoryServices _newCatetoryServices;
        public NewCatetorysController(INewCatetoryServices newCatetoryServices)
        {
            _newCatetoryServices = newCatetoryServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery] GetNewCatetoryPagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _newCatetoryServices.GetAllWithPaging(request);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] NewCatetoryCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _newCatetoryServices.Create(request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("{NewCatetoryID}/details")]
        public async Task<IActionResult> Details(int NewCatetoryID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _newCatetoryServices.Details(NewCatetoryID);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("{NewCatetoryID}/edit")]
        public async Task<IActionResult> Edit(int NewCatetoryID, [FromBody] NewCatetoryUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _newCatetoryServices.Edit(NewCatetoryID,request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("{NewCatetoryID}/delete")]
        public async Task<IActionResult> Delete(int NewCatetoryID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _newCatetoryServices.Delete(NewCatetoryID);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
    }
}