using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class ProductsModel
    {
        public int productid { get; set; }
        public string? Name { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int category_id { get; set; }
    }
}
