using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROG301_MVC_Currency.Interfaces;
using PROG301_MVC_Currency.Models;
using PROG301_MVC_Currency.Repos;
using static PROG301_MVC_Currency.Utilities.RandUtils;

namespace PROG301_MVC_Currency.Controllers
{

    public class CurrencyRepoController : Controller
    {
        private static ICurrencyRepo? currencyRepo {  get; set; }

        private static Dictionary<string, Type> currepos = new Dictionary<string, Type>();

        public CurrencyRepoController(ICurrencyRepo repo)
        {
            Type[] types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .Where(t => t.IsSubclassOf(typeof(CurrencyRepo))).ToArray();

            foreach(Type t in types)
            {
                string name = new string(t.Name.TakeWhile(c => c != 'C').ToArray());
                currepos[name] = t;
            }

            currencyRepo = repo;
            currencyRepo.Coins = GetRandCoinList(currencyRepo.GetType());
        }


        // GET: CurrencyRepoController
        public ActionResult Index()
        {
            if (currencyRepo == null) throw new ArgumentNullException(nameof(currencyRepo));

            ViewData["Repo"] = currencyRepo;
            ViewData["RepTypes"] = currepos.Keys.ToArray();
            return View(currencyRepo);
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

        public ActionResult CreateChange(string amount, string cost)
        {
            if (currencyRepo == null) throw new ArgumentNullException(nameof(currencyRepo));

            ICurrencyRepo curRep = null;
            decimal Amount = 0;
            decimal Cost = 0;

            if(amount != null && amount != string.Empty)
            {
                Amount = decimal.Parse(amount);
            }

            if (cost != null && cost != string.Empty)
            {
                Cost = decimal.Parse(cost);
            }

            if(Cost != 0)
            {
                curRep = currencyRepo.CreateChange(Amount, Cost);
            }
            else
            {
                curRep = currencyRepo.CreateChange(Amount);
            }

            if(curRep == null) throw new ArgumentNullException(nameof(curRep));

            ViewData["Repo"] = curRep;
            return View("Change", curRep);
        }

        public ActionResult MakeChange(string amount, string cost)
        {
            if (currencyRepo == null) throw new ArgumentNullException(nameof(currencyRepo));

            ICurrencyRepo curRep = null;
            decimal Amount = 0;
            decimal Cost = 0;

            if (amount != null && amount != string.Empty)
            {
                Amount = decimal.Parse(amount);
            }

            if (cost != null && cost != string.Empty)
            {
                Cost = decimal.Parse(cost);
            }

            if (Cost != 0)
            {
                curRep = currencyRepo.MakeChange(Amount, Cost);
            }
            else
            {
                curRep = currencyRepo.MakeChange(Amount);
            }

            if (curRep == null) throw new ArgumentNullException(nameof(curRep));

            ViewData["Repo"] = curRep;
            return View("Change", curRep);
        }

        public ActionResult ConvertCoin(string type)
        {
            ICurrencyRepo curRep = null;
            Type t = currepos[type];

            curRep = currencyRepo.ConvertCoins(t);

            ViewData["Repo"] = curRep;
            return View("Change", curRep);
        }

        [HttpGet]
        public ActionResult ViewCoins(ICoin[] coins)
        {
            var hold = coins;
            return View("ViewCoins", coins);
        }
    }
}
