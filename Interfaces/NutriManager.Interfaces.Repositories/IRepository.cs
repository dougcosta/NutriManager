using NutriManager.Entities;
using System;

namespace NutriManager.Interfaces.Repositories
{
    public interface IRepository<T>
        where T : EntityBase
    {
        /// <summary>
        /// Save the desired item
        /// </summary>
        /// <param name="item">Item to be saved</param>
        void Save(T item);
    }
}
