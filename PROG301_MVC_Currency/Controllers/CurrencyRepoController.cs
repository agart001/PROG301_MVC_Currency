using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROG301_MVC_Currency.Interfaces;
using PROG301_MVC_Currency.Models;
using PROG301_MVC_Currency.Repos;
using PROG301_MVC_Currency.ViewModels;
using static PROG301_MVC_Currency.Utilities.RandUtils;
using static PROG301_MVC_Currency.Utilities.TypeUtils;

namespace PROG301_MVC_Currency.Controllers
{
    /// <summary>
    /// Controller for managing currency repositories and related actions.
    /// </summary>
    public class CurrencyRepoController : Controller
    {
        private static CurrencyRepoViewModel CurrencyRepoVM { get; set; }

        private static Type[] RepTypes { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyRepoController"/> class.
        /// </summary>
        /// <param name="repo">The currency repository interface implementation.</param>
        public CurrencyRepoController(ICurrencyRepo repo)
        {
            RepTypes = GetSubclasses<CurrencyRepo>();

            repo.Coins = GetRandCoinList(repo.GetType());
            CurrencyRepoVM = new CurrencyRepoViewModel(repo);
        }

        /// <summary>
        /// Displays the index view with information about the currency repository.
        /// </summary>
        /// <returns>The index view.</returns>
        public ActionResult Index()
        {
            ViewData["RepTypes"] = RepTypes;
            ViewData["Title"] = "Home";
            return View(CurrencyRepoVM);
        }

        /// <summary>
        /// Adds coins to the currency repository based on the provided type and amount.
        /// </summary>
        /// <param name="type">The type of the coin to add.</param>
        /// <param name="amount">The amount of the coin to add.</param>
        /// <returns>The index view with updated information.</returns>
        public ActionResult AddCoins(string type, string amount)
        {
            object[] parameters = new object[]
            {
                TypeByName(type),
                amount
            };

            CurrencyRepoVM.AddCoinCommand.Execute(parameters);

            ViewData["RepTypes"] = RepTypes;
            ViewData["Title"] = "Home";
            return View("Index", CurrencyRepoVM);
        }

        /// <summary>
        /// Removes coins from the currency repository based on the provided type and amount.
        /// </summary>
        /// <param name="type">The type of the coin to remove.</param>
        /// <param name="amount">The amount of the coin to remove.</param>
        /// <returns>The index view with updated information.</returns>
        public ActionResult RemoveCoins(string type, string amount)
        {
            object[] parameters = new object[]
            {
                TypeByName(type),
                amount
            };

            CurrencyRepoVM.RemoveCoinCommand.Execute(parameters);

            ViewData["RepTypes"] = RepTypes;
            ViewData["Title"] = "Home";
            return View("Index", CurrencyRepoVM);
        }

        /// <summary>
        /// Creates change based on the provided amount and cost.
        /// </summary>
        /// <param name="amount">The amount for which to create change.</param>
        /// <param name="cost">The cost for which to create change.</param>
        /// <returns>The change view with information about the created change.</returns>
        public ActionResult CreateChange(string amount, string cost)
        {
            object[] parameters = new object[]
            {
                amount,
                cost
            };

            CurrencyRepoVM.CreateChangeCommand.Execute(parameters);

            CurrencyRepoViewModel vm = new CurrencyRepoViewModel(CurrencyRepoVM.CreateChangeCommand.Result);

            ViewData["RepTypes"] = RepTypes;
            ViewData["Title"] = "Create Change";
            return View("Change", vm);
        }

        /// <summary>
        /// Makes change based on the provided amount and cost.
        /// </summary>
        /// <param name="amount">The amount for which to make change.</param>
        /// <param name="cost">The cost for which to make change.</param>
        /// <returns>The change view with information about the made change.</returns>
        public ActionResult MakeChange(string amount, string cost)
        {
            object[] parameters = new object[]
            {
                amount,
                cost
            };

            CurrencyRepoVM.MakeChangeCommand.Execute(parameters);

            CurrencyRepoViewModel vm = new CurrencyRepoViewModel(CurrencyRepoVM.MakeChangeCommand.Result);

            ViewData["RepTypes"] = RepTypes;
            ViewData["Title"] = "Make Change";
            return View("Change", vm);
        }

        /// <summary>
        /// Converts coins of the provided type.
        /// </summary>
        /// <param name="type">The type of coins to convert.</param>
        /// <returns>The change view with information about the converted coins.</returns>
        public ActionResult ConvertCoin(string type)
        {
            object parameter = TypeByName(type);

            CurrencyRepoVM.ConvertCoinsCommand.Execute(parameter);

            CurrencyRepoViewModel vm = new CurrencyRepoViewModel(CurrencyRepoVM.ConvertCoinsCommand.Result);

            ViewData["RepTypes"] = RepTypes;
            ViewData["Title"] = "Convert Coins";
            return View("Change", vm);
        }

        /// <summary>
        /// Displays a view with information about coins of the provided type.
        /// </summary>
        /// <param name="type">The type of coins to view.</param>
        /// <returns>The view with information about the specified type of coins.</returns>
        public ActionResult ViewCoins(string type)
        {
            Type t = TypeByName(type);
            ICoin[] coins = CurrencyRepoVM.Coins.FindAll(c => c.GetType() == t).ToArray();

            IEnumerableViewModel<ICoin> vm = new IEnumerableViewModel<ICoin>(coins, true, true, true, true);

            ViewData["Title"] = "Coins View";
            return View("ViewCoins", vm);
        }
    }
}
