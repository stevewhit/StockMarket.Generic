using StockMarket.DataModel;
using System;

namespace StockMarket.Generic.Downloaders
{
    public interface IMarketDownloader<C, Q> : ICompanyDownloader<C>, IQuoteDownloader<Q>, IDisposable where C : Company where Q : Quote
    {
        
    }
}
