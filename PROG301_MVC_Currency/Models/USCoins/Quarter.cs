using static PROG301_MVC_Currency.Statics.Currency.US;

namespace PROG301_MVC_Currency.Models.USCoins
{
    /// <summary>
    /// Represents a Quarter, a type of US coin.
    /// </summary>
    public class Quarter : USCoin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Quarter"/> class with default values.
        /// </summary>
        public Quarter() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Quarter"/> class with the specified mint mark.
        /// </summary>
        /// <param name="mark">The mint mark of the Quarter.</param>
        public Quarter(USCoinMintMark mark) : base(mark)
        {
        }
    }
}
