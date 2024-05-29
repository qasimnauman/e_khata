using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class OrdersModel
    {
        public int orderid { get; set; }
        public DateTime? orderdate { get; set; }
        public int customerid { get; set; }
        public int billamount { get; set; }
        public int productid { get; set; }
        public string? status { get; set; }
        public int quantity { get; set; }
    }
}
