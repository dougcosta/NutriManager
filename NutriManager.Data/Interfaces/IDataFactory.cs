using NutriManager.Data;

namespace NutriManager.Data.Interfaces
{
    public interface IDataFactory
    {
        DataContext Get();
    }
}
