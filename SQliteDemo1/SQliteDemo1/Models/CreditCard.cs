using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQliteDemo1.Models
{
    public class CreditCard : Abstractions.TableData
    {
        public DateTime ExpirationDate { get; set; }

        [ForeignKey(typeof(Customer))]
        public int CustomerId { get; set; }

    }
}
