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

    }

}