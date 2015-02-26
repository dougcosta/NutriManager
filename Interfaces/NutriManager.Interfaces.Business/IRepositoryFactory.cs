using NutriManager.Interfaces.Repositories;

namespace NutriManager.Interfaces.Business
{
    public interface IRepositoryFactory
    {
        IRepository<T> Get<T>();
    }
}
