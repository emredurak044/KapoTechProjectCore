using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KapoTechProjectCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [AllowAnonymous]
    public class ProjectController : Controller
    {
        private ProjectManager _projectManager = new ProjectManager(new EfProjectDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProjectsList()
        {
            var result = _projectManager.TGetList();
            return View(result);
        }
        [HttpGet]
        public IActionResult ProjectsAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProjectsAdd(Project project)
        {
            if (ModelState.IsValid)
            {
                _projectManager.TAdd(project);
                return RedirectToAction("ProjectsList");
            }
            return View();
        }

        public IActionResult ProjectsDeleted(int id)
        {
            if (id != null)
            {
                Project project = _projectManager.TGetByID(id);
                _projectManager.TDelete(project);
                return RedirectToAction("ProjectsList");
            }
            return View();
        }


        [HttpGet]
        public IActionResult ProjectsUpdated(int id)
        {
            var result = _projectManager.TGetByID(id);
            Project project = new Project
            {
                ProjectID = id,
                ProjectName = result.ProjectName,
                Status = result.Status,
                ProjectImage = result.ProjectImage,
                ProjectURL = result.ProjectURL
            };
            return View(result);
        }

        [HttpPost]
        public IActionResult ProjectsUpdated(Project project)
        {
            if (ModelState.IsValid)
            {
                _projectManager.TUpdate(project);
                return RedirectToAction("ProjectsList");
            }
            return View();
        }
    }
}
