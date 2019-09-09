
using StockMarket.DataModel.Test.Builders.Objects;

namespace StockMarket.DataModel.Test.Builders
{
    public static class FakeCompaniesBuilder
    {
        // PLEASE NOTE: In order for the market downloader to work, remember to add each
        // company to the MockMarketDownloader class in StockMarket.Generic.Test.Builders

        public static TestCompany CreateFakeCompanyAAPL()
        {
            return new TestCompany()
            {
                Id = 111,
                Symbol = "AAPL",
                CompanyName = "Apple Inc.",
                Exchange = "NASDAQ",
                Industry = "Telecommunications Equipment..",
                Website = "https://www.apple.com",
                Description = "Apple, Inc. gengages in the ...",
                CEO = "Tim Cook",
                SecurityName = "Apple Inc.",
                IssueType = "cs",
                Sector = "Electronic Technology",
                NumEmployees = 132000,
                Tags = "AAPL, Apple Inc..."
            };
        }

        public static TestCompany CreateFakeCompanyGPRO()
        {
            return new TestCompany()
            {
                Id = 222,
                Symbol = "GPRO",
                CompanyName = "GoPro",
                Exchange = "NASDAQ",
                Industry = "Telecommunications Equipment..",
                Website = "https://www.gopro.com",
                Description = "GoPro gengages in the ...",
                CEO = "Tim Cook",
                SecurityName = "GoPro",
                IssueType = "cs",
                Sector = "Electronic Technology",
                NumEmployees = 112233,
                Tags = "GPRO, GoPro..."
            };
        }

        public static TestCompany CreateFakeCompanyGOOGIncomplete()
        {
            return new TestCompany()
            {
                Id = 333,
                Symbol = "GOOG"
            };
        }

        public static TestCompany CreateFakeCompanyGOOG()
        {
            return new TestCompany()
            {
                Id = 333,
                Symbol = "GOOG",
                CompanyName = "Google",
                Exchange = "NASDAQ",
                Industry = "Telecommunications Equipment..",
                Website = "https://www.google.com",
                Description = "Google gengages in the ...",
                CEO = "Tim Cook",
                SecurityName = "Google",
                IssueType = "cs",
                Sector = "Electronic Technology",
                NumEmployees = 132000,
                Tags = "GOOG, Alphabet..."
            };
        }

        public static TestCompany CreateFakeCompanyAMZNIncomplete()
        {
            return new TestCompany()
            {
                Id = 444,
                Symbol = "AMZN"
            };
        }

        public static TestCompany CreateFakeCompanyAMZN()
        {
            return new TestCompany()
            {
                Id = 444,
                Symbol = "AMZN",
                CompanyName = "Amazon",
                Exchange = "NASDAQ",
                Industry = "Telecommunications Equipment..",
                Website = "https://www.amazon.com",
                Description = "Amazon gengages in the ...",
                CEO = "Tim Cook",
                SecurityName = "Amazon",
                IssueType = "cs",
                Sector = "Electronic Technology",
                NumEmployees = 132000,
                Tags = "Amazon, AMZN..."
            };
        }
    }
}
