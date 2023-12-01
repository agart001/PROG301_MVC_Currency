using static PROG301_MVC_Currency.Statics.Currency.UK;

namespace PROG301_MVC_Currency.Models.UKCoins
{
    /// <summary>
    /// Represents a Fifty Pence coin, a type of UK coin.
    /// </summary>
    public class FiftyPence : UKCoin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FiftyPence"/> class.
        /// </summary>
        public FiftyPence() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FiftyPence"/> class with the specified mint mark.
        /// </summary>
        /// <param name="mark">The mint mark of the Fifty Pence.</param>
        public FiftyPence(UKCoinMintMark mark) : base(mark)
        {
        }
    }
}