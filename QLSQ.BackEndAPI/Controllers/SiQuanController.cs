using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLSQ.Application.Catalog.SiQuan;

namespace QLSQ.BackEndAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class SiQuanController : ControllerBase
    {
        private readonly IPublicSiQuanServices _publicSiQuanServices;
        public SiQuanController(IPublicSiQuanServices publicSiQuanServices)
        {
            _publicSiQuanServices = publicSiQuanServices;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var siquan = await _publicSiQuanServices.GetAll();
            return Ok(siquan);
        }
    }
}