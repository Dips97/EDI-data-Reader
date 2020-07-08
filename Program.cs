using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EDIDataReaderApp
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"C:\Users\LENOVO\source\repos\EDIDataReaderApp\EDI 860 Sample Data.txt"; //File Location
            DataReader reader = new DataReader(path);
            List<PO1> items = reader.Items();
            
            var CityZip = reader.N4();

            Console.WriteLine($"-------------------------Purchase Order {reader.ST()}--------------------------");
            Console.WriteLine($"{reader.N1()}.\n{reader.N3()}.\n{CityZip[1]}, {CityZip[2]} {CityZip[3]}");
            Console.WriteLine("");
            Console.WriteLine("Item No.     ProductID           Description                         Qty        Unit Price           Line Total");
            foreach (var item in items)
            {
                decimal EachQTY = Convert.ToDecimal(item.Quantity);
                decimal EachUnitPrice = Convert.ToDecimal(item.UnitPrice);

                Console.WriteLine($"{item.LineNumber}             {item.ProductId}           {item.ProductDescription}                         {EachQTY}        {EachUnitPrice}           {EachQTY * EachUnitPrice}");
            }

            Console.ReadLine();
        }
    }
}
