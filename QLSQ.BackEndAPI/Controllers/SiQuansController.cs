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
    //[Authorize]
    public class SiQuansController : ControllerBase
    {
        private readonly IPublicSiQuanServices _publicSiQuanServices;
        private readonly IManageSiQuanServices _manageSiQuanServices;
        public SiQuansController(IPublicSiQuanServices publicSiQuanServices, IManageSiQuanServices manageSiQuanServices)
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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm]SiQuanCreateRequest request)
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
        public async Task<IActionResult> Update(int IDSQ, [FromBody]SiQuanUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageSiQuanServices.Update(IDSQ, request);
            if (!result.IsSuccessed)
                return BadRequest();
            //var siquan = await _manageSiQuanServices.GetById(result);
            return Ok(result);
        }
        [HttpDelete("{IDSQ}/delete")]
        public async Task<IActionResult> Delete(int IDSQ)
        {
            var result = await _manageSiQuanServices.Detele(IDSQ);
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("getnotinqldv")]
        public async Task<IActionResult> GetSiQuanNotInQLDangVien()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var listSq = await _manageSiQuanServices.GetSiQuanNotInQLDangVien();
            if (listSq.IsSuccessed)
                return Ok(listSq);
            return BadRequest(listSq);
        }
        [HttpGet("getallwithoutpaging")]
        public async Task<IActionResult> GetAllWithoutPaging()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var listsq = await _manageSiQuanServices.GetAllWithoutPaging();
            if (listsq.IsSuccessed)
                return Ok(listsq);
            return BadRequest(listsq);

        }
        [HttpGet("getlistsiquanautocomplete")]
        public async Task<IActionResult> GetListSiQuanAutocomplete(string preconfix)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var listsq = await _manageSiQuanServices.GetListSiQuanAutocomplete(preconfix);
            if (listsq.IsSuccessed)
                return Ok(listsq);
            return BadRequest(listsq);
        }
        [HttpGet("getfulllistsiquanautocomplete")]
        public async Task<IActionResult> GetFullListSiQuanAutocomplete(string preconfix)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var listsq = await _manageSiQuanServices.GetFullListSiQuanAutocomplete(preconfix);
            if (listsq.IsSuccessed)
                return Ok(listsq);
            return BadRequest(listsq);
        }
        [HttpGet("getlistsiquannotinqlquanhamautocomplete")]
        public async Task<IActionResult> GetListSiQuanNotInQLQuanHamAutocomplete(string prefix)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var listsq = await _manageSiQuanServices.GetListSiQuanNotInQLQuanHamAutocomplete(prefix);
            if (listsq.IsSuccessed)
                return Ok(listsq);
            return BadRequest(listsq);
        }
        [HttpGet("getlistsiquannotinqlchucvuautocomplete")]
        public async Task<IActionResult> GetListSiQuanNotInQLChucVuAutocomplete(string prefix)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var listsq = await _manageSiQuanServices.GetListSiQuanNotInQLChucVuAutocomplete(prefix);
            if (listsq.IsSuccessed)
                return Ok(listsq);
            return BadRequest(listsq);
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
        [HttpGet("{UserName}/getprofilebyusername")]
        public async Task<IActionResult> GetUserNameByUserName(string UserName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _publicSiQuanServices.GetProfileByUsername(UserName);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("{IDSQ}/getinfoofjobofsiquan")]
        public async Task<IActionResult> GetInfoOfJobOfSiQuan(int IDSQ)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _publicSiQuanServices.GetInfoOfJobOfSiQuan(IDSQ);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
    }
}