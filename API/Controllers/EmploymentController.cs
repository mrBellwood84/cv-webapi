using Application.DataService;
using Domain.Employment;
using Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploymentController : ControllerBase
    {
        private readonly IDataService _dataService;

        public EmploymentController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet] 
        public async Task<ActionResult<List<Employment>>> GetAll()
        {
            try
            {
                var result = await _dataService.Employment.GetAll();
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<Employment>> AddSingle(Employment employment)
        {
            try
            {
                await _dataService.Employment.AddSingle(employment);
                return Ok(employment);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<ActionResult<Employment>> UpdateSingle(Employment employment)
        {
            try
            {
                await _dataService.Employment.UpdateSingle(employment);
                return Ok(employment);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSingle(RequestById request)
        {
            try
            {
                await _dataService.Employment.DeleteSingle(request.Id);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
