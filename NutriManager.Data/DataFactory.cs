using NutriManager.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriManager.Data
{
    public class DataFactory : IDataFactory
    {
        //TODO:Testar
        public DataContext Get()
        {
            return new DataContext();
        }
    }
}
