using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Week07_Capstone.Models;

namespace Week07_Capstone.Controllers
{
    public class ValuesController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        public List<Prod> GetProducts()
        {
            List<Product> products = db.Products.ToList();
            List<Prod> prods = new List<Prod>();

            for (int i = 0; i < products.Count; i++)
            {

                prods.Add(new Prod(products[i].ProductID, products[i].ProductName));
            }

            return prods;

        }

        public List<Product> GetProductByID(int id)
        {
            List<Product> products = (from p in db.Products
                                      where p.ProductID == id
                                      select p).ToList();

            return products;


        }

        public List<Product> GetProductByCategoryID(int id)
        {
            List<Product> products = (from p in db.Products
                                      where p.CategoryID == id
                                      select p).ToList();

            return products;
        }

        public List<Product> GetProductBySupplierID(int id)
        {
            List<Product> products = (from p in db.Products
                                      where p.SupplierID == id
                                      select p).ToList();

            return products;
        }

        public Product GetProductByMaxPrice()
        {

            decimal max = 0;

            List<Product> allProds = db.Products.ToList();

            for (int i = 0; i < allProds.Count; i++)
            {
                if (allProds[i].UnitPrice > max)

                {
                    max = (decimal)allProds[i].UnitPrice;
                }
            }

            Product product = (from p in db.Products
                               where p.UnitPrice == max
                               select p).Single();

            return product;

        }

        public List<Product> GetDiscontinuedItems(bool status = false)
        {
            if (status == true)
            {
                List<Product> products = (from p in db.Products
                                          where p.Discontinued == status
                                          select p).ToList();

                return products;
            }
            else
            {
                List<Product> products = db.Products.ToList();
                return products;
            }
        }

    }

}
