using System;
using System.Collections.Generic;
using System.Text;

namespace SQliteDemo1.Models
{
    public class Order : Abstractions.TableData
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
