using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
#endregion

namespace eRestaurantSystem.DAL.Entities
{
    public class Table
    {
        [Key]
        public int TableID { get; set; }
        [Required,Range(1,25)]
        public byte TableNumber { get; set; } // tinyInt in SQL
        public bool Smoking { get; set; }
        [Required]
        public int Capacity { get; set; }
        public bool Available { get; set; }


        //Navigation Properties

        // The Reservations table (sql) is a many to many
        //relationship to the Table table (sql)

        //SQL solves this problem by having an associate table
        //that has a compound primary key created from Reservations
        //and tables

        //We will not be creating an entity for this associate Table.
        //Instead we will create an overloaded Map in our DbContext class

        //However, we can still create virtaul naviagtion property to accomodate
        //this relationship


        public virtual ICollection<Reservation> Reservations { get; set; }


        //set Boolean values

        public Table()
        {
            Available = true;
            Smoking = false;
        }

    }
}
