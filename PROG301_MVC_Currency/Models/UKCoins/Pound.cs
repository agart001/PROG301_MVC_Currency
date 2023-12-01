using static PROG301_MVC_Currency.Statics.Currency.UK;

namespace PROG301_MVC_Currency.Models.UKCoins
{
    /// <summary>
    /// Represents a Pound coin, a type of UK coin.
    /// </summary>
    public class Pound : UKCoin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pound"/> class.
        /// </summary>
        public Pound() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pound"/> class with the specified mint mark.
        /// </summary>
        /// <param name="mark">The mint mark of Pound.</param>
        public Pound(UKCoinMintMark mark) : base(mark)
        {
        }
    }
}