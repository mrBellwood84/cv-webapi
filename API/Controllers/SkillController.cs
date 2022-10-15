using Application.DataService;
using Domain.Shared;
using Domain.Skill;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly IDataService _dataService;

        public SkillController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Skill>>> GetAll()
        {
            try
            {
                var result = await _dataService.Skill.GetAll();
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Authorize (Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<Skill>> AddSingle(Skill skill)
        {
            try
            {
                await _dataService.Skill.AddSingle(skill);
                return Ok(skill);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<ActionResult<Skill>> UpdateSingle(Skill skill)
        {
            try
            {
                await _dataService.Skill.UpdateSingle(skill);
                return Ok(skill);
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
                await _dataService.Skill.DeleteSingle(request.Id);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
