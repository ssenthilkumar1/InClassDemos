using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Collections;
#endregion

namespace eRestaurantSystem.DAL.DTOs
{
    public class ReservationsByDate
    {
        public string Description { get; set; }

        //The next variable will hold a reservation of row
        public IEnumerable Reservations { get; set; }
    }
}
