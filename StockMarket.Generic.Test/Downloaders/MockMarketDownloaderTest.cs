using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockMarket.Generic.Downloaders;
using StockMarket.Generic.Test.Builders;
using StockMarket.DataModel.Test.Builders;
using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using StockMarket.DataModel.Test.Builders.Objects;

namespace StockMarket.Generic.Test.Downloaders
{

    /// <summary>
    /// Tests of mock interface provided because minimal verification is needed to test the mock methods are
    /// returning properly.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class MockMarketDownloaderTest
    {
        private MockMarketDownloader _mockDownloader;
        private IMarketDownloader<TestCompany, TestQuote> _downloader;
        private TestCompany _fakeCompany;

        [TestInitialize]
        public void Initialize()
        {
            _mockDownloader = new MockMarketDownloader();
            _downloader = _mockDownloader.Object;
            _fakeCompany = FakeCompaniesBuilder.CreateFakeCompanyAAPL();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _downloader = null;
        }

        #region Testing MockMarketDownloader SetupDownloadCompanyDetails()

        [TestMethod]
        public void DownloadCompanyDetails_WithValidSymbol_ReturnsFakeCompany()
        {
            // Arrange
            var fakeCompany = FakeCompaniesBuilder.CreateFakeCompanyAAPL();

            // Act
            var downloadedCompany = _downloader.DownloadCompanyDetails("AAPL");

            // Assert
            Assert.IsNotNull(downloadedCompany);
            Assert.IsTrue(downloadedCompany.Id == fakeCompany.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void DownloadCompanyDetails_WithInvalidSymbol_ThrowsException()
        {
            // Act
            var downloadedCompany = _downloader.DownloadCompanyDetails("ZZAA");
        }

        #endregion
        #region Testing MockMarketDownloader SetupDownloadPreviousDayQuote()

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void DownloadPreviousDayQuote_WithInvalidSymbol_ThrowsException()
        {
            // Act
            _downloader.DownloadPreviousDayQuote(null);
        }

        [TestMethod]
        public void DownloadPreviousDayQuote_ReturnsYesterdaysQuote()
        {
            // Act
            var downloadedQuote = _downloader.DownloadPreviousDayQuote(_fakeCompany.Symbol);

            // Assert
            Assert.IsNotNull(downloadedQuote);
            Assert.IsTrue(downloadedQuote.Id == 1);
        }

        #endregion
        #region Testing MockMarketDownloader SetupDownloadQuotesFiveDays()

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void DownloadQuotesFiveDays_WithInvalidSymbol_ThrowsException()
        {
            // Act
            _downloader.DownloadQuotesFiveDays(null);
        }

        [TestMethod]
        public void DownloadQuotesFiveDays_ReturnsQuotes()
        {
            // Act
            var downloadedQuotes = _downloader.DownloadQuotesFiveDays(_fakeCompany.Symbol);

            // Assert
            Assert.IsNotNull(downloadedQuotes);
            Assert.IsTrue(downloadedQuotes.Count() == 5);
            Assert.IsTrue(downloadedQuotes.FirstOrDefault()?.Id == 1);
            Assert.IsTrue(downloadedQuotes.LastOrDefault()?.Id == 5);
        }

        #endregion
        #region Testing MockMarketDownloader SetupDownloadQuotesOneMonth()

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void DownloadQuotesOneMonth_WithInvalidSymbol_ThrowsException()
        {
            // Act
            _downloader.DownloadQuotesOneMonth(null);
        }

        [TestMethod]
        public void DownloadQuotesOneMonth_ReturnsQuotes()
        {
            // Act
            var downloadedQuotes = _downloader.DownloadQuotesOneMonth(_fakeCompany.Symbol);

            // Assert
            Assert.IsNotNull(downloadedQuotes);
            Assert.IsTrue(downloadedQuotes.Count() == (int)(DateTime.Now - DateTime.Now.AddMonths(-1)).TotalDays);
            Assert.IsTrue(downloadedQuotes.FirstOrDefault()?.Id == 1);
            Assert.IsTrue(downloadedQuotes.LastOrDefault()?.Id == (int)(DateTime.Now - DateTime.Now.AddMonths(-1)).TotalDays);
        }

        #endregion
        #region Testing MockMarketDownloader SetupDownloadQuotesThreeMonths()

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void DownloadQuotesThreeMonths_WithInvalidSymbol_ThrowsException()
        {
            // Act
            _downloader.DownloadQuotesThreeMonths(null);
        }

        [TestMethod]
        public void DownloadQuotesThreeMonths_ReturnsQuotes()
        {
            // Act
            var downloadedQuotes = _downloader.DownloadQuotesThreeMonths(_fakeCompany.Symbol);

            // Assert
            Assert.IsNotNull(downloadedQuotes);
            Assert.IsTrue(downloadedQuotes.Count() == (int)(DateTime.Now - DateTime.Now.AddMonths(-3)).TotalDays);
            Assert.IsTrue(downloadedQuotes.FirstOrDefault()?.Id == 1);
            Assert.IsTrue(downloadedQuotes.LastOrDefault()?.Id == (int)(DateTime.Now - DateTime.Now.AddMonths(-3)).TotalDays);
        }

        #endregion
        #region Testing MockMarketDownloader SetupDownloadQuotesFiveMonths()

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void DownloadQuotesFiveMonths_WithInvalidSymbol_ThrowsException()
        {
            // Act
            _downloader.DownloadQuotesFiveMonths(null);
        }

        [TestMethod]
        public void DownloadQuotesFiveMonths_ReturnsQuotes()
        {
            // Act
            var downloadedQuotes = _downloader.DownloadQuotesFiveMonths(_fakeCompany.Symbol);

            // Assert
            Assert.IsNotNull(downloadedQuotes);
            Assert.IsTrue(downloadedQuotes.Count() == (int)(DateTime.Now - DateTime.Now.AddMonths(-5)).TotalDays);
            Assert.IsTrue(downloadedQuotes.FirstOrDefault()?.Id == 1);
            Assert.IsTrue(downloadedQuotes.LastOrDefault()?.Id == (int)(DateTime.Now - DateTime.Now.AddMonths(-5)).TotalDays);
        }

        #endregion
        #region Testing MockMarketDownloader SetupDownloadQuotesOneYear()

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void DownloadQuotesOneYear_WithInvalidSymbol_ThrowsException()
        {
            // Act
            _downloader.DownloadQuotesOneYear(null);
        }

        [TestMethod]
        public void DownloadQuotesOneYear_ReturnsQuotes()
        {
            // Act
            var downloadedQuotes = _downloader.DownloadQuotesOneYear(_fakeCompany.Symbol);

            // Assert
            Assert.IsNotNull(downloadedQuotes);
            Assert.IsTrue(downloadedQuotes.Count() == (int)(DateTime.Now - DateTime.Now.AddYears(-1)).TotalDays);
            Assert.IsTrue(downloadedQuotes.FirstOrDefault()?.Id == 1);
            Assert.IsTrue(downloadedQuotes.LastOrDefault()?.Id == (int)(DateTime.Now - DateTime.Now.AddYears(-1)).TotalDays);
        }

        #endregion
        #region Testing MockMarketDownloader SetupDownloadQuotesTwoYears()

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void DownloadQuotesTwoYears_WithInvalidSymbol_ThrowsException()
        {
            // Act
            _downloader.DownloadQuotesTwoYears(null);
        }

        [TestMethod]
        public void DownloadQuotesTwoYears_ReturnsQuotes()
        {
            // Act
            var downloadedQuotes = _downloader.DownloadQuotesTwoYears(_fakeCompany.Symbol);

            // Assert
            Assert.IsNotNull(downloadedQuotes);
            Assert.IsTrue(downloadedQuotes.Count() == (int)(DateTime.Now - DateTime.Now.AddYears(-2)).TotalDays);
            Assert.IsTrue(downloadedQuotes.FirstOrDefault()?.Id == 1);
            Assert.IsTrue(downloadedQuotes.LastOrDefault()?.Id == (int)(DateTime.Now - DateTime.Now.AddYears(-2)).TotalDays);
        }

        #endregion
        #region Testing MockMarketDownloader SetupDownloadQuotesFiveYears()

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void DownloadQuotesFiveYears_WithInvalidSymbol_ThrowsException()
        {
            // Act
            _downloader.DownloadQuotesFiveYears(null);
        }

        [TestMethod]
        public void DownloadQuotesFiveYears_ReturnsQuotes()
        {
            // Act
            var downloadedQuotes = _downloader.DownloadQuotesFiveYears(_fakeCompany.Symbol);

            // Assert
            Assert.IsNotNull(downloadedQuotes);
            Assert.IsTrue(downloadedQuotes.Count() == (int)(DateTime.Now.Date - DateTime.Now.AddYears(-5).Date).TotalDays);
            Assert.IsTrue(downloadedQuotes.FirstOrDefault()?.Id == 1);
            Assert.IsTrue(downloadedQuotes.LastOrDefault()?.Id == (int)(DateTime.Now.Date - DateTime.Now.AddYears(-5).Date).TotalDays);
        }

        #endregion
        #region Testing MockMarketDownloader SetupDispose()

        [TestMethod]
        public void Dispose_UpdatesProperty()
        {
            // Act
            _downloader.Dispose();

            // Assert
            Assert.IsTrue(_mockDownloader.IsDisposed);
        }

        #endregion
    }
}
