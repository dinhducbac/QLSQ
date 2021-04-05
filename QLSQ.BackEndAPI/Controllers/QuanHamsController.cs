using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody]QuanHamCreateRequest request)
        {
            var create = await _quanHamServices.Create(request);
            return Ok(create);
        }
        [HttpPut("{IDQH}/edit")]
        public async Task<IActionResult> Edit(int IDQH, [FromBody] QuanHamUpdateRequest request)
        {
            var edit = await _quanHamServices.Edit(IDQH,request);
            return Ok(edit);
        }
    }
}