using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace KapoTechProjectCore.Views.ViewComponents.Admin.Dashboard
{
    public class _ProjectCounter: ViewComponent
    {
        private Context _context = new Context();

        public IViewComponentResult Invoke()
        {
            var projectCount = _context.Projects.Count();
            ViewBag.ProjectCount = projectCount;
            return View();
        }
    }
}
