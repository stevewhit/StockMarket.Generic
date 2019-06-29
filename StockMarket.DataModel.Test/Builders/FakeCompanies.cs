
namespace StockMarket.DataModel.Test.Builders
{
    public static class FakeCompaniesBuilder
    {
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
    }
}
