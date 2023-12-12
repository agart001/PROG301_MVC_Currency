using PROG301_MVC_Currency.Commands;
using PROG301_MVC_Currency.Interfaces;
using System.Collections.Generic;
using System.Windows.Input;

namespace PROG301_MVC_Currency.ViewModels
{
    /// <summary>
    /// ViewModel for managing a currency repository.
    /// </summary>
    public class CurrencyRepoViewModel : BaseViewModel
    {
        private ICurrencyRepo CurRepo { get; set; }

        #region Commands

        #region Add

        /// <summary>
        /// Command to add a coin to the currency repository.
        /// </summary>
        public ICommand AddCoinCommand { get; set; }
        private bool CanAddCoin(object parameter) => true;

        /// <summary>
        /// Command to add a specified amount of coins to the currency repository.
        /// </summary>
        public ICommand AddAmountCommand { get; set; }
        private bool CanAddAmount(object parameter) => true;

        #endregion

        #region Remove

        /// <summary>
        /// Command to remove a coin from the currency repository.
        /// </summary>
        public ICommand RemoveCoinCommand { get; set; }
        private bool CanRemoveCoin(object parameter) => true;

        /// <summary>
        /// Command to remove a specified amount of coins from the currency repository.
        /// </summary>
        public ICommand RemoveAmountCommand { get; set; }
        private bool CanRemoveAmount(object parameter) => true;

        #endregion

        #region Change

        /// <summary>
        /// Command to make change based on the provided amount and total cost.
        /// </summary>
        public ReturnCommand<ICurrencyRepo> MakeChangeCommand { get; set; }
        private bool CanMakeChange(object parameter) => true;

        /// <summary>
        /// Command to create change based on the provided amount and total cost.
        /// </summary>
        public ReturnCommand<ICurrencyRepo> CreateChangeCommand { get; set; }
        private bool CanCreateChange(object parameter) => true;

        #endregion

        #region Convert

        /// <summary>
        /// Command to convert coins of the specified type.
        /// </summary>
        public ReturnCommand<ICurrencyRepo> ConvertCoinsCommand { get; set; }
        private bool CanConvertCoins(object parameter) => true;

        #endregion

        #endregion

        /// <summary>
        /// Default constructor for <see cref="CurrencyRepoViewModel"/>.
        /// </summary>
        public CurrencyRepoViewModel() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyRepoViewModel"/> class.
        /// </summary>
        /// <param name="repo">The currency repository to be managed by the ViewModel.</param>
        public CurrencyRepoViewModel(ICurrencyRepo repo)
        {
            CurRepo = repo;

            #region Set Commands

            AddCoinCommand = new BasicCommand(AddCoin, CanAddCoin);
            AddAmountCommand = new BasicCommand(AddAmount, CanAddAmount);

            RemoveCoinCommand = new BasicCommand(RemoveCoin, CanRemoveCoin);

            MakeChangeCommand = new ReturnCommand<ICurrencyRepo>(MakeChange, CanMakeChange);
            CreateChangeCommand = new ReturnCommand<ICurrencyRepo>(CreateChange, CanCreateChange);

            ConvertCoinsCommand = new ReturnCommand<ICurrencyRepo>(ConvertCoins, CanConvertCoins);

            #endregion
        }

        #region Return Methods

        /// <summary>
        /// Gets information about the currency repository.
        /// </summary>
        public string About
        {
            get => CurRepo.About();
        }

        /// <summary>
        /// Gets the type of the currency repository.
        /// </summary>
        public Type Type
        {
            get => CurRepo.GetType();
        }

        /// <summary>
        /// Gets a list of coins in the currency repository.
        /// </summary>
        public List<ICoin> Coins
        {
            get => CurRepo.Coins;
        }

        /// <summary>
        /// Gets the count of coins in the currency repository.
        /// </summary>
        public int CoinCount
        {
            get => CurRepo.GetCoinCount();
        }

        /// <summary>
        /// Gets a dictionary with counts of each type of coin in the currency repository.
        /// </summary>
        public Dictionary<Type, int> CoinCounts
        {
            get => CurRepo.GetCoinCounts();
        }

