using StockMarket.DataModel;
using System.Diagnostics.CodeAnalysis;

namespace StockMarket.Generic.Downloaders.IEXCloud.JSON_Objects
{
    [ExcludeFromCodeCoverage]
    public class EXCompany : Company
    {
        public string CompanyName { get => Name; set => Name = value; }
        public int? Employees { get => NumEmployees; set => NumEmployees = value; }
    }
}
