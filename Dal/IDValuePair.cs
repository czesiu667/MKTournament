using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL
{
    public class IDValuePair
    {
        public int ID { get; set; }
        public int Value { get; set; }

        public IDValuePair(int id, int value)
        {
            ID = id;
            Value = value;
        }
    }
}