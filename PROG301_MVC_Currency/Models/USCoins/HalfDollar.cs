using static PROG301_MVC_Currency.Statics.Currency.US;

namespace PROG301_MVC_Currency.Models.USCoins
{
    /// <summary>
    /// Represents a Half Dollar, a type of US coin.
    /// </summary>
    public class HalfDollar : USCoin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HalfDollar"/> class with default values.
        /// </summary>
        public HalfDollar() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="HalfDollar"/> class with the specified mint mark.
        /// </summary>
        /// <param name="mark">The mint mark of the Half Dollar.</param>
        public HalfDollar(USCoinMintMark mark) : base(mark)
        {
        }
    }
}
