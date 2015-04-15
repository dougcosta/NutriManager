using NutriManager.Data.Interfaces;
using NutriManager.Entities;
using NutriManager.Interfaces.Repositories;
using NutriManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriManager.Business.Factories
{
    //TODO: Testar
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IDataFactory _dataFactory;
        
        public RepositoryFactory(IDataFactory dataFactory)
        {
            if (dataFactory == null)
                throw new ArgumentNullException("dataFactory");

            this._dataFactory = dataFactory;
        }

        public IRepository<T> Get<T>()
            where T : EntityBase
        {
            IRepository<T> repository = (IRepository<T>) new PacientRepository(this._dataFactory);

            return repository;
        }
    }
}
