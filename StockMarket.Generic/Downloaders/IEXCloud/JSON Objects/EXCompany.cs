using System;
using System.Diagnostics.CodeAnalysis;

namespace StockMarket.Generic.Downloaders.IEXCloud.JSON_Objects
{
    [ExcludeFromCodeCoverage]
    public class EXCompany
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public string Exchange { get; set; }
        public string Industry { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string CEO { get; set; }
        public string SecurityName { get; set; }
        public string IssueType { get; set; }
        public string Sector { get; set; }
        public Nullable<int> Employees { get; set; }
        public string Tags { get; set; }
    }
}
