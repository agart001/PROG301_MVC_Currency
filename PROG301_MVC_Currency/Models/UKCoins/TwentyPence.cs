using static PROG301_MVC_Currency.Statics.Currency.UK;

namespace PROG301_MVC_Currency.Models.UKCoins
{
    public class TwentyPence : UKCoin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TwentyPence"/> class.
        /// </summary>
        public TwentyPence() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TwentyPence"/> class with the specified mint mark.
        /// </summary>
        /// <param name="mark">The mint mark of Twenty Pence.</param>
        public TwentyPence(UKCoinMintMark mark) : base(mark)
        {
        }
    }
}