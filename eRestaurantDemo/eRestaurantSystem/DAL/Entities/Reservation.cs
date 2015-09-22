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
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReservationDate{get;set;}
        public int NumberInParty { get; set; }
        public string ContactPhone { get; set; }
        public string ReservationStatus { get; set; }
        public string EventCode { get; set; }

        // Navigation Properties
        public virtual SpecialEvent Event { get; set; }

        // The Reservations table (sql) is a many to many
        //relationship to the Table table (sql)

        //SQL solves this problem by having an associate table
        //that has a compound primary key created from Reservations
        //and tables

        //We will not be creating an entity for this associate Table.
        //Instead we will create an overloaded Map in our DbContext class

        //However, we can still create virtaul naviagtion property to accomodate
        //this relationship


        public virtual ICollection<Table> Tables { get; set; }

    }
}
