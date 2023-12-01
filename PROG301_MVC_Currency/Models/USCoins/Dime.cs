using static PROG301_MVC_Currency.Statics.Currency.US;

namespace PROG301_MVC_Currency.Models.USCoins
{
    /// <summary>
    /// Represents a Dime, a type of US coin.
    /// </summary>
    public class Dime : USCoin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dime"/> class with default values.
        /// </summary>
        public Dime() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dime"/> class with the specified mint mark.
        /// </summary>
        /// <param name="mark">The mint mark of the Dime.</param>
        public Dime(USCoinMintMark mark) : base(mark)
        {
        }
    }
}
