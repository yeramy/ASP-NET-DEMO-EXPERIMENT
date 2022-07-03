using Microsoft.AspNetCore.Mvc;
using ASP_NET_DEMO_EXPERIMENT.Models;

namespace ASP_NET_DEMO_EXPERIMENT.Controllers
{
    public class MyController : Controller
    {
        private static List<VocabViewModel> vocabs = new List<VocabViewModel>();
        public IActionResult Index()
        {
            return View(vocabs);
        }

        public IActionResult Create()
        {
            var vocabVm = new VocabViewModel();
            return View(vocabVm);
        }

        public IActionResult Manage()
        {
            return View(vocabs);
        }

        public IActionResult CreateVocab(VocabViewModel vocabViewModel)
        {
            //return View("Index");
            vocabs.Add(vocabViewModel);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ManageVocab(VocabViewModel vocabViewModel)
        {

            vocabs.Add(vocabViewModel);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult showVocabList()
        {
            return View();
        }


    }
}
