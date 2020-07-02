using StockMarket.DataModel;
using System.Diagnostics.CodeAnalysis;

namespace StockMarket.Generic.Downloaders.IEXCloud.JSON_Objects
{
    [ExcludeFromCodeCoverage]
    public class EXIntradayQuote
    {
        public int QuoteTypeId => (int)QuoteTypeEnum.OneMinute;

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public System.DateTime Date { get; set; }
        public string Minute { get; set; }
        public string Label { get; set; }
        public decimal? Open { get; set; }
        public decimal? High { get; set; }
        public decimal? Low { get; set; }
        public decimal? Close { get; set; }
        public long Volume { get; set; }
        public float? Average { get; set; }
        public float ChangeOverTime { get; set; }
    }
}
