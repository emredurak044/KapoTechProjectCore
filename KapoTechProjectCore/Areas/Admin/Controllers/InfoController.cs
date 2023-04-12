using BusinessLayer.Concrete;
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
    public class InfoController : Controller
    {
        InfoManager _infoManager = new InfoManager(new EfInfoDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult InfoList()
        {
            var result = _infoManager.TGetList();
            return View(result);
        }
        [HttpGet]
        public IActionResult InfoAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InfoAdd(Info info)
        {
            if (ModelState.IsValid)
            {
                _infoManager.TAdd(info);
                return RedirectToAction("InfoList");
            }
            return View();
        }

        public IActionResult InfoDeleted(int id)
        {
            if (id != null)
            {
                Info info = _infoManager.TGetByID(id);
                _infoManager.TDelete(info);
                return RedirectToAction("InfoList");
            }
            return View();
        }


        [HttpGet]
        public IActionResult InfoUpdated(int id)
        {
            var result = _infoManager.TGetByID(id);
            Info info = new Info
            {
                InfoID = id,
                InfoName = result.InfoName,
                Status = result.Status,
                InfoSkill = result.InfoSkill
            };
            return View(result);
        }

        [HttpPost]
        public IActionResult InfoUpdated(Info info)
        {
            if (ModelState.IsValid)
            {
                _infoManager.TUpdate(info);
                return RedirectToAction("InfoList");
            }
            return View();
        }
    }
}
