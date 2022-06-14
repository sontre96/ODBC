using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssigmentODBC
{
    class Product
    {
        private int Id { get; set; }
        private string proName { get; set; }
        private string proDesc { get; set; }
        private decimal Price { get; set; }

        public Product(string proName, string proDesc, decimal Price)
        {
            this.proName = proName;
            this.proDesc = proDesc;
            this.Price = Price;
        }

        public Product(int id, string proName, string proDesc, decimal Price)
        {
            this.Id = id;
            this.proName = proName;
            this.proDesc = proDesc;
            this.Price = Price;
        }

        public override string ToString()
        {
            //return "Product { Name: " + proName + "\tDescription: "  + proDesc + "\tPrice: " + Price + "}";
            return "Product { Id: " + Id + "\tName: " + proName + "\tDescription: "  + proDesc + "\tPrice: " + Price + "}";
        }
    }
}

