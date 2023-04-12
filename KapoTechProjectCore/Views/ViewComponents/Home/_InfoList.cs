using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using KapoTechProjectCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace KapoTechProjectCore.Views.ViewComponents.Home
{
    public class _InfoList: ViewComponent
    {
        InfoManager _infoManager = new InfoManager(new EfInfoDal());

        public IViewComponentResult Invoke()
        {
            var result = _infoManager.TGetList();
            return View(result);
        }
    }
}
