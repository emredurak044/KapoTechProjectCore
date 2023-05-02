using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KapoTechProjectCore.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectAPIController : ControllerBase

    {
        private ProjectManager _projectManager = new ProjectManager(new EfProjectDal());
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_projectManager.TGetList());
        }
        [HttpPost("ProjectAdd")]
        public IActionResult Post(Project project)
        {

            try
            {
                _projectManager.TAdd(project);
                return Ok();
            }
            catch
            {

                return BadRequest();
            }
        }
        [HttpPost("ProjectUpdate")]
        public IActionResult Post(int id, string projectName, string projectImage)
        {
            Project project = _projectManager.TGetByID(id);
            project.ProjectName = projectName;
            project.ProjectImage = projectImage;
            try
            {
                _projectManager.TUpdate(project);
                return Ok();
            }
            catch
            {

                return BadRequest();
            }
        }[HttpDelete("ProjectDelete")]
        public IActionResult ProjectDelete(int id)
        {
            Project project = _projectManager.TGetByID(id);
          
            try
            {
                _projectManager.TDelete(project);
                return Ok();
            }
            catch
            {

                return BadRequest();
            }
        }
    }
}
