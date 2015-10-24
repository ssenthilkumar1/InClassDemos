using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eRestaurantSystem.DAL;
using eRestaurantSystem.DAL.Entities;
using System.ComponentModel; //Object Data Source
using eRestaurantSystem.DAL.DTOs;
using eRestaurantSystem.DAL.POCOs;
#endregion

namespace eRestaurantSystem.BLL
{
    [DataObject]
    public class AdminController
    {
        #region Queries

         [DataObjectMethod(DataObjectMethodType.Select, false)]
         public List<Waiter> Waiters_List()
         {

             using (var context = new eRestaurantContext())
             {
                 
                 var results = from item in context.Waiters
                               orderby item.LastName,item.FirstName
                               select item;
                 return results.ToList(); // null,one or mnore rows

             }

         }


         [DataObjectMethod(DataObjectMethodType.Select, false)]
         public Waiter GetWaiterByID(int waiterid)
         {

             using (var context = new eRestaurantContext())
             {

                 var results = from item in context.Waiters
                               where item.WaiterID == waiterid
                               select item;
                 return results.FirstOrDefault(); // only one row

             }
         }

         [DataObjectMethod(DataObjectMethodType.Insert, false)]
         public int Waiters_Add(Waiter item)
         {
             //set context
             using (eRestaurantContext context = new eRestaurantContext())
             {
                 // these methods are executed using an instance level item
                 //set up an instance pointer and intialize the pointer to null

                 Waiter added = null;
                 //setup the command to execute the add
                 added = context.Waiters.Add(item);

                 //command is not executed until it is actually saved.
                 context.SaveChanges();

                 //the waiter instance added contains the newly inserted
                 //record to sql including the generated pkey value

                 return added.WaiterID;
             }
         }

         [DataObjectMethod(DataObjectMethodType.Update, false)]
         public void Waiter_Update(Waiter item)
         {
             //set context
             using (eRestaurantContext context = new eRestaurantContext())
             {
                 // indicate the updating item instance
                 //alter the modified status flag for the particular instance

                 context.Entry<Waiter>(context.Waiters.Attach(item)).State =
                     System.Data.Entity.EntityState.Modified;
                 //command is not executed until it is actually saved.
                 context.SaveChanges();
             }
         }

         [DataObjectMethod(DataObjectMethodType.Delete, false)]
         public void Waiter_Delete(Waiter item)
         {
             //set context
             using (eRestaurantContext context = new eRestaurantContext())
             {
                 //look uo for the instance and record if found
                 Waiter existing = context.Waiters.Find(item.WaiterID);
                 //setup the command to execute the delete
                 context.Waiters.Remove(existing);

                 //command is not executed until it is actually saved.
                 context.SaveChanges();
             }
         }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SpecialEvent> SpecialEvents_List()
        {
            //Connect to our DbContext Class in the DAL
            //create an instance of the class
            //we will use a transaction for our query

            using (var context = new eRestaurantContext())
            {
                //method syntax
                //  return context.SpecialEvents.OrderBy(x => x.Description).ToList();

                //Query Syntax for the above mentioned return statement
                //which gives the same data as the return statement

                var results = from item in context.SpecialEvents
                              orderby item.Description
                              select item;
                return results.ToList();

            }


        }


//getting data from the reservation table

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Reservation> GetReservationsByEventCode(string eventcode)
        {
            //Connect to our DbContext Class in the DAL
            //create an instance of the class
            //we will use a transaction for our query

            using (var context = new eRestaurantContext())
            {
                //method syntax
                //  return context.SpecialEvents.OrderBy(x => x.Description).ToList();

                //Query Syntax for the above mentioned return statement
                //which gives the same data as the return statement

                var results = from item in context.Reservations
                              where item.EventCode.Equals(eventcode)
                              orderby item.CustomerName,item.ReservationDate
                              select item;
                return results.ToList();

            }


        }


        [DataObjectMethod(DataObjectMethodType.Select, false)]

