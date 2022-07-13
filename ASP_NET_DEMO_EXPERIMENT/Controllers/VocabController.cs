using Microsoft.AspNetCore.Mvc;
using ASP_NET_DEMO_EXPERIMENT.Models;
using ASP_NET_DEMO_EXPERIMENT.Views.Data;

namespace ASP_NET_DEMO_EXPERIMENT.Controllers
{
    public class VocabController : Controller
    {
        public IActionResult Index()
        {
            List<VocabViewModel> vocab = new List<VocabViewModel>();

            VocabDAO vocabDAO = new VocabDAO();

            vocab = vocabDAO.FetchAll();
     
            return View("Index",vocab);
        }
    }
}
