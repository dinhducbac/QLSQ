using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.QLGiaDinhSQ;
using QLSQ.ViewModel.Catalogs.QLGiaDinhSQ;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLGiaDinhSQsController : ControllerBase
    {
        public readonly IQLGiaDinhSQServices _qLGiaDinhSQServices;
        public QLGiaDinhSQsController(IQLGiaDinhSQServices qLGiaDinhSQServices)
        {
            _qLGiaDinhSQServices = qLGiaDinhSQServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery]GetQLGiaDinhSQPagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLGiaDinhSQServices.GetAllWithPaging(request);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(QLGiaDinhSQCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLGiaDinhSQServices.Create(request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("{IDQLGDSQ}/details")]
        public async Task<IActionResult> Details(int IDQLGDSQ)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLGiaDinhSQServices.Details(IDQLGDSQ);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("{IDQLGDSQ}/edit")]
        public async Task<IActionResult> Edit(int IDQLGDSQ, QLGiaDinhSQUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLGiaDinhSQServices.Edit(IDQLGDSQ,request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
        
    }
}