using NutriManager.Data;

namespace NutriManager.Interfaces.Repositories
{
    public interface IDataFactory
    {
        DataContext Get();
    }
}
