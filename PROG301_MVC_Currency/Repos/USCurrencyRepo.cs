using PROG301_MVC_Currency.Interfaces;

namespace PROG301_MVC_Currency.Repos
{
    /// <summary>
    /// Represents a repository specific to US currency-related operations, derived from CurrencyRepo.
    /// </summary>
    public class USCurrencyRepo : CurrencyRepo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="USCurrencyRepo"/> class.
        /// </summary>
        public USCurrencyRepo()
        {
            // Constructor for the US currency repository.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="USCurrencyRepo", with coins./> class.
        /// </summary>
        /// <param name="coins">A list of <see cref="ICoin"./></param>
        public USCurrencyRepo(List<ICoin> coins) : base(coins) { }
    }
}
