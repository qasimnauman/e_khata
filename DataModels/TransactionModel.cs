using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class TransactionModel
    {
        public int TransactionsId { get; set; }
        public DateTime transaction_date { get; set; }
        public string? type { get; set; }
        public int product_id { get; set; }
        public int qunatity { get; set; }
        public int unitprice { get; set; }
    }
}
