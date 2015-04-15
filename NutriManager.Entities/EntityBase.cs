using System;
using System.ComponentModel.DataAnnotations;

namespace NutriManager.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
