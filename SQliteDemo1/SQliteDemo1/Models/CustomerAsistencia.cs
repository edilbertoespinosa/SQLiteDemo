using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQliteDemo1.Models
{
    public class CustomerAsistencia
    {
        [ForeignKey(typeof(Customer))]
        public int CustomerId { get; set; }
        [ForeignKey(typeof(Asistencia))]
        public int AsistenciaId { get; set; }
    }
}
