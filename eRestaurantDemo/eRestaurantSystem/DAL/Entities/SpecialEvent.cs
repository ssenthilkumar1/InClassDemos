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
    public class SpecialEvent
    {
        [Key]
        [Required(ErrorMessage="An Event Code Is Required (only one character")]
        [StringLength(1,ErrorMessage="Event Code only one Charater in Length")]        
        public string EventCode { get; set; }
        [Required(ErrorMessage="Description is a Required Field")]
        [StringLength(30,ErrorMessage="Description has a maximum Length of 30 Characters")]
        public string Description { get; set; }
        
        public bool Active { get; set; }

        // Navigational virtual properties
        //This is a parent to the Reservation entity

        public virtual ICollection<Reservation> Reservations { get; set; }

        //default values can be set in the class  Contructor

        public SpecialEvent()
        {
            Active = true;
        }
    }
}
