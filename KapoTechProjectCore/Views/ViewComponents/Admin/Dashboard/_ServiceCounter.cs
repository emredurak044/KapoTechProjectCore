using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KapoTechProjectCore.Views.ViewComponents.Admin.Dashboard
{
    public class _ServiceCounter : ViewComponent
    {
        private Context _context = new Context();
        public IViewComponentResult Invoke()
        {
            var serviceCount = _context.Services.Count();
            ViewBag.ServiceCount = serviceCount;
            return View();
        }
    }
}

