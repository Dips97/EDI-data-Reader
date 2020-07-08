using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EDIDataReaderApp
{
    class DataReader
    {
        string _filePath;

        public DataReader(string filepath)
        {
            _filePath = filepath;
        }

        public int ST()
        {
            
            string search = "ST";
            int EDIType = 0;
            string[] lines = File.ReadAllLines(_filePath);
            foreach(string line in lines)
            {
                if (line.StartsWith(search))
                {
                    var Elements = line.Split('*');
                    EDIType = Convert.ToInt32(Elements[1]);
                }
            }

            //string E = line.Where(Line => Line.StartsWith(search)).ToString();
            //    var STLIneElement = E.Split('*');
            //    var EDItype = STLIneElement[1];
            //    return Convert.ToInt32(EDItype);
            return EDIType;
        }
        public string N1()
        {
            string N1Element = string.Empty;
            string searchKeyword = "N1";
            string[] lines = File.ReadAllLines(_filePath);
            foreach(string line in lines)
            {
                if (line.StartsWith(searchKeyword))
                {
                    string[] n1LineElements = line.Split('*');
                    N1Element = n1LineElements[2];
                }
            }
            
            return N1Element;
        }
        public string N3()
        {
            string N3element = string.Empty;
            string searchKeyword = "N3";

            string[] lines = File.ReadAllLines(_filePath);
            foreach(string line in lines)
            {
                if (line.StartsWith(searchKeyword))
                {
                    var N3elements = line.Split('*');
                    N3element = N3elements[1];
                }
            }
            return N3element;
        }
        public string[] N4()
        {
            string[] N4elements = new string[4];
            string searchKeyword = "N4";
            var lines = File.ReadAllLines(_filePath);
            foreach(var line in lines)
            {
                if (line.StartsWith(searchKeyword))
                {
                    var elements = line.Split('*');
                    N4elements = elements;
                }
            }
            return N4elements;
        }

        public List<PO1> Items()
        {
            List<PO1> items = new List<PO1>();
            PO1 itemObject = null;
            var lines = File.ReadAllLines(_filePath);
            foreach(var line in lines)
            {
                if (line.StartsWith("PO1"))
                {
                    string[] itemValues = line.Split('*');

                    itemObject = new PO1();
                    itemObject.LineNumber = itemValues[1];
                    itemObject.Quantity = itemValues[2];
                    itemObject.UnitPrice = itemValues[4];
                    itemObject.ProductId = itemValues[7];
                    //populate all the other fields
                    
                }
                if (line.StartsWith("PID"))
                {
                    string[] PIDValues = line.Split('*');

                    itemObject.ProductDescription = PIDValues[5];
                    items.Add(itemObject);
                }
                
            }
            return items;
        }
    }
}
