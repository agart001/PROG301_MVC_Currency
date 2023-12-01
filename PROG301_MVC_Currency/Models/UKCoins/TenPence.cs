using static PROG301_MVC_Currency.Statics.Currency.UK;

namespace PROG301_MVC_Currency.Models.UKCoins
{
    public class TenPence : UKCoin
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TenPence"/> class.
        /// </summary>
        public TenPence() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TenPence"/> class with the specified mint mark.
        /// </summary>
        /// <param name="mark">The mint mark of the Ten Pence.</param>
        public TenPence(UKCoinMintMark mark) : base(mark)
        {
        }
    }
}