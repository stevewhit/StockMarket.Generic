using StockMarket.DataModel;
using System;
using System.Collections.Generic;

namespace StockMarket.Generic.Downloaders
{
    public interface IQuoteDownloader<Q> : IDisposable where Q : Quote
    {
        /// <summary>
        /// Downloads and returns the last known quote for the given <paramref name="tickerSymbol"/>.
        /// Note: This will not return the current day's quote until 4:00am the following day.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quote for.</param>
        /// <returns>Returns the last known quote for the given <paramref name="tickerSymbol"/>.</returns>
        Q DownloadPreviousDayQuote(string tickerSymbol);

        /// <summary>
        /// Downloads and returns quotes within the last 5 days for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 5 days for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Q> DownloadQuotesFiveDays(string tickerSymbol);

        /// <summary>
        /// Downloads and returns quotes within the last 1 month for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 1 month for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Q> DownloadQuotesOneMonth(string tickerSymbol);

        /// <summary>
        /// Downloads and returns quotes within the last 3 months for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 3 month for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Q> DownloadQuotesThreeMonths(string tickerSymbol);

        /// <summary>
        /// Downloads and returns quotes within the last 5 months for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 5 month for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Q> DownloadQuotesFiveMonths(string tickerSymbol);

        /// <summary>
        /// Downloads and returns quotes within the last 1 year for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 1 year for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Q> DownloadQuotesOneYear(string tickerSymbol);

        /// <summary>
        /// Downloads and returns quotes within the last 2 years for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 2 years for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Q> DownloadQuotesTwoYears(string tickerSymbol);

        /// <summary>
        /// Downloads and returns quotes within the last 5 years for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 5 years for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Q> DownloadQuotesFiveYears(string tickerSymbol);
    }
}
