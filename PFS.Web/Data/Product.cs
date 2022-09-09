using PFS.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PFS.Web.Data
{
    public class Product
    {
        public static List<Products> GetProduct()
        {
            List<Products> list = new();

            string[] categoryArray = new string[] { "Electronic", "Fashion", "Home Decor", "Electronic", "Fashion", "Home Decor", "Electronic", "Fashion", "Home Decor", "Electronic" };

            for (int i = 0; i < categoryArray.Length; i++)
            {
                var id = i + 1;
                list.Add(new Products()
                {
                    Id = id,
                    Name = $"Product {id}",
                    Price = Convert.ToDouble(id),
                    Category = categoryArray[i].ToString(),
                });
            }

            return list;
        }
    }
}
