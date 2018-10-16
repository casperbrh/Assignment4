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
    }
}
