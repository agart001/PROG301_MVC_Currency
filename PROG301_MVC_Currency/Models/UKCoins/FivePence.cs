using static PROG301_MVC_Currency.Statics.Currency.UK;

namespace PROG301_MVC_Currency.Models.UKCoins
{
    /// <summary>
    /// Represents a Five Pence coin, a type of UK coin.
    /// </summary>
    public class FivePence : UKCoin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FivePence"/> class.
        /// </summary>
        public FivePence() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FivePence"/> class with the specified mint mark.
        /// </summary>
        /// <param name="mark">The mint mark of the Five Pence.</param>
        public FivePence(UKCoinMintMark mark) : base(mark)
        {
        }
    }
}