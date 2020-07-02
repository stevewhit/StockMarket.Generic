using Framework.Generic.Utility;
using StockMarket.DataModel.Test.Builders.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace StockMarket.DataModel.Test.Builders
{
    [ExcludeFromCodeCoverage]
    public static class FakeQuotesBuilder
    {
        public static bool CreatesValidQuotes { get; set; } = true;

        public static IEnumerable<TestQuote> CreateFakeDayQuotes(TestCompany company, int numDays, int numDaysSkipped)
        {
            for (int i = numDaysSkipped+1; i <= numDays+numDaysSkipped; i++)
            {
                yield return new TestQuote()
                {
                    Id = i,
                    Company = company,
                    CompanyId = company?.Id ?? 0,
                    Date = SystemTime.Now().AddDays((-1 * i)).Date,
                    Close = NumberUtils.GenerateRandomNumber(1, 200),
                    High = NumberUtils.GenerateRandomNumber(1, 200),
                    Low = NumberUtils.GenerateRandomNumber(1, 200),
                    Open = NumberUtils.GenerateRandomNumber(1, 200),
                    Volume = NumberUtils.GenerateRandomNumber(1, 1000000),
                    QuoteType = QuoteTypeEnum.Day,
                    TypeId = (int)QuoteTypeEnum.Day,
                    IsValid = CreatesValidQuotes
                };
            }
        }

        public static IEnumerable<TestQuote> CreateFakeDayQuotes(TestCompany company, int numDays)
        {
            return CreateFakeDayQuotes(company, numDays, 0);
        }
        
        public static IEnumerable<TestQuote> CreateFakeMinuteQuotes(TestCompany company, TimeSpan endTime)
        {
            var marketOpen = new TimeSpan(9, 30, 0);
            var marketClose = new TimeSpan(15, 59, 0);

            if (marketOpen >= endTime)
                yield break;

            for (int i = 0; i <= Math.Min((int)(endTime - marketOpen).TotalMinutes, (int)(marketClose - marketOpen).TotalMinutes); i++)
            {
                yield return new TestQuote()
                {
                    Id = i+1,
                    Company = company,
                    CompanyId = company?.Id ?? 0,
                    Date = SystemTime.Now().Date.Add(marketOpen.Add(new TimeSpan(0, i, 0))),
                    Close = NumberUtils.GenerateRandomNumber(1, 200),
                    High = NumberUtils.GenerateRandomNumber(1, 200),
                    Low = NumberUtils.GenerateRandomNumber(1, 200),
                    Open = NumberUtils.GenerateRandomNumber(1, 200),
                    Volume = NumberUtils.GenerateRandomNumber(1, 1000000),
                    QuoteType = QuoteTypeEnum.OneMinute,
                    TypeId = (int)QuoteTypeEnum.OneMinute,
                    IsValid = CreatesValidQuotes
                };
            }
        }
        
        public static IEnumerable<TestQuote> CreateFakeDayMinuteQuotes(TestCompany company, int numDaysSkipped, TimeSpan endTime)
        {
            SystemTime.SetDateTime(DateTime.Now.AddDays(-1 * numDaysSkipped));

            var dayQuotes = CreateFakeDayQuotes(null, 7);
            var minuteQuotes = CreateFakeMinuteQuotes(null, endTime);

            var quoteCounter = 1;
            foreach (var dayQuote in dayQuotes)
            {
                dayQuote.Id = quoteCounter++;
                dayQuote.Company = company;
                dayQuote.CompanyId = company.Id;
                yield return dayQuote;
            }
            foreach (var minQuote in minuteQuotes)
            {
                minQuote.Id = quoteCounter++;
                minQuote.Company = company;
                minQuote.CompanyId = company.Id;
                yield return minQuote;
            }

            SystemTime.ResetDateTime();
        }
    }
}
