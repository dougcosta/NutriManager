using NutriManager.Entities;
using NutriManager.Interfaces.Repositories;
using System;

namespace NutriManager.Repositories
{
    public class PacientRepository : IRepository<Pacient>
    {
        private readonly IDataFactory _dataFactory;

        public PacientRepository(IDataFactory dataFactory)
        {
            if (dataFactory == null)
                throw new ArgumentNullException("dataFactory");

            this._dataFactory = dataFactory;
        }

        /// <summary>
        /// Save the desired pacient
        /// </summary>
        /// <param name="item">Pacient to be saved</param>
        public void Save(Pacient patient)
        {
            using(var context = this._dataFactory.Get())
            {
                if (patient.Id.Equals(Guid.Empty))
                    patient.Id = Guid.NewGuid();

                context.Pacients.Add(patient);
                context.SaveChanges();
            }
        }
    }
}
