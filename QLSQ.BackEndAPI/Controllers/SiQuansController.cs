using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.SiQuan;
using QLSQ.Application.Catalog.SiQuans;
using QLSQ.ViewModel.Catalogs.SiQuan;
using QLSQ.ViewModel.Catalogs.SiQuanImage;

namespace QLSQ.BackEndAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SiQuansController : ControllerBase
    {
        private readonly IPublicSiQuanServices _publicSiQuanServices;
        private readonly IManageSiQuanServices _manageSiQuanServices;
        public SiQuansController(IPublicSiQuanServices publicSiQuanServices,IManageSiQuanServices manageSiQuanServices)
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
        [HttpGet("manage-paging")]
        public async Task<IActionResult> GetAllManagePaging([FromQuery] GetManageSiQuanPagingRequest request)
        {
            var siquan = await _manageSiQuanServices.GetAllPaging(request);
            return Ok(siquan);
        }
        [HttpGet("{IDSQ}/detail")]
        public async Task<IActionResult> GetById(int IDSQ)
        {
            var siquan = await _manageSiQuanServices.GetById(IDSQ);
            return Ok(siquan);
        }
        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody]SiQuanCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var siquanId = await _manageSiQuanServices.Create(request);
            if (siquanId.ResultObj == 0)
                return BadRequest(siquanId);
            return Ok(siquanId);
            //var siquan = await _manageSiQuanServices.GetById(siquanId.ResultObj);
            //return CreatedAtAction(nameof(GetById),siquanId);
        }
        [HttpPut("{IDSQ}/update")]
        public async Task<IActionResult> Update(int IDSQ,[FromBody]SiQuanUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageSiQuanServices.Update(IDSQ,request);
            if (!result.IsSuccessed)
                return BadRequest();
            //var siquan = await _manageSiQuanServices.GetById(result);
            return Ok(result);
        }
        [HttpDelete("{IDSQ}/delete")]
        public async Task<IActionResult> Delete( int IDSQ, [FromBody] SiQuanDeleteRequest request)
        {
            var result = await _manageSiQuanServices.Detele(IDSQ, request);
            if (!result.IsSuccessed)
                return BadRequest();
            return Ok();
        }
        // SiQuanImage---------------------------------------------------------------------
        [HttpPost("{IDSQ}/images")]
        public async Task<IActionResult> AddImage( int IDSQ, [FromForm]SiQuanImageCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var siquanImageID = await _manageSiQuanServices.AddImages(IDSQ, request);
            if (siquanImageID == 0)
                return BadRequest();
            //return Ok();
            var siquanimage = await _manageSiQuanServices.GetImageByID(siquanImageID);
            return CreatedAtAction(nameof(GetImageByID), siquanimage);
        }
        [HttpGet("{IDImage}/images")]
        public async Task<IActionResult> GetImageByID(int IDImage)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var siquanImage = await _manageSiQuanServices.GetImageByID(IDImage);
            return Ok(siquanImage);
        }
        [HttpDelete("{IDImage}/images")]
        public async Task<IActionResult> RemoveImages(int IDImage)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _manageSiQuanServices.RemoveImages(IDImage);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}