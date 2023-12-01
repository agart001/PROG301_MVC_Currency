using PROG301_MVC_Currency.Interfaces;

namespace PROG301_MVC_Currency.Repos
{
    /// <summary>
    /// Represents a repository specific to UK currency-related operations, derived from CurrencyRepo.
    /// </summary>
    public class UKCurrencyRepo : CurrencyRepo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UKCurrencyRepo"/> class.
        /// </summary>
        public UKCurrencyRepo()
        {
            // Constructor for the UK currency repository.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UKCurrencyRepo", with coins./> class.
        /// </summary>
        /// <param name="coins">A list of <see cref="ICoin"./></param>
        public UKCurrencyRepo(List<ICoin> coins) : base(coins) { }
    }
}