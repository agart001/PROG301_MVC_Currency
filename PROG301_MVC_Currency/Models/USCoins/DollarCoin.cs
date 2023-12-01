using static PROG301_MVC_Currency.Statics.Currency.US;

namespace PROG301_MVC_Currency.Models.USCoins
{
    /// <summary>
    /// Represents a Dollar Coin, a type of US coin.
    /// </summary>
    public class DollarCoin : USCoin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DollarCoin"/> class with default values.
        /// </summary>
        public DollarCoin() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DollarCoin"/> class with the specified mint mark.
        /// </summary>
        /// <param name="mark">The mint mark of the Dollar Coin.</param>
        public DollarCoin(USCoinMintMark mark) : base(mark)
        {
        }
    }
}
