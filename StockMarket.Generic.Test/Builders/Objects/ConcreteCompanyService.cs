using Framework.Generic.EntityFramework;
using StockMarket.DataModel;
using StockMarket.Generic.Services;

namespace StockMarket.Generic.Test.Builders.Objects
{
    public interface IConcreteCompanyService<T> : IBaseCompanyService<T> where T : Company
    {

    }

    public class ConcreteCompanyService<T> : BaseCompanyService<T>, IConcreteCompanyService<T> where T : Company
    {
        public ConcreteCompanyService(IEfRepository<T> repository)
            : base (repository)
        {

        }
    }
}
