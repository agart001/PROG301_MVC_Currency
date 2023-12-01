
namespace PROG301_MVC_Currency.Interfaces
{
    /// <summary>
    /// Represents an interface for managing currency repositories and coin-related operations.
    /// </summary>
    public interface ICurrencyRepo
    {
        /// <summary>
        /// Gets or sets a list of ICoin objects within the currency repository.
        /// </summary>
        public List<ICoin> Coins { get; set; }

        /// <summary>
        /// Provides a description of the currency repository (to be implemented).
        /// </summary>
        /// <returns>A string describing the currency repository.</returns>
        public string About();

        /// <summary>
        /// Adds an ICoin object to the currency repository.
        /// </summary>
        /// <param name="coin">The ICoin object to be added to the repository.</param>
        public void AddCoin(ICoin coin);

        /// <summary>
        /// Removes an ICoin object from the currency repository.
        /// </summary>
        /// <param name="coin">The ICoin object to be removed from the repository.</param>
        public void RemoveCoin(ICoin coin);

        /// <summary>
        /// Retrieves the count of ICoin objects in the currency repository.
        /// </summary>
        /// <returns>The count of ICoin objects in the repository.</returns>
        public int GetCoinCount();

        /// <summary>
        /// Calculates and returns the total value of the ICoin objects in the currency repository.
        /// </summary>
        /// <returns>The total value of the ICoin objects in the repository.</returns>
        public decimal TotalValue();

        /// <summary>
        /// Creates a new currency repository with change for a specified amount.
        /// </summary>
        /// <param name="Amount">The amount for which change needs to be made.</param>
        /// <returns>A new currency repository with the change for the specified amount.</returns>
        public ICurrencyRepo MakeChange(decimal Amount);

        /// <summary>
        /// Creates a new currency repository with change for a given amount tendered and total cost.
        /// </summary>
        /// <param name="AmountTendered">The amount tendered by the customer.</param>
        /// <param name="TotalCost">The total cost of the purchase.</param>
        /// <returns>A new currency repository with the change for the given transaction.</returns>
        public ICurrencyRepo MakeChange(decimal AmountTendered, decimal TotalCost);
    }
}
