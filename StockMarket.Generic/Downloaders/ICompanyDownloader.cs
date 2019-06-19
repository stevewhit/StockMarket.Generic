using StockMarket.DataModel;
using System;

namespace StockMarket.Generic.Downloaders
{
    public interface ICompanyDownloader<C> : IDisposable where C : Company
    {
        /// <summary>
        /// Downloads all company details for the given <paramref name="tickerSymbol"/>. The results are deserialized and converted to a useable model.
        /// </summary>
        /// <param name="tickerSymbol">The symbol of the company to download details for.</param>
        /// <returns>Returns company details for the supplied <paramref name="tickerSymbol"/>.</returns>
        C DownloadCompanyDetails(string tickerSymbol);
    }
}
