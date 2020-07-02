using System.Collections.Generic;

namespace StockMarket.DataModel
{
    public enum QuoteTypeEnum
    {
        OneMinute = 1,
        FiveMinute = 2,
        FifteenMinute = 3,
        ThirtyMinute = 4,
        OneHour = 5,
        Day = 6,
        Week = 7,
        Month = 8
    }

    public partial class QuoteType
    {
        private QuoteType(QuoteTypeEnum @enum)
        {
            Id = (int)@enum;
            Type = @enum.ToString();
            Quotes = new HashSet<Quote>();
        }

        public static implicit operator QuoteType(QuoteTypeEnum @enum) => new QuoteType(@enum);
        public static implicit operator QuoteTypeEnum(QuoteType quoteType) => (QuoteTypeEnum)quoteType.Id;
    }
}
