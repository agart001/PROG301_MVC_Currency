using static PROG301_MVC_Currency.Statics.Currency.US;

namespace PROG301_MVC_Currency.Models.USCoins
{
    /// <summary>
    /// Represents a Nickel, a type of US coin.
    /// </summary>
    public class Nickel : USCoin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Nickel"/> class with default values.
        /// </summary>
        public Nickel() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Nickel"/> class with the specified mint mark.
        /// </summary>
        /// <param name="mark">The mint mark of the Nickel.</param>
        public Nickel(USCoinMintMark mark) : base(mark)
        {
        }
    }
}
