using Microsoft.AspNetCore.Mvc;
using ASP_NET_DEMO_EXPERIMENT.Models;
using ASP_NET_DEMO_EXPERIMENT.Views.Data;

namespace ASP_NET_DEMO_EXPERIMENT.Controllers
{
    public class VocabController : Controller
    {
        List<VocabViewModel> vocab = new List<VocabViewModel>();
        public IActionResult Index()
        {


            VocabDAO vocabDAO = new VocabDAO();

            vocab = vocabDAO.FetchAll();
     
            return View("Index",vocab);
        }

        public IActionResult Create()
        {
            var vocabVm = new VocabViewModel();
            return View();
        }

        public IActionResult Edit(int id)
        {
            VocabDAO vocabDAO = new VocabDAO();
            VocabViewModel vocab = vocabDAO.FetchOne(id);
            return View("Edit", vocab);
        }

        public IActionResult Details(int id)
        {
            VocabDAO vocabDAO = new VocabDAO();
            VocabViewModel vocab = vocabDAO.FetchOne(id);
            return View("Details", vocab);
        }


        public IActionResult CreateVocab(VocabViewModel vocabViewModel)
        {
            VocabDAO vocabDAO = new VocabDAO();
            vocabDAO.CreateRow(vocabViewModel);

            return RedirectToAction("Index", vocab);
        }

        public IActionResult ApplyChange(VocabViewModel vocabModel)
        {
            VocabDAO vocabDAO = new VocabDAO();
            vocabDAO.ModifyRow(vocabModel);
            vocab = vocabDAO.FetchAll();
            return View("Index", vocab);
        }

        public IActionResult Delete(int id)
        {
            VocabDAO dao = new VocabDAO();
            dao.Delete(id);
            vocab = dao.FetchAll();
            return View("Index", vocab);
        }
    }
}
