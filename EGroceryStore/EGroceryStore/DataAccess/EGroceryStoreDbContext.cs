using EGroceryStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGroceryStore.DataAccess
{
   
        public class EGroceryStoreDbContext : DbContext
        {




            public EGroceryStoreDbContext(DbContextOptions<EGroceryStoreDbContext> options) : base(options)
            {

            }
            public DbSet<UserModel> UserModels { get; set; }
            public DbSet<CartModel> CartModels { get; set; }
            public DbSet<GroceryModel> GroceryModels { get; set; }
            public DbSet<LoginModel> LoginModels { get; set; }
            public DbSet<RatingModel> RatingModels { get; set; }
            public DbSet<VegetableModel> VegetableModels { get; set; }
            public DbSet<BuyModel> BuyModel { get; set; }


        }
    }

