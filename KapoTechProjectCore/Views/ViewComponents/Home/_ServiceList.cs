using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using KapoTechProjectCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace KapoTechProjectCore.Views.ViewComponents.Home
{
    public class _ServiceList : ViewComponent
    {
        ServiceManager _serviceManager = new ServiceManager(new EfServiceDal());
        public IViewComponentResult Invoke()
        {
            var result = _serviceManager.TGetList();
            return View(result);
        }
    }
}
