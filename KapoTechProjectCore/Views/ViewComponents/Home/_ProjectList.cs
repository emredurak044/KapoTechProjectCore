using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using KapoTechProjectCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace KapoTechProjectCore.Views.ViewComponents.Home
{
    public class _ProjectList:ViewComponent
    {
        ProjectManager _projectManager = new ProjectManager(new EfProjectDal());

        public IViewComponentResult Invoke()
        {
            var result = _projectManager.TGetList();
            return View(result);
        }
    }
}
