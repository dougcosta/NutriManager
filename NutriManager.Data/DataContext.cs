using NutriManager.Entities;
using System.Data.Entity;

namespace NutriManager.Data
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Pacient> Pacients { get; set; }
    }
}
