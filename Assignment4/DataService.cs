using System;
using System.Linq;
using System.Collections.Generic;

namespace Assignment4
{
    public class DataService
    {

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
        public Category DeleteCategory(int id)
        {
            using (var db = new NorthwindContex())
            {
                var delCat = new Category() { Id = id };
                db.Categories.Attach(delCat);
                db.Categories.Remove(delCat);
                db.SaveChanges();
                return delCat;
            }

        }
    }
}
