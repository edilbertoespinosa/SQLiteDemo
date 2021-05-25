using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQliteDemo1.Abstractions
{
    public class TableData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
