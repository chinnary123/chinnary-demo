using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EGroceryStore.Models
{
    public class VegetableModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public long QuantityInKg { get; set; }
        [Required]
        public long CostPerKg { get; set; }
        [Required]
        public string HybridOrNatural { get; set; }
    }
}

