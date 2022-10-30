using Application.DataService;
using Domain.Project;
using Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IDataService _dataService;

        public ProjectController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetAllProjectData()
        {
            try
            {
                var data = await _dataService.Portfolio.GetAll();
                return Ok(data);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<Project>> AddSingleProject(Project project)
        {
            try
            {
                await _dataService.Portfolio.AddSingle(project);
                return Ok(project);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<ActionResult<Project>> UpdateSingleProject(Project project)
        {
            try
            {
                await _dataService.Portfolio.UpdateSingle(project);
                return Ok(project);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<ActionResult<Project>> DeleteSingleProject(RequestById request)
        {
            try
            {
                await _dataService.Portfolio.DeleteSingle(request.Id);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }


}
