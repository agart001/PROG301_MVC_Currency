using static PROG301_MVC_Currency.Statics.Currency.UK;

namespace PROG301_MVC_Currency.Models.UKCoins
{
    /// <summary>
    /// Represents a Pence coin, a type of UK coin.
    /// </summary>
    public class Pence : UKCoin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pence"/> class.
        /// </summary>
        public Pence() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pence"/> class with the specified mint mark.
        /// </summary>
        /// <param name="mark">The mint mark of the Pence.</param>
        public Pence(UKCoinMintMark mark) : base(mark)
        {
        }
    }
}