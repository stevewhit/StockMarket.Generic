using Framework.Generic.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace StockMarket.DataModel.Test.Builders
{
    [ExcludeFromCodeCoverage]
    public static class FakeQuotesBuilder
    {
        public static IEnumerable<TestQuote> CreateFakeQuotes(TestCompany company, int numDays, int numDaysSkipped)
        {
            for (int i = numDaysSkipped+1; i <= numDays+numDaysSkipped; i++)
            {
                yield return new TestQuote()
                {
                    Id = i,
                    Company = company,
                    CompanyId = company?.Id ?? 0,
                    Date = DateTime.Now.AddDays((-1 * i)).Date,
                    Close = NumberUtils.GenerateRandomNumber(1, 200),
                    High = NumberUtils.GenerateRandomNumber(1, 200),
                    Low = NumberUtils.GenerateRandomNumber(1, 200),
                    Open = NumberUtils.GenerateRandomNumber(1, 200),
                    Volume = NumberUtils.GenerateRandomNumber(1, 1000000)
                };
            }
        }

        public static IEnumerable<TestQuote> CreateFakeQuotes(TestCompany company, int numDays)
        {
            return CreateFakeQuotes(company, numDays, 0);
        }
    }
}
