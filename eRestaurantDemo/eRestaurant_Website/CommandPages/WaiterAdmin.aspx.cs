using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using eRestaurantSystem.BLL; // for Controller
using eRestaurantSystem.DAL.Entities; // for Entity
using EatIn.UI; // for delegate
#endregion
public partial class CommandPages_WaiterAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CheckForException(object sender,ObjectDataSourceStatusEventArgs e)
    {
        MessageUserControl.HandleDataBoundException(e);
    }
    protected void FetchWaiter_Click(object sender, EventArgs e)
    {
        // to properly interface with our messageusercontrol
        //we will delegate the execution of this click event 
        //under the MessageUserControl

        if(WaiterList.SelectedIndex == 0)
        {
            //Issue our own Error Message
            MessageUserControl.ShowInfo("Please Select a waiter to process");
        }
        else{
            //execute the necessary standard lookup code under the
            //control of the messageUSerControl

            MessageUserControl.TryRun((ProcessRequest)GetWaiterInfo);
        }
    }

    public void GetWaiterInfo(){
        // Standard look up process

        AdminController sysmgr = new AdminController();
        var waiter = sysmgr.GetWaiterByID(int.Parse(WaiterList.SelectedValue));
        WaiterID.Text = waiter.WaiterID.ToString();
        FirstName.Text = waiter.FirstName;
        LastName.Text = waiter.LastName;
        Address.Text = waiter.Address;
        Phone.Text = waiter.Phone;
        HireDate.Text = waiter.HireDate.ToShortDateString();
        //null field check
        if(waiter.ReleaseDate.HasValue)
        {
            ReleaseDate.Text = waiter.ReleaseDate.ToString();
        }
        else{
            ReleaseDate.Text = " ";
        }

    }
}