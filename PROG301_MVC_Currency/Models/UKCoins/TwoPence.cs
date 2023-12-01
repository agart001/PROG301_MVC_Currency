using static PROG301_MVC_Currency.Statics.Currency.UK;

namespace PROG301_MVC_Currency.Models.UKCoins
{
    public class TwoPence : UKCoin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TwoPence"/> class.
        /// </summary>
        public TwoPence() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TwoPence"/> class with the specified mint mark.
        /// </summary>
        /// <param name="mark">The mint mark of the Two Pence.</param>
        public TwoPence(UKCoinMintMark mark) : base(mark)
        {
        }
    }
}