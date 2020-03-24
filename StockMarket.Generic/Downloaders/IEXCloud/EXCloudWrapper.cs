using AutoMapper;
using Newtonsoft.Json;
using StockMarket.DataModel;
using StockMarket.Generic.Downloaders.IEXCloud.JSON_Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace StockMarket.Generic.Downloaders.IEXCloud
{
    public interface IEXCloudWrapper : IMarketDownloader<Company, Quote>, IDisposable
    {

    }

    [ExcludeFromCodeCoverage]
    public class EXCloudWrapper : IEXCloudWrapper
    {
        //private const string _baseUrl = "https://cloud.iexapis.com/stable";
        private const string _baseUrl = "https://sandbox.iexapis.com/stable";
        private string _token;
        private bool _isDisposed = false;
        private readonly IMapper _mapper;

        public EXCloudWrapper(string token)
        {
            _token = token;

            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EXCompany, Company>().ForMember(dest => dest.NumEmployees, opt => opt.MapFrom(src => src.Employees))
                                                   .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => string.Join(",", src.Tags)));
                cfg.CreateMap<EXDayQuote, Quote>().ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.QuoteTypeId))
                                                  .ForMember(dest => dest.IsValid, opt => opt.MapFrom(src => true));
                cfg.CreateMap<EXIntradayQuote, Quote>().ForMember(dest => dest.TypeId, opt => opt.MapFrom(src => src.QuoteTypeId))
                                                       .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.Add(TimeSpan.Parse(src.Minute))))
                                                       .ForMember(dest => dest.IsValid, opt => opt.MapFrom(src => src.High == null || src.Low == null || src.Open == null || src.Close == null ? false : true));
            }).CreateMapper();
        }

        #region ICompanyDownloader<Company>

        /// <summary>
        /// Downloads all company details for the given <paramref name="tickerSymbol"/>. The results are deserialized and converted to a useable model.
        /// </summary>
        /// <param name="tickerSymbol">The symbol of the company to download details for.</param>
        /// <returns>Returns company details for the supplied <paramref name="tickerSymbol"/>.</returns>
        Company ICompanyDownloader<Company>.DownloadCompanyDetails(string tickerSymbol)
        {
            return _mapper.Map<EXCompany, Company>(DownloadCompanyDetails(tickerSymbol));
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
            return _mapper.Map<EXDayQuote, Quote>(DownloadPreviousDayQuote(tickerSymbol));
        }

        /// <summary>
        /// Downloads and returns quotes within the last 5 days for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 5 days for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Quote> IQuoteDownloader<Quote>.DownloadQuotesFiveDays(string tickerSymbol)
        {
            return _mapper.Map<IEnumerable<EXDayQuote>, IEnumerable<Quote>>(DownloadDayQuotesFiveDays(tickerSymbol));
        }

        /// <summary>
        /// Downloads and returns quotes within the last 1 month for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 1 month for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Quote> IQuoteDownloader<Quote>.DownloadQuotesOneMonth(string tickerSymbol)
        {
            return _mapper.Map<IEnumerable<EXDayQuote>, IEnumerable<Quote>>(DownloadDayQuotesOneMonth(tickerSymbol));
        }

        /// <summary>
        /// Downloads and returns quotes within the last 3 months for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 3 month for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Quote> IQuoteDownloader<Quote>.DownloadQuotesThreeMonths(string tickerSymbol)
        {
            return _mapper.Map<IEnumerable<EXDayQuote>, IEnumerable<Quote>>(DownloadDayQuotesThreeMonths(tickerSymbol));
        }

        /// <summary>
        /// Downloads and returns quotes within the last 5 months for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 5 month for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Quote> IQuoteDownloader<Quote>.DownloadQuotesFiveMonths(string tickerSymbol)
        {
            return _mapper.Map<IEnumerable<EXDayQuote>, IEnumerable<Quote>>(DownloadDayQuotesFiveMonths(tickerSymbol));
        }

        /// <summary>
        /// Downloads and returns quotes within the last 1 year for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 1 year for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Quote> IQuoteDownloader<Quote>.DownloadQuotesOneYear(string tickerSymbol)
        {
            return _mapper.Map<IEnumerable<EXDayQuote>, IEnumerable<Quote>>(DownloadDayQuotesOneYear(tickerSymbol));
        }

        /// <summary>
        /// Downloads and returns quotes within the last 2 years for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 2 years for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Quote> IQuoteDownloader<Quote>.DownloadQuotesTwoYears(string tickerSymbol)
        {
            return _mapper.Map<IEnumerable<EXDayQuote>, IEnumerable<Quote>>(DownloadDayQuotesTwoYears(tickerSymbol));
        }

        /// <summary>
        /// Downloads and returns quotes within the last 5 years for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 5 years for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Quote> IQuoteDownloader<Quote>.DownloadQuotesFiveYears(string tickerSymbol)
        {
            return _mapper.Map<IEnumerable<EXDayQuote>, IEnumerable<Quote>>(DownloadDayQuotesFiveYears(tickerSymbol));
        }

        /// <summary>
        /// Downloads and returns intraday minute quotes for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns intraday minute quotes for the company matching the <paramref name="tickerSymbol"/>.</returns>
        IEnumerable<Quote> IQuoteDownloader<Quote>.DownloadIntradayMinuteQuotes(string tickerSymbol)
        {
            return _mapper.Map<IEnumerable<EXIntradayQuote>, IEnumerable<Quote>>(DownloadIntradayMinuteQuotes(tickerSymbol));
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

            return GetJsonFromUrl<EXCompany>(url);
        }

        /// <summary>
        /// Downloads and returns the last known quote for the given <paramref name="tickerSymbol"/>.
        /// Note: This will not return the current day's quote until 4:00am the following day.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quote for.</param>
        /// <returns>Returns the last known quote for the given <paramref name="tickerSymbol"/>.</returns>
        public EXDayQuote DownloadPreviousDayQuote(string tickerSymbol)
        {
            if (_isDisposed)
                throw new ObjectDisposedException("EXCloudWrapper", "The wrapper has been disposed.");

            var url = $"{_baseUrl}/stock/{tickerSymbol}/previous?token={_token}";

            return GetJsonFromUrl<EXDayQuote>(url);
        }

        /// <summary>
        /// Downloads and returns quotes within the last 5 days for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 5 days for the company matching the <paramref name="tickerSymbol"/>.</returns>
        public IEnumerable<EXDayQuote> DownloadDayQuotesFiveDays(string tickerSymbol)
        {
            return DownloadDayQuotesInRange(tickerSymbol, "5d");
        }

        /// <summary>
        /// Downloads and returns quotes within the last 1 month for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 1 month for the company matching the <paramref name="tickerSymbol"/>.</returns>
        public IEnumerable<EXDayQuote> DownloadDayQuotesOneMonth(string tickerSymbol)
        {
            return DownloadDayQuotesInRange(tickerSymbol, "1m");
        }

        /// <summary>
        /// Downloads and returns quotes within the last 3 months for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 3 month for the company matching the <paramref name="tickerSymbol"/>.</returns>
        public IEnumerable<EXDayQuote> DownloadDayQuotesThreeMonths(string tickerSymbol)
        {
            return DownloadDayQuotesInRange(tickerSymbol, "3m");
        }

        /// <summary>
        /// Downloads and returns quotes within the last 5 months for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 5 month for the company matching the <paramref name="tickerSymbol"/>.</returns>
        public IEnumerable<EXDayQuote> DownloadDayQuotesFiveMonths(string tickerSymbol)
        {
            return DownloadDayQuotesInRange(tickerSymbol, "5m");
        }

        /// <summary>
        /// Downloads and returns quotes within the last 1 year for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 1 year for the company matching the <paramref name="tickerSymbol"/>.</returns>
        public IEnumerable<EXDayQuote> DownloadDayQuotesOneYear(string tickerSymbol)
        {
            return DownloadDayQuotesInRange(tickerSymbol, "1y");
        }

        /// <summary>
        /// Downloads and returns quotes within the last 2 years for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 2 years for the company matching the <paramref name="tickerSymbol"/>.</returns>
        public IEnumerable<EXDayQuote> DownloadDayQuotesTwoYears(string tickerSymbol)
        {
            return DownloadDayQuotesInRange(tickerSymbol, "2y");
        }

        /// <summary>
        /// Downloads and returns quotes within the last 5 years for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns historical quotes within the last 5 years for the company matching the <paramref name="tickerSymbol"/>.</returns>
        public IEnumerable<EXDayQuote> DownloadDayQuotesFiveYears(string tickerSymbol)
        {
            return DownloadDayQuotesInRange(tickerSymbol, "5y");
        }

        /// <summary>
        /// Downloads and returns the intraday minute quotes (either today or yesterday depending on the current time of the day) for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <returns>Returns minute quotes for the company matching the <paramref name="tickerSymbol"/>.</returns>
        public IEnumerable<EXIntradayQuote> DownloadIntradayMinuteQuotes(string tickerSymbol)
        {
            if (_isDisposed)
                throw new ObjectDisposedException("EXCloudWrapper", "The wrapper has been disposed.");

            var url = $"{_baseUrl}/stock/{tickerSymbol}/intraday-prices?token={_token}";

            return GetJsonFromUrl<IEnumerable<EXIntradayQuote>>(url);
        }

        /// <summary>
        /// Downloads and returns quotes within the <paramref name="quoteRange"/> for the company matching the <paramref name="tickerSymbol"/>.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol of the company to download the quotes for.</param>
        /// <param name="quoteRange">The range of time (5d, 1m, 1y, etc..) to download stock quotes for.</param>
        /// <returns>Returns historical quotes within the <paramref name="quoteRange"/> for the company matching the <paramref name="tickerSymbol"/>.</returns>
        private IEnumerable<EXDayQuote> DownloadDayQuotesInRange(string tickerSymbol, string quoteRange)
        {
            if (_isDisposed)
                throw new ObjectDisposedException("EXCloudWrapper", "The wrapper has been disposed.");

            var url = $"{_baseUrl}/stock/{tickerSymbol}/chart/{quoteRange}?token={_token}";

            return GetJsonFromUrl<IEnumerable<EXDayQuote>>(url);
        }
        
        /// <summary>
        /// Converts and returns the response Json object from the url provided. 
        /// </summary>
        /// <typeparam name="T">The generic type of object to return.</typeparam>
        /// <param name="url">The url of the json string.</param>
        /// <returns>Returns the converted Json object from the url.</returns>
        private T GetJsonFromUrl<T>(string url)
        {
            using (var client = new WebClient())
            {
                var jsonResponse = client.DownloadString(url);

                return JsonConvert.DeserializeObject<T>(jsonResponse);
            }
        }
    }
}
