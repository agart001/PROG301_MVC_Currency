using Microsoft.CodeAnalysis.CSharp.Syntax;
using PROG301_MVC_Currency.Interfaces;
using PROG301_MVC_Currency.Models;
using static PROG301_MVC_Currency.Statics.Repos.CurRep;
using static PROG301_MVC_Currency.Utilities.MethodUtils;

namespace PROG301_MVC_Currency.Repos
{
    /// <summary>
    /// This class represents a repository for managing various coins and currency operations.
    /// </summary>
    public class CurrencyRepo : ICurrencyRepo
    {
        /// <summary>
        /// Gets or sets a list that holds ICoin objects.
        /// </summary>
        public List<ICoin> Coins { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyRepo"/> class.
        /// </summary>
        public CurrencyRepo()
        {
            Coins = new List<ICoin>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyRepo", with coins./> class.
        /// </summary>
        /// <param name="coins">A list of <see cref="ICoin"./></param>
        public CurrencyRepo(List<ICoin> coins)
        {
            Coins = coins;
        }

        /// <summary>
        /// Placeholder method for describing the repository (to be implemented).
        /// </summary>
        public string About()
        {
            throw new NotImplementedException();
        }

        #region Add/Remove Coin

        /// <summary>
        /// Adds a coin to the repository.
        /// </summary>
        /// <param name="coin">The ICoin object to add to the repository.</param>
        public void AddCoin(ICoin coin) => Coins.Add(coin);

        /// <summary>
        /// Removes a coin from the repository.
        /// </summary>
        /// <param name="coin">The ICoin object to remove from the repository.</param>
        public void RemoveCoin(ICoin coin) => Coins.Remove(coin);

        #endregion

        #region Total/Count

        /// <summary>
        /// Returns the count of coins in the repository.
        /// </summary>
        /// <returns>The count of coins in the repository.</returns>
        public int GetCoinCount() => Coins.Count();

        /// <summary>
        /// Creates a dictionary where the key is a given coin's type and the value is the integer count
        /// of that coin type in the repository's coins.
        /// </summary>
        /// <returns>A dictionary of coin counts by type.</returns>
        public Dictionary<Type, int> GetCoinCounts()
        {
            Dictionary<Type, int> counts = new Dictionary<Type, int>();
            Type[] types = RepoCoinDict[GetType()].Select(c => c.GetType()).ToArray();

            foreach (Type t in types)
            {
                int count = Coins.FindAll(c => c.GetType() == t).Count();
                counts[t] = count;
            }

            return counts;
        }

        /// <summary>
        /// Calculates and returns the total value of the coins in the repository.
        /// </summary>
        /// <returns>The total value of the coins in the repository.</returns>
        public decimal TotalValue() => Coins.Sum(coin => coin.Value);

        /// <summary>
        /// Calculates and returns the total XAU value of the coins in the repository.
        /// </summary>
        /// <returns>The total XAU value of the coins in the repository.</returns>
        public decimal TotalXAUValue() => Coins.Sum(coin => coin.XAUValue);

        #endregion

        #region Make Change

        /// <summary>
        /// Creates a new currency repository with change, from the repository's available change, 
        /// for a specified amount.
        /// </summary>
        /// <param name="Amount">The amount for which change needs to be made.</param>
        /// <returns>A new currency repository with the change for the specified amount.</returns>
        public ICurrencyRepo MakeChange(decimal Amount)
        {
            ICurrencyRepo repo = CreateInstance<ICurrencyRepo>(GetType());
            List<ICoin> coins = Coins;

            // Sort the coins in descending order by value.
            coins.Sort((coin1, coin2) => -coin1.Value.CompareTo(coin2.Value));

            int amountInCents = (int)(Amount * 100);

            foreach (var coin in coins)
            {
                int coinValueInCents = (int)(coin.Value * 100);

                if(amountInCents >= coinValueInCents)
                {
                    repo.AddCoin(coin);
                    RemoveCoin(coin);
                    amountInCents -= coinValueInCents;
                }
            }

            return repo;
        }

        /// <summary>
        /// Creates a new currency repository with change, from the repository's available change, 
        /// for a given amount tendered and total cost.
        /// </summary>
        /// <param name="AmountTendered">The amount tendered by the customer.</param>
        /// <param name="TotalCost">The total cost of the purchase.</param>
        /// <returns>A new currency repository with the change for the given transaction.</returns>
        public ICurrencyRepo MakeChange(decimal AmountTendered, decimal TotalCost)
        {
            decimal changeAmount = AmountTendered - TotalCost;

            
            ICurrencyRepo repo = CreateInstance<ICurrencyRepo>(GetType());
            List<ICoin> coins = Coins;

            // Sort the coins in descending order by value.
            coins.Sort((coin1, coin2) => -coin1.Value.CompareTo(coin2.Value));

            int amountInCents = (int)(changeAmount * 100);

            foreach (var coin in coins)
            {
                int coinValueInCents = (int)(coin.Value * 100);

                if(amountInCents >= coinValueInCents)
                {
                    repo.AddCoin(coin);
                    RemoveCoin(coin);
                    amountInCents -= coinValueInCents;
                }
            }

            return repo;
        }

        #endregion

        #region Create Change

        /// <summary>
        /// Creates a new currency repository with change for a specified amount.
        /// </summary>
        /// <param name="Amount">The amount for which change needs to be made.</param>
        /// <returns>A new currency repository with the change for the specified amount.</returns>
        public ICurrencyRepo CreateChange(decimal Amount)
        {
            ICurrencyRepo repo = CreateInstance<ICurrencyRepo>(GetType());
            List<ICoin> coins = CoinValsByType(GetType());

            // Sort the coins in descending order by value.
            coins.Sort((coin1, coin2) => -coin1.Value.CompareTo(coin2.Value));

            int amountInCents = (int)(Amount * 100);

            foreach (var coin in coins)
            {
                int coinValueInCents = (int)(coin.Value * 100);

                while (amountInCents >= coinValueInCents)
                {
                    if (amountInCents <= 0)
                    {
                        break;
                    }
                    repo.AddCoin(coin);
                    amountInCents -= coinValueInCents;
                }
            }

            return repo;
        }

        /// <summary>
        /// Creates a new currency repository with change for a given amount tendered and total cost.
        /// </summary>
        /// <param name="AmountTendered">The amount tendered by the customer.</param>
        /// <param name="TotalCost">The total cost of the purchase.</param>
        /// <returns>A new currency repository with the change for the given transaction.</returns>
        public ICurrencyRepo CreateChange(decimal AmountTendered, decimal TotalCost)
        {
            decimal changeAmount = AmountTendered - TotalCost;

            
            ICurrencyRepo repo = CreateInstance<ICurrencyRepo>(GetType());
            List<ICoin> coins = CoinValsByType(GetType());

            // Sort the coins in descending order by value.
            coins.Sort((coin1, coin2) => -coin1.Value.CompareTo(coin2.Value));

            int amountInCents = (int)(changeAmount * 100);

            foreach (var coin in coins)
            {
                int coinValueInCents = (int)(coin.Value * 100);

                while (amountInCents >= coinValueInCents)
                {
                    if (amountInCents <= 0)
                    {
                        break;
                    }
                    repo.AddCoin(coin);
                    amountInCents -= coinValueInCents;
                }
            }

            return repo;
        }

        #endregion

        public ICurrencyRepo ConvertCoins(Type t)
        {
            ICurrencyRepo repo = CreateInstance<ICurrencyRepo>(t);
            List<ICoin> coins = CoinValsByType(t);
            coins = coins.OrderByDescending(coin => coin.Value).ToList();

            decimal total = TotalXAUValue();

            foreach (ICoin coin in coins)
            {
                // Calculate the number of coins needed to reach the remaining total XAU value
                int numCoinsNeeded = (int)(total / coin.XAUValue);

                // Add the calculated number of coins to the new repository
                for (int i = 0; i < numCoinsNeeded; i++)
                {
                    repo.AddCoin(coin);
                }

                // Update the remaining total XAU value
                total %= coin.XAUValue;
            }

            decimal tot = repo.TotalXAUValue();

            return repo;
        }
    }
}
