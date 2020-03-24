using System.Collections.Generic;

namespace StockMarket.DataModel
{
    public enum QuoteTypeEnum
    {
        Second = 1,
        Minute = 2,
        Hour = 3,
        Day = 4
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
