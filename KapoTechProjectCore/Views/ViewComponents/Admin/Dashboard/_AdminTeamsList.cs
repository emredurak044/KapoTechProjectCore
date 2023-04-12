using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace KapoTechProjectCore.Views.ViewComponents.Admin.Dashboard
{
    public class _AdminTeamsList: ViewComponent
    {
        private TeamManager _teamManager = new TeamManager(new EfTeamDal());

        public IViewComponentResult Invoke()
        {
            var teamList = _teamManager.TGetList();
            return View(teamList);
        }
    }
}
