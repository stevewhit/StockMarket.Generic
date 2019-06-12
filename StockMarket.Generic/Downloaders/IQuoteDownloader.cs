using StockMarket.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Generic.Downloaders
{
    public interface IQuoteDownloader<T> : IDisposable where T : Quote
    {
        /// <summary>
        /// Downloads all available daily End of Day (EOD) quotes for a given <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of a company.</param>
        /// <returns>Returns all available quotes for the identified company.</returns>
        IEnumerable<T> DownloadQuotes(string tickerSymbol);

        /// <summary>
        /// Downloads daily End of Day (EOD) quotes for a given <paramref name="tickerSymbol"/> between and including the provided <paramref name="startDate"/> and the current date.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of a company.</param>
        /// <param name="startDate">The starting date of when to grab quotes for.</param>
        /// <returns>Returns the quotes for the identified company between and including the <paramref name="startDate"/> and the current date.</returns>
        IEnumerable<T> DownloadQuotes(string tickerSymbol, DateTime startDate);

        /// <summary>
        /// Downloads daily End of Day (EOD) quotes for a given <paramref name="tickerSymbol"/> between and including the provided <paramref name="startDate"/> and <paramref name="endDate"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of a company.</param>
        /// <param name="startDate">The starting date of when to grab quotes for.</param>
        /// <param name="endDate">The ending date of when to grab quotes for.</param>
        /// <returns>Returns the quotes for the identified company between and including the <paramref name="startDate"/> and <paramref name="endDate"/>.</returns>
        IEnumerable<T> DownloadQuotes(string tickerSymbol, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Downloads all available daily End of Day (EOD) quotes for the provided company.
        /// </summary>
        /// <param name="companyId">The id of the company.</param>
        /// <returns>Returns all available quotes for the identified company.</returns>
        IEnumerable<T> DownloadQuotes(int companyId);

        /// <summary>
        /// Downloads all available daily End of Day (EOD) quotes for the provided company between and including the provided <paramref name="startDate"/> and the current date.
        /// </summary>
        /// <param name="companyId">The id of the company.</param>
        /// <param name="startDate">The starting date of when to grab quotes for.</param>
        /// <returns>Returns the quotes for the identified company between and including the <paramref name="startDate"/> and the current date.</returns>
        IEnumerable<T> DownloadQuotes(int companyId, DateTime startDate);

        /// <summary>
        /// Downloads all available daily End of Day (EOD) quotes for the provided company between and including the provided <paramref name="startDate"/> and <paramref name="endDate"/>.
        /// </summary>
        /// <param name="companyId">The id of the company.</param>
        /// <param name="startDate">The starting date of when to grab quotes for.</param>
        /// <param name="endDate">The ending date of when to grab quotes for.</param>
        /// <returns>Returns the quotes for the identified company between and including the <paramref name="startDate"/> and <paramref name="endDate"/>.</returns>
        IEnumerable<T> DownloadQuotes(int companyId, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Downloads all available daily End of Day (EOD) quotes for the provided company.
        /// </summary>
        /// <param name="company">The company to download quotes for.</param>
        /// <returns>Returns all available quotes for the identified company.</returns>
        IEnumerable<T> DownloadQuotes(Company company);

        /// <summary>
        /// Downloads all available daily End of Day (EOD) quotes for the provided company between and including the provided <paramref name="startDate"/> and the current date.
        /// </summary>
        /// <param name="company">The company to download quotes for.</param>
        /// <param name="startDate">The starting date of when to grab quotes for.</param>
        /// <returns>Returns the quotes for the identified company between and including the <paramref name="startDate"/> and the current date.</returns>
        IEnumerable<T> DownloadQuotes(Company company, DateTime startDate);

        /// <summary>
        /// Downloads all available daily End of Day (EOD) quotes for the provided company between and including the provided <paramref name="startDate"/> and <paramref name="endDate"/>.
        /// </summary>
        /// <param name="company">The company to download quotes for.</param>
        /// <param name="startDate">The starting date of when to grab quotes for.</param>
        /// <param name="endDate">The ending date of when to grab quotes for.</param>
        /// <returns>Returns the quotes for the identified company between and including the <paramref name="startDate"/> and <paramref name="endDate"/>.</returns>
        IEnumerable<T> DownloadQuotes(Company company, DateTime startDate, DateTime endDate);
    }
}
