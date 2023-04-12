using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace KapoTechProjectCore.Views.ViewComponents.Admin.Dashboard
{
    public class _AdminProjectList : ViewComponent
    {
        private Context _context = new Context();

        public IViewComponentResult Invoke()
        {
            var projectList = _context.Projects.ToList();
            return View(projectList);
        }
    }
}
