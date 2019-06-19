using StockMarket.DataModel;
using System.Diagnostics.CodeAnalysis;

namespace StockMarket.Generic.Downloaders.IEXCloud.JSON_Objects
{
    [ExcludeFromCodeCoverage]
    public class EXQuote : Quote
    {
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
