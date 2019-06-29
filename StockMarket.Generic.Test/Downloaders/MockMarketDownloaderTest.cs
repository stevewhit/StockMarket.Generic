using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockMarket.Generic.Downloaders;
using StockMarket.Generic.Test.Builders;
using StockMarket.DataModel.Test.Builders;
using System;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

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

        [TestInitialize]
        public void Initialize()
        {
            _mockDownloader = new MockMarketDownloader();
            _downloader = _mockDownloader.Object;
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
        public void DownloadPreviousDayQuote_ReturnsYesterdaysQuote()
        {
            // Act
            var downloadedQuote = _downloader.DownloadPreviousDayQuote(null);

            // Assert
            Assert.IsNotNull(downloadedQuote);
            Assert.IsTrue(downloadedQuote.Id == 1);
        }

        #endregion
        #region Testing MockMarketDownloader SetupDownloadQuotesFiveDays()

        [TestMethod]
        public void DownloadQuotesFiveDays_ReturnsQuotes()
        {
            // Act
            var downloadedQuotes = _downloader.DownloadQuotesFiveDays(null);

            // Assert
            Assert.IsNotNull(downloadedQuotes);
            Assert.IsTrue(downloadedQuotes.Count() == 5);
            Assert.IsTrue(downloadedQuotes.FirstOrDefault()?.Id == 1);
            Assert.IsTrue(downloadedQuotes.LastOrDefault()?.Id == 5);
        }

        #endregion
        #region Testing MockMarketDownloader SetupDownloadQuotesOneMonth()

        [TestMethod]
        public void DownloadQuotesOneMonth_ReturnsQuotes()
        {
            // Act
            var downloadedQuotes = _downloader.DownloadQuotesOneMonth(null);

            // Assert
            Assert.IsNotNull(downloadedQuotes);
            Assert.IsTrue(downloadedQuotes.Count() == (int)(DateTime.Now - DateTime.Now.AddMonths(-1)).TotalDays);
            Assert.IsTrue(downloadedQuotes.FirstOrDefault()?.Id == 1);
            Assert.IsTrue(downloadedQuotes.LastOrDefault()?.Id == (int)(DateTime.Now - DateTime.Now.AddMonths(-1)).TotalDays);
        }

        #endregion
        #region Testing MockMarketDownloader SetupDownloadQuotesThreeMonths()

        [TestMethod]
        public void DownloadQuotesThreeMonths_ReturnsQuotes()
        {
            // Act
            var downloadedQuotes = _downloader.DownloadQuotesThreeMonths(null);

            // Assert
            Assert.IsNotNull(downloadedQuotes);
            Assert.IsTrue(downloadedQuotes.Count() == (int)(DateTime.Now - DateTime.Now.AddMonths(-3)).TotalDays);
            Assert.IsTrue(downloadedQuotes.FirstOrDefault()?.Id == 1);
            Assert.IsTrue(downloadedQuotes.LastOrDefault()?.Id == (int)(DateTime.Now - DateTime.Now.AddMonths(-3)).TotalDays);
        }

        #endregion
        #region Testing MockMarketDownloader SetupDownloadQuotesFiveMonths()

        [TestMethod]
        public void DownloadQuotesFiveMonths_ReturnsQuotes()
        {
            // Act
            var downloadedQuotes = _downloader.DownloadQuotesFiveMonths(null);

            // Assert
            Assert.IsNotNull(downloadedQuotes);
            Assert.IsTrue(downloadedQuotes.Count() == (int)(DateTime.Now - DateTime.Now.AddMonths(-5)).TotalDays);
            Assert.IsTrue(downloadedQuotes.FirstOrDefault()?.Id == 1);
            Assert.IsTrue(downloadedQuotes.LastOrDefault()?.Id == (int)(DateTime.Now - DateTime.Now.AddMonths(-5)).TotalDays);
        }

        #endregion
        #region Testing MockMarketDownloader SetupDownloadQuotesOneYear()

        [TestMethod]
        public void DownloadQuotesOneYear_ReturnsQuotes()
        {
            // Act
            var downloadedQuotes = _downloader.DownloadQuotesOneYear(null);

            // Assert
            Assert.IsNotNull(downloadedQuotes);
            Assert.IsTrue(downloadedQuotes.Count() == (int)(DateTime.Now - DateTime.Now.AddYears(-1)).TotalDays);
            Assert.IsTrue(downloadedQuotes.FirstOrDefault()?.Id == 1);
            Assert.IsTrue(downloadedQuotes.LastOrDefault()?.Id == (int)(DateTime.Now - DateTime.Now.AddYears(-1)).TotalDays);
        }

        #endregion
        #region Testing MockMarketDownloader SetupDownloadQuotesTwoYears()

        [TestMethod]
        public void DownloadQuotesTwoYears_ReturnsQuotes()
        {
            // Act
            var downloadedQuotes = _downloader.DownloadQuotesTwoYears(null);

            // Assert
            Assert.IsNotNull(downloadedQuotes);
            Assert.IsTrue(downloadedQuotes.Count() == (int)(DateTime.Now - DateTime.Now.AddYears(-2)).TotalDays);
            Assert.IsTrue(downloadedQuotes.FirstOrDefault()?.Id == 1);
            Assert.IsTrue(downloadedQuotes.LastOrDefault()?.Id == (int)(DateTime.Now - DateTime.Now.AddYears(-2)).TotalDays);
        }

        #endregion
        #region Testing MockMarketDownloader SetupDownloadQuotesFiveYears()

        [TestMethod]
        public void DownloadQuotesFiveYears_ReturnsQuotes()
        {
            // Act
            var downloadedQuotes = _downloader.DownloadQuotesFiveYears(null);

            // Assert
            Assert.IsNotNull(downloadedQuotes);
            Assert.IsTrue(downloadedQuotes.Count() == (int)(DateTime.Now - DateTime.Now.AddYears(-5)).TotalDays);
            Assert.IsTrue(downloadedQuotes.FirstOrDefault()?.Id == 1);
            Assert.IsTrue(downloadedQuotes.LastOrDefault()?.Id == (int)(DateTime.Now - DateTime.Now.AddYears(-5)).TotalDays);
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
