using Framework.Generic.EntityFramework;
using StockMarket.DataModel;
using StockMarket.Generic.Services;

namespace StockMarket.Generic.Test.Builders.Objects
{
    public interface IConcreteQuoteService<T> : IQuoteServiceBase<T> where T : Quote
    {

    }

    public class ConcreteQuoteService<T> : QuoteServiceBase<T>, IConcreteQuoteService<T> where T : Quote
    {
        public ConcreteQuoteService(IEfRepository<T> repository)
                : base(repository)
        {

        }
    }
}
