using QueenLocalDataHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenLocalDataHandling
{
    class Order
    {
        public int OrderId { get; set; }
        public string CustomerCnic { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public int ProductId { get; set; }
        public int ProductPrice { get; set; }
        public string ProductSize { get; set; }
    }
}