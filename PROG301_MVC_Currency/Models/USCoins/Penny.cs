using static PROG301_MVC_Currency.Statics.Currency.US;

namespace PROG301_MVC_Currency.Models.USCoins
{
    /// <summary>
    /// Represents a Penny, a type of US coin.
    /// </summary>
    public class Penny : USCoin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Penny"/> class with default values.
        /// </summary>
        public Penny() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Penny"/> class with the specified mint mark and a specific year.
        /// </summary>
        /// <param name="mark">The mint mark of the Penny.</param>
        public Penny(USCoinMintMark mark) : base(mark)
        {
        }
    }
}
