using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eRestaurantSystem.DAL.Entities;
using System.Data.Entity;
#endregion
namespace eRestaurantSystem.DAL
{
    //this class only be accessiblefrom classes
    //only inside this compnanet library
    //therefore the access level for this class will be internal
    //This class will inherit from Dbcontext(EntityFramkework)

    internal class eRestaurantContext : DbContext
    {
        //Create a contructor which will task the connection string name to
        // the dbContext
        public eRestaurantContext() : base("name=EatIn")
        {

        }

        //set up of mapping DbSet<T> properties
        //map an entity to a database table

        public DbSet<SpecialEvent> SpecialEvents { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        
        //pasted from the moodle
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<Waiter> Waiters { get; set; }


        // When overwriting the OnModel creating method it is important
        //to remember to call the base method's implementation before
        // you accept the method

        //The ManyToManyNavigationpropertyconfiguration.map Method
        //lets you configure the tables and columns used for this
        //many to many relationship

        //it takes a ManyToManyNavigationpropertyconfiguration instance
        //in which you specify the column names by calling the MapLeftKey
        //MayRightKey, and ToTable methods

        //the "left" key is the one specified in the HasMany method
        //the "right" key is the one specified in the WithMany method

        //this navigation replaces the SQL associated table that breaks
        //the many to many relationship
        //this technique should only be used if the associate table in
        //sql has ONLY a compound primary key and NO non-key attributes

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Reservation>().HasMany(r => r.Tables)
                .WithMany(t => t.Reservations)
                .Map(mapping =>
                {
                    mapping.ToTable("ReservationTables");
                    mapping.MapLeftKey("ReservationsID");
                    mapping.MapRightKey("TableID");
                });
            base.OnModelCreating(modelBuilder); // DO NOT REMOVE
        }

        
    }
}
