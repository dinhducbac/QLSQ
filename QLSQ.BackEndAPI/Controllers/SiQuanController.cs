using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.SiQuan;
using QLSQ.Application.Catalog.SiQuans;
using QLSQ.ViewModel.Catalogs.SiQuan;

namespace QLSQ.BackEndAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class SiQuanController : ControllerBase
    {
        private readonly IPublicSiQuanServices _publicSiQuanServices;
        private readonly IManageSiQuanServices _manageSiQuanServices;
        public SiQuanController(IPublicSiQuanServices publicSiQuanServices,IManageSiQuanServices manageSiQuanServices)
        {
            _publicSiQuanServices = publicSiQuanServices;
            _manageSiQuanServices = manageSiQuanServices;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var siquan = await _publicSiQuanServices.GetAll();
            return Ok(siquan);
        }
        [HttpGet("public-paging")]
        public async Task<IActionResult> Get([FromQuery]GetPublicSiQuanPagingRequest request)
        {
            var siquan = await _publicSiQuanServices.GetAllBySiQuanId(request);
            return Ok(siquan);
        }
        [HttpGet("{IDSQ}")]
        public async Task<IActionResult> GetById(int IDSQ)
        {
            var siquan = await _manageSiQuanServices.GetById(IDSQ);
            return Ok(siquan);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromQuery]SiQuanCreateRequest request)
        {
            var siquanId = await _manageSiQuanServices.Create(request);
            if (siquanId == 0)
                return BadRequest();
            var siquan = await _manageSiQuanServices.GetById(siquanId);
            return CreatedAtAction(nameof(GetById),siquanId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery]SiQuanUpdateRequest request)
        {
            var siquanId = await _manageSiQuanServices.Update(request);
            if (siquanId == 0)
                return BadRequest();
            var siquan = await _manageSiQuanServices.GetById(siquanId);
            return Ok(siquan);
        }
        [HttpDelete("{IDSQ}")]
        public async Task<IActionResult> Delete([FromQuery] int IDSQ)
        {
            var result = await _manageSiQuanServices.Detele(IDSQ);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}