﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eRestaurantSystem.DAL;
using eRestaurantSystem.DAL.Entities;
using System.ComponentModel; //Object Data Source
#endregion

namespace eRestaurantSystem.BLL
{
    [DataObject]
    public class AdminController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<SpecialEvent> SpecialEvents_List()
        {
            //Connect to our DbContext Class in the DAL
            //create an instance of the class
            //we will use a transaction for our query

            using(var context = new eRestaurantContext())
            {
                 //method syntax
                return context.SpecialEvents.OrderBy(x => x.Description).ToList();

            }

          
        }

    }
}