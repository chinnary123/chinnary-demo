using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EGroceryStore.Models
{
    public class BuyModel
    {
        [Key]
        public int BuyerId { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentMode { get; set; }
        public int ContactNumber { get; set; }
        [ForeignKey("userModel")]
        public int UserId { get; set; }

    }
}
