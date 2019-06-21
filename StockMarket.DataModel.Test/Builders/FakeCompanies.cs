using QR.Business.Tests.Builders;

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
    }
}
