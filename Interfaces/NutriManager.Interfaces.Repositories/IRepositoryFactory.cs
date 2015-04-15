using NutriManager.Entities;
using NutriManager.Interfaces.Repositories;

namespace NutriManager.Interfaces.Repositories
{
    public interface IRepositoryFactory
    {
        IRepository<T> Get<T>() where T : EntityBase;
    }
}
