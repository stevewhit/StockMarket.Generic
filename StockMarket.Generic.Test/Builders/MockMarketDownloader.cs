using Moq;
using System;
using StockMarket.Generic.Downloaders;
using StockMarket.DataModel.Test.Builders;
using System.Linq;
using StockMarket.DataModel.Test.Builders.Objects;
using Framework.Generic.Utility;
using System.Diagnostics.CodeAnalysis;

namespace StockMarket.Generic.Test.Builders
{
    [ExcludeFromCodeCoverage]
    public class MockMarketDownloader : Mock<IMarketDownloader<TestCompany, TestQuote>>
    {
        public bool IsDisposed { get; private set; } = false;

        public MockMarketDownloader()
        {
            // Setup all mock methods.
            SetupDownloadCompanyDetails().SetupDownloadPreviousDayQuote().SetupDownloadQuotesFiveDays().SetupDownloadQuotesOneMonth().SetupDownloadQuotesOneMonth().SetupDownloadQuotesThreeMonths().SetupDownloadQuotesFiveMonths().SetupDownloadQuotesOneYear().SetupDownloadQuotesTwoYears().SetupDownloadQuotesFiveYears().SetupDownloadIntradayMinuteQuotes().SetupDispose();
        }

        private TestCompany GetSupportedCompany(string tickerSymbol)
        {
            switch (tickerSymbol)
            {
                case "AAPL":
                    return FakeCompaniesBuilder.CreateFakeCompanyAAPL();
                case "GPRO":
                    return FakeCompaniesBuilder.CreateFakeCompanyGPRO();
                case "AMZN":
                    return FakeCompaniesBuilder.CreateFakeCompanyAMZN();
                case "GOOG":
                    return FakeCompaniesBuilder.CreateFakeCompanyGOOG();
                default:
                    throw new NotImplementedException("No fake data exists yet for this company.");
            }
        }

        public MockMarketDownloader SetupDownloadCompanyDetails()
        {
            Setup(w => w.DownloadCompanyDetails(It.IsAny<string>()))
                .Returns((string tickerSymbol) =>
                {
                    return GetSupportedCompany(tickerSymbol);
                });

            return this;
        }

        public MockMarketDownloader SetupDownloadPreviousDayQuote()
        {
            Setup(w => w.DownloadPreviousDayQuote(It.IsAny<string>()))
                .Returns((string tickerSymbol) =>
                {
                    var validCompany = GetSupportedCompany(tickerSymbol);
                    return FakeQuotesBuilder.CreateFakeDayQuotes(null, 1).FirstOrDefault();
                });

            return this;
        }

        public MockMarketDownloader SetupDownloadQuotesFiveDays()
        {
            Setup(w => w.DownloadQuotesFiveDays(It.IsAny<string>()))
                .Returns((string tickerSymbol) =>
                {
                    var validCompany = GetSupportedCompany(tickerSymbol);
                    return FakeQuotesBuilder.CreateFakeDayQuotes(null, 5);
                });

            return this;
        }

        public MockMarketDownloader SetupDownloadQuotesOneMonth()
        {
            Setup(w => w.DownloadQuotesOneMonth(It.IsAny<string>()))
                .Returns((string tickerSymbol) =>
                {
                    var validCompany = GetSupportedCompany(tickerSymbol);
                    return FakeQuotesBuilder.CreateFakeDayQuotes(null, (int)(SystemTime.Now() - SystemTime.Now().AddMonths(-1)).TotalDays);
                });

            return this;
        }

        public MockMarketDownloader SetupDownloadQuotesThreeMonths()
        {
            Setup(w => w.DownloadQuotesThreeMonths(It.IsAny<string>()))
                .Returns((string tickerSymbol) =>
                {
                    var validCompany = GetSupportedCompany(tickerSymbol);
                    return FakeQuotesBuilder.CreateFakeDayQuotes(null, (int)(SystemTime.Now() - SystemTime.Now().AddMonths(-3)).TotalDays);
                });

            return this;
        }

        public MockMarketDownloader SetupDownloadQuotesFiveMonths()
        {
            Setup(w => w.DownloadQuotesFiveMonths(It.IsAny<string>()))
                .Returns((string tickerSymbol) =>
                {
                    var validCompany = GetSupportedCompany(tickerSymbol);
                    return FakeQuotesBuilder.CreateFakeDayQuotes(null, (int)(SystemTime.Now() - SystemTime.Now().AddMonths(-5)).TotalDays);
                });

            return this;
        }

        public MockMarketDownloader SetupDownloadQuotesOneYear()
        {
            Setup(w => w.DownloadQuotesOneYear(It.IsAny<string>()))
                .Returns((string tickerSymbol) =>
                {
                    var validCompany = GetSupportedCompany(tickerSymbol);
                    return FakeQuotesBuilder.CreateFakeDayQuotes(null, (int)(SystemTime.Now() - SystemTime.Now().AddYears(-1)).TotalDays);
                });

            return this;
        }

        public MockMarketDownloader SetupDownloadQuotesTwoYears()
        {
            Setup(w => w.DownloadQuotesTwoYears(It.IsAny<string>()))
                .Returns((string tickerSymbol) =>
                {
                    var validCompany = GetSupportedCompany(tickerSymbol);
                    return FakeQuotesBuilder.CreateFakeDayQuotes(null, (int)(SystemTime.Now() - SystemTime.Now().AddYears(-2)).TotalDays);
                });

            return this;
        }

        public MockMarketDownloader SetupDownloadQuotesFiveYears()
        {
            Setup(w => w.DownloadQuotesFiveYears(It.IsAny<string>()))
                .Returns((string tickerSymbol) =>
                {
                    var validCompany = GetSupportedCompany(tickerSymbol);
                    return FakeQuotesBuilder.CreateFakeDayQuotes(null, (int)(SystemTime.Now() - SystemTime.Now().AddYears(-5)).TotalDays);
                });

            return this;
        }

        public MockMarketDownloader SetupDownloadIntradayMinuteQuotes()
        {
            Setup(w => w.DownloadIntradayMinuteQuotes(It.IsAny<string>()))
                .Returns((string tickerSymbol) =>
                {
                    var validCompany = GetSupportedCompany(tickerSymbol);
                    return FakeQuotesBuilder.CreateFakeMinuteQuotes(null, SystemTime.Now().TimeOfDay);
                });

            return this;
        }

        public MockMarketDownloader SetupDispose()
        {
            Setup(c => c.Dispose())
                .Callback(() =>
                {
                    IsDisposed = true;
                });

            return this;
        }
    }
}
