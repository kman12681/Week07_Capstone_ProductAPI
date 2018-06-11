using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Week07_Capstone.Models
{
    public class Prod
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public Prod(int id, string name)
        {
            ProductID = id;
            ProductName = name;
        }
    }
}