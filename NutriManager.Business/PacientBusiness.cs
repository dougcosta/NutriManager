using NutriManager.Entities;
using NutriManager.Interfaces.Business;
using NutriManager.Interfaces.Repositories;
using System;

namespace NutriManager.Business
{
    public class PacientBusiness
    {
        private readonly IRepositoryFactory _repositoryFactory;
        public PacientBusiness(IRepositoryFactory repositoryFactory)
        {
            if (repositoryFactory == null)
                throw new ArgumentNullException("repositoryFactory");

            this._repositoryFactory = repositoryFactory;
        }

        public void Save(Pacient pacient)
        {
            IRepository<Pacient> repository = this._repositoryFactory.Get<Pacient>();

            repository.Save(pacient);
        }
    }
}
