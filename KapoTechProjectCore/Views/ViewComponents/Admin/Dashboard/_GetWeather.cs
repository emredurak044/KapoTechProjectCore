using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace KapoTechProjectCore.Views.ViewComponents.Admin.Dashboard
{
    public class _GetWeather : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string apikey = "279ab030962429cbb21b0eaf212de199";
            string city = "Malatya";
            string Countries = "Turkey";
            string apiurl = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&mode=xml&units=metric&appid=" + apikey;
            XDocument document = XDocument.Load(apiurl);
            
            ViewBag.Degree = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.City = city;
            ViewBag.Countries = Countries;
            return View();
        }
    }
}
