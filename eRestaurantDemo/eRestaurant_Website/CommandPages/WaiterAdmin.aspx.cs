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
        if(!Page.IsPostBack)
        {
            HireDate.Text = DateTime.Today.ToShortDateString();
            RefreshWaiterList("0"); //set the dropdown list to the prompt
        }
    }

    protected void RefreshWaiterList(string selectedvalue)
    {
        //force the re-execution for the dropdown list

        WaiterList.DataBind();

        // Insert the prompt line into the dropdown list data
        WaiterList.Items.Insert(0, "Select a Waiter");

        //Position the waiter list to the Desired row representing the waiter
        WaiterList.SelectedValue = selectedvalue;
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
    protected void WaiterInsert_Click(object sender, EventArgs e)
    {
        //Inline versionof using MessageUserControl
        //Inline is done by using Lamda (=>)
        MessageUserControl.TryRun(() => 
            // remainder of the code is what would have gone in the 
            //extrenal method of(ProcessRequest(MethodName))
            {
                Waiter item = new Waiter();
                item.FirstName = FirstName.Text;
                item.LastName = LastName.Text;
                item.Address = Address.Text;
                item.Phone = Phone.Text;
                item.HireDate = DateTime.Parse(HireDate.Text);

                //check for nullable

                if(string.IsNullOrEmpty(ReleaseDate.Text))
                {
                    item.ReleaseDate = null;
                }
                else
                {
                    item.ReleaseDate = DateTime.Parse(ReleaseDate.Text);
                }

                AdminController sysmgr = new AdminController();
                WaiterID.Text = sysmgr.Waiters_Add(item).ToString();
                MessageUserControl.ShowInfo("Waiter added.");
             //   WaiterList.DataBind(); // Refresh the drop down list
                RefreshWaiterList(WaiterID.Text);

            }
            );
    }
    protected void WaiterUpdate_Click(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(WaiterID.Text))
        {
            MessageUserControl.ShowInfo("Please Select a waiter first before Updating");
        }
        else
        {
            //Standard update process
            MessageUserControl.TryRun(() =>
            // remainder of the code is what would have gone in the 
            //extrenal method of(ProcessRequest(MethodName))
            {
                Waiter item = new Waiter();

                //for an update you must supply the primary key value
                item.WaiterID = int.Parse(WaiterID.Text);
                item.FirstName = FirstName.Text;
                item.LastName = LastName.Text;
                item.Address = Address.Text;
                item.Phone = Phone.Text;
                item.HireDate = DateTime.Parse(HireDate.Text);

                //check for nullable

                if (string.IsNullOrEmpty(ReleaseDate.Text))
                {
                    item.ReleaseDate = null;
                }
                else
                {
                    item.ReleaseDate = DateTime.Parse(ReleaseDate.Text);
                }

                AdminController sysmgr = new AdminController();
               sysmgr.Waiter_Update(item);
                MessageUserControl.ShowInfo("Waiter updated.");
               // WaiterList.DataBind(); // Refresh the drop down list
                RefreshWaiterList(WaiterID.Text);

            }
            );
        }
    }
    
}