using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EGroceryStore.Models
{
    public class RatingModel
    {
        [Key]
        public int RatingId { get; set; }
        public int RatingScalevalue { get; set; }

        public int UserId { get; set; }
        public UserModel userModel { get; set; }

    }
}
