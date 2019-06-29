using ServiceStack;
using StockMarket.DataModel;
using StockMarket.Generic.Downloaders.IEXCloud.JSON_Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace StockMarket.Generic.Downloaders.IEXCloud
{
    public interface IEXCloudWrapper : IMarketDownloader<Company, Quote>, IDisposable
    {
        
    }

    [ExcludeFromCodeCoverage]
    public class EXCloudWrapper : IEXCloudWrapper
    {
        private const string _baseUrlLive = "https://cloud.iexapis.com/stable";
        private const string _baseUrl = "https://sandbox.iexapis.com/stable";
        private string _token;
        private bool _isDisposed = false;

        public EXCloudWrapper(string token)
        {
            _token = token;
        }

        #region ICompanyDownloader<Company>

        /// <summary>
        /// Downloads all company details for the given <paramref name="tickerSymbol"/>. The results are deserialized and converted to a useable model.
        /// </summary>
        /// <param name="tickerSymbol">The symbol of the company to download details for.</param>
        /// <returns>Returns company details for the supplied <paramref name="tickerSymbol"/>.</returns>
        Company ICompanyDownloader<Company>.DownloadCompanyDetails(string tickerSymbol)
        {
            return DownloadCompanyDetails(tickerSymbol).BaseCompany;
        }

        #endregion
        #region IQuoteDownloader<Quote>

        /// <summary>
        /// Downloads and returns the last known quote for the given <paramref name="tickerSymbol"/>.
        /// Note: This will not return the current day's quote until 4:00am the following day.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quote for.</param>
        /// <returns>Returns the last known quote for the given <paramref name="tickerSymbol"/>.</returns>
        Quote IQuoteDownloader<Quote>.DownloadPreviousDayQuote(string tickerSymbol)
        {
            return DownloadPreviousDayQuote(tickerSymbol);
        }

        /// <summary>
        /// Downloads and returns quotes within the last 5 days for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 5 days for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Quote> IQuoteDownloader<Quote>.DownloadQuotesFiveDays(string tickerSymbol)
        {
            return DownloadQuotesFiveDays(tickerSymbol);
        }

        /// <summary>
        /// Downloads and returns quotes within the last 1 month for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 1 month for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Quote> IQuoteDownloader<Quote>.DownloadQuotesOneMonth(string tickerSymbol)
        {
            return DownloadQuotesOneMonth(tickerSymbol);
        }

        /// <summary>
        /// Downloads and returns quotes within the last 3 months for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 3 month for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Quote> IQuoteDownloader<Quote>.DownloadQuotesThreeMonths(string tickerSymbol)
        {
            return DownloadQuotesThreeMonths(tickerSymbol);
        }

        /// <summary>
        /// Downloads and returns quotes within the last 5 months for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 5 month for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Quote> IQuoteDownloader<Quote>.DownloadQuotesFiveMonths(string tickerSymbol)
        {
            return DownloadQuotesFiveMonths(tickerSymbol);
        }

        /// <summary>
        /// Downloads and returns quotes within the last 1 year for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 1 year for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Quote> IQuoteDownloader<Quote>.DownloadQuotesOneYear(string tickerSymbol)
        {
            return DownloadQuotesOneYear(tickerSymbol);
        }

        /// <summary>
        /// Downloads and returns quotes within the last 2 years for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 2 years for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Quote> IQuoteDownloader<Quote>.DownloadQuotesTwoYears(string tickerSymbol)
        {
            return DownloadQuotesTwoYears(tickerSymbol);
        }

        /// <summary>
        /// Downloads and returns quotes within the last 5 years for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 5 years for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Quote> IQuoteDownloader<Quote>.DownloadQuotesFiveYears(string tickerSymbol)
        {
            return DownloadQuotesFiveYears(tickerSymbol);
        }

        #endregion
        #region IDisposable

        /// <summary>
        /// Disposes this object and properly cleans up resources. 
        /// </summary>
        protected void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _token = null;
                }

                _isDisposed = true;
            }
        }

        /// <summary>
        /// Disposes this object and properly cleans up resources. 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        /// <summary>
        /// Downloads all company details for the given <paramref name="tickerSymbol"/>. The results are deserialized and converted to a useable model.
        /// </summary>
        /// <param name="tickerSymbol">The symbol of the company to download details for.</param>
        /// <returns>Returns company details for the supplied <paramref name="tickerSymbol"/>.</returns>
        public EXCompany DownloadCompanyDetails(string tickerSymbol)
        {
            if (_isDisposed)
                throw new ObjectDisposedException("EXCloudWrapper", "The wrapper has been disposed.");

            var url = $"{_baseUrl}/stock/{tickerSymbol}/company?token={_token}";

            return url.GetJsonFromUrl().FromJson<EXCompany>();
        }

        /// <summary>
        /// Downloads and returns the last known quote for the given <paramref name="tickerSymbol"/>.
        /// Note: This will not return the current day's quote until 4:00am the following day.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quote for.</param>
        /// <returns>Returns the last known quote for the given <paramref name="tickerSymbol"/>.</returns>
        public EXQuote DownloadPreviousDayQuote(string tickerSymbol)
        {
            if (_isDisposed)
                throw new ObjectDisposedException("EXCloudWrapper", "The wrapper has been disposed.");

            var url = $"{_baseUrl}/stock/{tickerSymbol}/previous?token={_token}";

            return url.GetJsonFromUrl().FromJson<EXQuote>();
        }

        /// <summary>
        /// Downloads and returns quotes within the last 5 days for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 5 days for the company matching the <paramref name="tickerSymbol"/>.</returns>
        public IEnumerable<EXQuote> DownloadQuotesFiveDays(string tickerSymbol)
        {
            return DownloadQuotesInRange(tickerSymbol, "5d");
        }

        /// <summary>
        /// Downloads and returns quotes within the last 1 month for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 1 month for the company matching the <paramref name="tickerSymbol"/>.</returns>
        public IEnumerable<EXQuote> DownloadQuotesOneMonth(string tickerSymbol)
        {
            return DownloadQuotesInRange(tickerSymbol, "1m");
        }

        /// <summary>
        /// Downloads and returns quotes within the last 3 months for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 3 month for the company matching the <paramref name="tickerSymbol"/>.</returns>
        public IEnumerable<EXQuote> DownloadQuotesThreeMonths(string tickerSymbol)
        {
            return DownloadQuotesInRange(tickerSymbol, "3m");
        }

        /// <summary>
        /// Downloads and returns quotes within the last 5 months for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 5 month for the company matching the <paramref name="tickerSymbol"/>.</returns>
        public IEnumerable<EXQuote> DownloadQuotesFiveMonths(string tickerSymbol)
        {
            return DownloadQuotesInRange(tickerSymbol, "5m");
        }

        /// <summary>
        /// Downloads and returns quotes within the last 1 year for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 1 year for the company matching the <paramref name="tickerSymbol"/>.</returns>
        public IEnumerable<EXQuote> DownloadQuotesOneYear(string tickerSymbol)
        {
            return DownloadQuotesInRange(tickerSymbol, "1y");
        }

        /// <summary>
        /// Downloads and returns quotes within the last 2 years for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 2 years for the company matching the <paramref name="tickerSymbol"/>.</returns>
        public IEnumerable<EXQuote> DownloadQuotesTwoYears(string tickerSymbol)
        {
            return DownloadQuotesInRange(tickerSymbol, "2y");
        }

        /// <summary>
        /// Downloads and returns quotes within the last 5 years for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 5 years for the company matching the <paramref name="tickerSymbol"/>.</returns>
        public IEnumerable<EXQuote> DownloadQuotesFiveYears(string tickerSymbol)
        {
            return DownloadQuotesInRange(tickerSymbol, "5y");
        }

        /// <summary>
        /// Downloads and returns quotes within the <paramref name="quoteRange"/> for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <param name="quoteRange">The range of time (5d, 1m, 1y, etc..) to download stock quotes for.</param>
        /// <returns>Returns historical quotes within the <paramref name="quoteRange"/> for the company matching the <paramref name="tickerSymbol"/>.</returns>
        private IEnumerable<EXQuote> DownloadQuotesInRange(string tickerSymbol, string quoteRange)
        {
            if (_isDisposed)
                throw new ObjectDisposedException("EXCloudWrapper", "The wrapper has been disposed.");

            var url = $"{_baseUrl}/stock/{tickerSymbol}/chart/{quoteRange}?token={_token}";

            return url.GetJsonFromUrl().FromJson<IList<EXQuote>>();
        }
    }
}