        /// <summary>
        /// Gets the total value of the coins in the currency repository.
        /// </summary>
        public decimal TotalValue
        {
            get => CurRepo.TotalValue();
        }

        /// <summary>
        /// Gets the total value of the coins in XAU (Gold) in the currency repository.
        /// </summary>
        public decimal TotalXAUValue
        {
            get => CurRepo.TotalXAUValue();
        }

        #endregion

        #region Command Methods

        #region Add

        /// <summary>
        /// Adds a specified amount of a coin type to the currency repository.
        /// </summary>
        /// <param name="parameter">An array containing the coin type and the amount to add.</param>
        private void AddCoin(object parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            object[] parameters = (object[])parameter;
            Type type = (Type)parameters[0];
            int amount = int.Parse((string)parameters[1]);

            ICoin coin = (ICoin)Activator.CreateInstance(type) ?? throw new ArgumentException(nameof(type));

            for (int i = 0; i < amount; i++)
            {
                CurRepo.AddCoin(coin);
            }
        }

        /// <summary>
        /// Adds the coins from a temporary currency repository to the current repository.
        /// </summary>
        /// <param name="parameter">The parameters used to create a temporary currency repository.</param>
        private void AddAmount(object parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));
            ICurrencyRepo repo = CreateChange(parameter);

            foreach (var coin in repo.Coins)
            {
                CurRepo.AddCoin(coin);
            }
        }

        #endregion

        #region Remove

        /// <summary>
        /// Removes a specified amount of a coin type from the currency repository.
        /// </summary>
        /// <param name="parameter">An array containing the coin type and the amount to remove.</param>
        private void RemoveCoin(object parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            object[] parameters = (object[])parameter;
            Type type = (Type)parameters[0];
            int amount = int.Parse((string)parameters[1]);

            ICoin coin = (ICoin)Activator.CreateInstance(type) ?? throw new ArgumentException(nameof(type));

            for (int i = 0; i < amount; i++)
            {
                CurRepo.RemoveCoin(coin);
            }
        }

        /// <summary>
        /// Removes the coins from a temporary currency repository from the current repository.
        /// </summary>
        /// <param name="parameter">The parameters used to create a temporary currency repository.</param>
        private void RemoveAmount(object parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));
            ICurrencyRepo repo = CreateChange(parameter);

            foreach (var coin in repo.Coins)
            {
                CurRepo.RemoveCoin(coin);
            }
        }

        #endregion

        #region Change

        /// <summary>
        /// Makes change in the currency repository based on the provided amount and total cost.
        /// </summary>
        /// <param name="parameter">An array containing the amount and total cost for making change.</param>
        /// <returns>The resulting currency repository after making change.</returns>
        private ICurrencyRepo MakeChange(object parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            ICurrencyRepo repo = null;

            object[] parameters = (object[])parameter;
            decimal amount = decimal.Parse((string)parameters[0]);
            decimal total = decimal.Parse((string)parameters[1] ?? "0");

            repo = CurRepo.MakeChange(amount, total);

            return repo;
        }

        /// <summary>
        /// Creates change in the currency repository based on the provided amount and total cost.
        /// </summary>
        /// <param name="parameter">An array containing the amount and total cost for creating change.</param>
        /// <returns>The resulting currency repository after creating change.</returns>
        private ICurrencyRepo CreateChange(object parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            ICurrencyRepo repo = null;

            object[] parameters = (object[])parameter;
            decimal amount = decimal.Parse((string)parameters[0]);
            decimal total = decimal.Parse((string)parameters[1] ?? "0");

            repo = CurRepo.CreateChange(amount, total);

            return repo;
        }

        #endregion

        #region Convert

        /// <summary>
        /// Converts coins of the specified type in the currency repository.
        /// </summary>
        /// <param name="parameter">The type of coins to convert.</param>
        /// <returns>The resulting currency repository after converting coins.</returns>
        private ICurrencyRepo ConvertCoins(object parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            ICurrencyRepo repo = null;
            Type type = (Type)parameter;

            repo = CurRepo.ConvertCoins(type);

            return repo;
        }

        #endregion

        #endregion
    }
}
