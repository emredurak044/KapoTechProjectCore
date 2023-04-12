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
    public class ServiceController : Controller
    {
        ServiceManager _serviceManager = new ServiceManager(new EfServiceDal());
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ServicesList()
        {
            var result = _serviceManager.TGetList();
            return View(result);
        }
        [HttpGet]
        public IActionResult ServicesAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ServicesAdd(Service service)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.TAdd(service);
                return RedirectToAction("ServicesList");
            }
            return View();
        }

        public IActionResult ServicesDeleted(int id)
        {
            if (id != null)
            {
                Service service = _serviceManager.TGetByID(id);
                _serviceManager.TDelete(service);
                return RedirectToAction("ServicesList");
            }
            return View();
        }


        [HttpGet]
        public IActionResult ServicesUpdated(int id)
        {
            var result = _serviceManager.TGetByID(id);
            Service service = new Service
            {
                ServiceID = id,
                ServiceName = result.ServiceName,
                Status = result.Status,
                ImageUrl = result.ImageUrl
            };
            return View(result);
        }

        [HttpPost]
        public IActionResult ServicesUpdated(Service service)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.TUpdate(service);
                return RedirectToAction("ServicesList");
            }
            return View();
        }
    }
}
