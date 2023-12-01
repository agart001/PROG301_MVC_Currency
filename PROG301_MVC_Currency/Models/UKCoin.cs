
using static PROG301_MVC_Currency.Statics.Currency;
using static PROG301_MVC_Currency.Statics.Currency.UK;

namespace PROG301_MVC_Currency.Models
{
    /// <summary>
    /// Represents an abstract class for UK coins with properties such as MintMark, Year, Name, and Value.
    /// </summary>
    public abstract class UKCoin : Coin
    {
        /// <summary>
        /// Gets or sets the mint mark of the UK coin.
        /// </summary>
        public UKCoinMintMark MintMark { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UKCoin"/> class.
        /// </summary>
        public UKCoin()
        {
            MintMark = UKCoinMintMark.R;
            Year = DateTime.Now.Year;
            Name = UKCoinNameDict[GetType()];
            Value = UKCoinValueDict[GetType()];
            XAUValue = GetXAUValue(typeof(UKCoin), this);
            SetDesc
            (
                CurRegionDict[typeof(UKCoin)], 
                CurSymbolDict[typeof(UKCoin)], 
                UKCoinMintMarkDict[MintMark]
            );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UKCoin"/> class with the specified mint mark.
        /// </summary>
        /// <param name="mintMark">The mint mark of the UK coin.</param>
        public UKCoin(UKCoinMintMark mintMark)
        {
            MintMark = mintMark;
            Year = DateTime.Now.Year;
            Name = UKCoinNameDict[GetType()];
            Value = UKCoinValueDict[GetType()];
            XAUValue = GetXAUValue(typeof(UKCoin), this);
            SetDesc
            (
                CurRegionDict[typeof(UKCoin)], 
                CurSymbolDict[typeof(UKCoin)], 
                UKCoinMintMarkDict[MintMark]
            );
        }
    }
}