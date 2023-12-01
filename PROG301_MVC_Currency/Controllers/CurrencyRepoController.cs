using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROG301_MVC_Currency.Interfaces;
using PROG301_MVC_Currency.Models;
using static PROG301_MVC_Currency.Utilities.RandUtils;

namespace PROG301_MVC_Currency.Controllers
{
    public class CurrencyRepoController : Controller
    {
        private static ICurrencyRepo? currencyRepo {  get; set; }

        public CurrencyRepoController(ICurrencyRepo repo)
        {
            currencyRepo = repo;
            currencyRepo.Coins = GetRandCoinList(currencyRepo.GetType());
        }


        // GET: CurrencyRepoController
        public ActionResult Index()
        {
            if (currencyRepo == null) throw new ArgumentNullException(nameof(currencyRepo));

            return View((IEnumerable<Coin>)currencyRepo.Coins.Cast<Coin>().ToArray() ?? throw new NullReferenceException(nameof(currencyRepo)));
        }

        // GET: CurrencyRepoController/Details/5
        public ActionResult Details(Guid id)
        {
            if (currencyRepo == null) throw new ArgumentNullException(nameof(currencyRepo));
            var selected = currencyRepo.Coins.Select(c => c.ID == id);
            return View();
        }

        // GET: CurrencyRepoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurrencyRepoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CurrencyRepoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CurrencyRepoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CurrencyRepoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CurrencyRepoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
