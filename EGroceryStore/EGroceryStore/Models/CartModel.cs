using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EGroceryStore.Models
{
    public class CartModel
    {
        [Key]
        public int CartId { get; set; }
        public string ItemName { get; set; }
        public float ItemPrice { get; set; }
        [ForeignKey("userModel")]
        public int UserId { get; set; }
        public UserModel userModel { get; set; }
    }
}
