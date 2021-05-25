using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQliteDemo1.Models
{
    public class Asistencia : Abstractions.TableData
    {
        public DateTime MyDate { get; set; }

        //Relacion Muchos a Muchos
        [ManyToMany(typeof(CustomerAsistencia))]
        public List<Customer> Customers { get; set; }
    }
}
