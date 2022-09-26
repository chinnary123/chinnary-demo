using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EGroceryStore.Models
{
    public class LoginModel
    {
        [Key]
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
