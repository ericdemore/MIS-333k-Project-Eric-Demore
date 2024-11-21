using BevoBnB.DAL;
using BevoBnB.Models;
using BevoBnB.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BevoBnB.Seeding
{

    public static class SeedCategories
    {
        public static void SeedAllCategories(AppDbContext db)
        {
            List<Category> AllCategories = new List<Category>();

            AllCategories.Add(new Category
            {
                CategoryName = "House"
            });
            AllCategories.Add(new Category
            {
                CategoryName = "Cabin"
            });
            AllCategories.Add(new Category
            {
                CategoryName = "Apartment"
            });
            AllCategories.Add(new Category
            {
                CategoryName = "Condo"
            });
            AllCategories.Add(new Category
            {
                CategoryName = "Hotel"
            });
            // Save each category to the database
            foreach (Category seedCategory in AllCategories)
            {
                Category dbCategory = db.Categories.FirstOrDefault(c => 
                    c.CategoryName == seedCategory.CategoryName);
                
                if (dbCategory == null)
                {
                    db.Categories.Add(seedCategory);
                    db.SaveChanges();
                }
            }
        }
    }
}
