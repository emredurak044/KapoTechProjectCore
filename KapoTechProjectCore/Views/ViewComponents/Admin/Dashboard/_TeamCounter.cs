using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace KapoTechProjectCore.Views.ViewComponents.Admin.Dashboard
{
    public class _TeamCounter : ViewComponent
    {
        private Context _context = new Context();
        public IViewComponentResult Invoke()
        {
            var teamCount = _context.Teams.Count();
            ViewBag.TeamCount = teamCount;
            return View();
        }
    }
}
