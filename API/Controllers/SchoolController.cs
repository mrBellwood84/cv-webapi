using Application.DataService;
using Domain.School;
using Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IDataService _dataService;

        public SchoolController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<ActionResult<List<School>>> GetAllSchoolEntities()
        {
            try
            {
                var data = await _dataService.School.GetAll();
                return Ok(data);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<School>> AddSingleSchool(School school)
        {
            try
            {
                await _dataService.School.AddSingleSchool(school);
                return Ok(school);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Authorize(Roles ="admin")]
        [HttpPut]
        public async Task<ActionResult<School>> UpdateSingleSchool(School school)
        {
            try
            {
                await _dataService.School.UpdateSchool(school);
                return Ok(school);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Authorize(Roles ="admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSingleSchool(RequestById request)
        {
            try
            {
                await _dataService.School.DeleteSchool(request.Id);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
}
