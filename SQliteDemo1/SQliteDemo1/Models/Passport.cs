using System;
using System.Collections.Generic;
using System.Text;

namespace SQliteDemo1.Models
{
    public class Passport : Abstractions.TableData
    {
        public DateTime ExpirationDate { get; set; }
    }
}
