using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public class DataService
    {
        /// <summary>
        /// Category Tests
        /// </summary>
        public List<Category> GetCategories()
        {
            using (var db = new NorthwindContex())
            {
                return db.Categories.ToList();
            }

        }
        public Category GetCategory(int index)
        {
            using (var db = new NorthwindContex())
            {
                return db.Categories.Find(index);
            }
        }
        public Category CreateCategory(string name, string description)
        {
            using (var db = new NorthwindContex())
            {
                var count = GetCategories();
                var newCat = new Category()
                {
                    Id = count.Count() + 1,
                    Name = name,
                    Description = description
                };
                db.Categories.Add(newCat);
                db.SaveChanges();
                return newCat;
            }

        }
        public bool DeleteCategory(int id)
        {
            try
            {
                using (var db = new NorthwindContex())
                {
                    var delCat = new Category() { Id = id };
                    db.Categories.Attach(delCat);
                    db.Categories.Remove(delCat);
                    db.SaveChanges();
                    if (delCat != null)
                    {

                        return true;
                    }
                    else return false;
                }
            }
            catch (Exception) { } return false;
        }

        /* public object UpdateCategory(int id, string v1, string v2)
        {
            throw new NotImplementedException();
        }*/

        public bool UpdateCategory(int categoryId, String name, String description)
        {
            try
            {
                using (var db = new NorthwindContex())
                {
                    var category = db.Categories.FirstOrDefault(x => x.Id == categoryId);

                    category.Name = name;
                    category.Description = description;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception) { } return false;
        }
        
        /// <summary>
        /// Product Tests
        /// </summary>
        public Product GetProduct(int productId)
        {
            using (var db = new NorthwindContex())
            {
                var product = db.Products
                    .Include(x => x.Category)
                    .FirstOrDefault(x => x.Id == productId);
                return product;
            }
        }
        
        public List<Product> GetProductByName(String productName)
        {
            using (var db = new NorthwindContex())
            {
                var product = db.Products
                    .Include(x => x.Category)
                    .FirstOrDefault(x => x.Id == productId);
                return product;
            }
        }
        
        /* public List<Product> GetProductByCategory(int categoryId)
         {
             using (var db = new NorthwindContex())
             {
                 var products = db.Products
                     .Include(x => x.Category)
                     .Where(x => x.Category.Id == categoryId)
                     .ToList();
                 return products;
             }
         }*/
         /*
        public List<Order> GetOrder(int Id)
        {
            using (var db = new NorthwindContex())
            {
                return db.Orders.ToList();
            }

        }*/


    }
}
