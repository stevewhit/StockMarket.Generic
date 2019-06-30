using System.Diagnostics.CodeAnalysis;

namespace StockMarket.Generic.Downloaders.IEXCloud.JSON_Objects
{
    [ExcludeFromCodeCoverage]
    public class EXQuote
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }
        public float UHigh { get; set; }
        public float ULow { get; set; }
        public float UClose { get; set; }
        public int UVolume { get; set; }
        public float Change { get; set; }
        public float ChangePercent { get; set; }
        public string Label { get; set; }
        public float ChangeOverTime { get; set; }
    }
}
