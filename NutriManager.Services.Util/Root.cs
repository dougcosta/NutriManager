using NutriManager.Business;
using NutriManager.Business.Factories;
using NutriManager.Data;
using NutriManager.Data.Interfaces;
using NutriManager.Interfaces.Business;
using NutriManager.Interfaces.Repositories;

namespace NutriManager.Services.Util
{
    public static class Root
    {
        public static IPacientBusiness GetPacientBusiness()
        {
            IDataFactory dataFactory = new DataFactory();
            IRepositoryFactory repositoryFactory = new RepositoryFactory(dataFactory);
            IPacientBusiness business = new PacientBusiness(repositoryFactory);

            return business;
        }
    }
}
