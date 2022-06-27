using Microsoft.AspNetCore.Mvc;
using ASP_NET_DEMO_EXPERIMENT.Models;

namespace ASP_NET_DEMO_EXPERIMENT.Controllers
{
    public class MyController : Controller
    {
        public IActionResult Index()
        {
            VocabViewModel list = new VocabViewModel() {Word="SSD",Definition="Solid State Drive"};
            return View(list);
        }

        public IActionResult showVocabList()
        {
            return View();
        }


    }
}