        public List<ReservationsByDate> GetReservationsByDate(string reservationdate)
        {
            using (var context = new eRestaurantContext())
            {
                //Linq is not cooperative with DateTime

                int theYear = (DateTime.Parse(reservationdate)).Year;
                int theMonth = (DateTime.Parse(reservationdate)).Month;
                int theDay = (DateTime.Parse(reservationdate)).Day;

                var results = from eventitem in context.SpecialEvents
                              orderby eventitem.Description
                              select new ReservationsByDate() // a new instance for the specialevent row on the table
                              {
                                  Description = eventitem.Description,
                                  Reservations = from row in eventitem.Reservations
                                                 where row.ReservationDate.Year == theYear &&
                                                 row.ReservationDate.Month == theMonth &&
                                                 row.ReservationDate.Day == theDay
                                                 select new ReservationDetail() //new instance for each reservation of a particular specialevent code
                                                 {
                                                     CustomerName = row.CustomerName,
                                                     ReservationDate = row.ReservationDate,
                                                     NumberInParty = row.NumberInParty,
                                                     ContactPhone = row.ContactPhone,
                                                     ReservationStatus = row.ReservationStatus
                                                 }
                              };

                return results.ToList();
            }


        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<CategoryMenuItems> GetReportCategoryMenuItems()
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var results = from cat in context.Items
                              orderby cat.Category.Description, cat.Description
                              select new CategoryMenuItems
                              {
                                  CategoryDescription = cat.Category.Description,
                                  ItemDescription = cat.Description,
                                  Price = cat.CurrentPrice,
                                  Calories = cat.Calories,
                                  Comment = cat.Comment
                              };

                return results.ToList(); // this was .Dump() in Linqpad
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<WaiterBilling> GetWaiterBillingReport()
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var results = from abillrow in context.Bills
                              where abillrow.BillDate.Month == 5
                              orderby abillrow.BillDate,
                              abillrow.Waiter.LastName,
                              abillrow.Waiter.FirstName
                              select new WaiterBilling()
                              {
                                  BillDate = abillrow.BillDate.Year+"/"+
                                                      abillrow.BillDate.Month + "/" +
                                                       abillrow.BillDate.Day,
                                  WaiterName = abillrow.Waiter.FirstName + ", " + abillrow.Waiter.LastName,
                                  BillID = abillrow.BillID,
                                  BillTotal = abillrow.Items.Sum(eachbillitemrow => eachbillitemrow.Quantity * eachbillitemrow.SalePrice),
                                  PartySize = abillrow.NumberInParty,
                                  Contact = abillrow.Reservation.CustomerName
                              };
                return results.ToList();
            }
        }

        #endregion

        #region Add,Update, Delete of CRUD for CQRS-Command Query Request seggregation

        [DataObjectMethod(DataObjectMethodType.Insert,false)]
        public void SpecialEvents_Add(SpecialEvent item)
        {
            //set context
            using(eRestaurantContext context = new eRestaurantContext())
            {
            // these methods are executed using an instance level item
            //set up an instance pointer and intialize the pointer to null

            SpecialEvent added = null;
            //setup the command to execute the add
            added = context.SpecialEvents.Add(item);

            //command is not executed until it is actually saved.
            context.SaveChanges();
            }
        }

         [DataObjectMethod(DataObjectMethodType.Update, false)]
        public void SpecialEvents_Update(SpecialEvent item)
        {
            //set context
            using (eRestaurantContext context = new eRestaurantContext())
            {
                // indicate the updating item instance
                //alter the modified status flag for the particular instance

                context.Entry<SpecialEvent>(context.SpecialEvents.Attach(item)).State =
                    System.Data.Entity.EntityState.Modified;
                //command is not executed until it is actually saved.
                context.SaveChanges();
            }
        }

         [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public void SpecialEvents_Delete(SpecialEvent item)
        {
            //set context
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //look uo for the instance and record if found
                SpecialEvent existing = context.SpecialEvents.Find(item.EventCode);
                //setup the command to execute the delete
                context.SpecialEvents.Remove(existing);

                //command is not executed until it is actually saved.
                context.SaveChanges();
            }
        }

        

        #endregion
    }//eof class
}//eof namespace
