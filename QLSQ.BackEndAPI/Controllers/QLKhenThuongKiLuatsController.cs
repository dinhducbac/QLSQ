using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.QLKhenThuongKiLuat;
using QLSQ.ViewModel.Catalog.QLKhenThuongKiLuat;
using QLSQ.ViewModel.Catalogs.QLKhenThuongKiLuat;

namespace QLSQ.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLKhenThuongKiLuatsController : ControllerBase
    {
        public readonly IQLKhenThuongKiLuatServices _qLKhenThuongKiLuatServices;
        public QLKhenThuongKiLuatsController(IQLKhenThuongKiLuatServices qLKhenThuongKiLuatServices)
        {
            _qLKhenThuongKiLuatServices = qLKhenThuongKiLuatServices;
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllWithPaging([FromQuery]GetQLKhenThuongKiLuatPagingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLKhenThuongKiLuatServices.GetAllWithPaging(request);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] QLKhenThuongKiLuatCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLKhenThuongKiLuatServices.Create(request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("{IDQLKTKL}/details")]
        public async Task<IActionResult> Details(int IDQLKTKL)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLKhenThuongKiLuatServices.Details(IDQLKTKL);
            if (result.ResultObj != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("{IDQLKTKL}/edit")]
        public async Task<IActionResult> Edit(int IDQLKTKL, QLKhenThuongKiLuatUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _qLKhenThuongKiLuatServices.Edit(IDQLKTKL, request);
            if (result.ResultObj == true)
                return Ok(result);
            return BadRequest(result);
        }
    }
}