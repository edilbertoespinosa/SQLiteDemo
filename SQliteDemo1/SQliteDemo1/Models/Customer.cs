using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQliteDemo1.Models
{
    [Table("Customers")]
    public class Customer : Abstractions.TableData
    {
        //[Column("name"), Indexed, Unique, NotNull]
        [Column("name"), Indexed, NotNull]
        public string Name { get; set; }

        public string Phone { get; set; }

        public int Age { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Ignore]
        public bool IsYoung 
        { 
            get
            {
                return Age < 30 ? true : false;
            }
        }

        [ForeignKey(typeof(Passport))]
        public int PassportId { get; set; }

        //Relacion Uno a Uno
        [OneToOne(CascadeOperations=CascadeOperation.CascadeInsert | 
                                    CascadeOperation.CascadeRead | 
                                    CascadeOperation.CascadeDelete)]
        public Passport Passport { get; set; }

        //Relacion Uno a Muchos
        [OneToMany(CascadeOperations = CascadeOperation.CascadeInsert |
                                    CascadeOperation.CascadeRead |
                                    CascadeOperation.CascadeDelete)]
        public List<CreditCard> CreditCards { get; set; }

        //Relacion Muchos a Muchos
        [ManyToMany(typeof(CustomerAsistencia), CascadeOperations = CascadeOperation.CascadeInsert |
                                    CascadeOperation.CascadeRead |
                                    CascadeOperation.CascadeDelete)]
        public List<Asistencia> Asistencias { get; set; }
    }
}
