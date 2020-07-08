using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDIDataReaderApp
{
    class PO1 
    {
        //As PO1 Line Contains Quantity, unit Price and item name and other details so we created a property class 
        public string LineNumber { set; get; }
        public string Quantity { set; get; }
        public string UnitPrice { set; get; }
        public string ProductId { set; get; }
        public string ProductDescription { set; get; }
    }
}
