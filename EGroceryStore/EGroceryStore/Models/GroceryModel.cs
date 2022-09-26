using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EGroceryStore.Models
{
    public class GroceryModel
    {
        [Key]
        public int GroceryId { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public float Cost { get; set; }
    }
}
