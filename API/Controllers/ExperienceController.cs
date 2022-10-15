using Application.DataService;
using Domain.Experience;
using Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IDataService _dataService;

        public ExperienceController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Experience>>> GetAll(string type)
        {
            
            try
            {
                if (type == "education")
                {
                    var educ = await _dataService.Experience.GetAllEducationExperiences();
                    return Ok(educ);
                }
                if (type == "other")
                {
                    var other = await _dataService.Experience.GetAllOtherExperiences();
                    return Ok(other);
                }
                return BadRequest();
            } 
            catch
            {
                return StatusCode(500);
            }
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<List<Experience>>> AddSingleExperience(Experience experience)
        {
            try
            {
                await _dataService.Experience.AddSingleExperience(experience);
                return Ok(experience);
            } 
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Authorize(Roles ="admin")]
        public async Task<ActionResult<List<Experience>>> UpdateSingleExperience(Experience experience)
        {
            try
            {
                await _dataService.Experience.UpdateExperience(experience);
                return Ok(experience);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> DeleteSingleExperience(RequestById request)
        {
            try
            {
                await _dataService.Experience.DeleteExperience(request.Id);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
}
