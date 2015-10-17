<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WaiterAdmin.aspx.cs" Inherits="CommandPages_WaiterAdmin" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <h1>Waiter Admin CRUD</h1>
    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />

    <br />
    <asp:Label ID="WaiterID" runat="server" Text="Waiter Name"></asp:Label>

    <asp:DropDownList ID="WaiterList" runat="server" AppendDataBoundItems="True" DataSourceID="ODSWaiterList" DataTextField="WaiterID" DataValueField="WaiterID" Height="17px" Width="360px">

        <asp:ListItem Value="0">Select a Waiter</asp:ListItem>
    </asp:DropDownList>
    <asp:LinkButton ID="FetchWaiter" runat="server" OnClick="FetchWaiter_Click">Fetch Waiter</asp:LinkButton>
    <asp:ObjectDataSource ID="ODSWaiterList" runat="server" DataObjectTypeName="eRestaurantSystem.DAL.Entities.Waiter" DeleteMethod="Waiter_Delete" InsertMethod="Waiter_Add" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWaiterByID" TypeName="eRestaurantSystem.BLL.AdminController" UpdateMethod="Waiter_Update">
        <SelectParameters>
            <asp:Parameter Name="waiterid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <table style="width: 70%">
        <tr>
            <td>ID</td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>First Name</td>
            <td>
                <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td>
                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Address</td>
            <td>
                <asp:TextBox ID="Address" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Phone</td>
            <td>
                <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Hire Date</td>
            <td>
                <asp:TextBox ID="HireDate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Release Date</td>
            <td>
                <asp:TextBox ID="ReleaseDate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="WaiterInsert" runat="server">Insert</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="WaiterUpdate" runat="server">Update</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

