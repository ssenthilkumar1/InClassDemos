<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SpecialEventsAdmin.aspx.cs" Inherits="SamplePage_SpecialEventsAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">


    <table align="center" style="width: 70%">
        <tr>
            <td align="right" style="width:50%">Select an Event:&nbsp;</td>
            <td>
                <asp:DropDownList ID="SpecialEventList" runat="server" AppendDataBoundItems="True" DataSourceID="ODSSpecialEvents" DataTextField="Description" DataValueField="EventCode">
                    <asp:ListItem Value="z">Select Event</asp:ListItem>
                </asp:DropDownList>
                <asp:LinkButton ID="FetchRegistrations" runat="server">Fetch Registrations</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="center"> 
                <asp:GridView ID="ReservationList" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ODSReservations">
                    <Columns>
                        <asp:BoundField DataField="CustomerName" HeaderText="Name" SortExpression="CustomerName" />
                        <asp:BoundField DataField="ReservationDate" HeaderText="Date" SortExpression="ReservationDate" DataFormatString="{0:MMM,dd,yyyy}" >
                        <FooterStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NumberInParty" HeaderText="Size" SortExpression="NumberInParty" >
                        <FooterStyle HorizontalAlign="Right" />
                        <HeaderStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ContactPhone" HeaderText="Phone" SortExpression="ContactPhone" >
                        <FooterStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ReservationStatus" HeaderText="Status" SortExpression="ReservationStatus" />
                    </Columns>
                    <EmptyDataTemplate>
                        No Data to Display At This Time
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
            
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:DetailsView ID="ReservationListDV" runat="server" AllowPaging="True" AutoGenerateRows="False" DataSourceID="ODSReservations" >
                    <EmptyDataTemplate>
                        No Data To Display At This Time
                    </EmptyDataTemplate>
                    <Fields>
                        <asp:BoundField DataField="CustomerName" HeaderText="Name">
                        <HeaderStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ReservationDate" DataFormatString="{0:MMM dd, yyyy h:mm:tt}" HeaderText="Date" />
                        <asp:BoundField DataField="NumberInParty" HeaderText="Size" />
                        <asp:BoundField DataField="ContactPhone" HeaderText="Phone" />
                        <asp:BoundField DataField="ReservationStatus" HeaderText="Status" />
                    </Fields>
                </asp:DetailsView>
            </td>
            
        </tr>
        
    </table>

    <asp:ObjectDataSource ID="ODSSpecialEvents" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SpecialEvents_List" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODSReservations" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetReservationsByEventCode" TypeName="eRestaurantSystem.BLL.AdminController">
        <SelectParameters>
            <asp:ControlParameter ControlID="SpecialEventList" Name="eventcode" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>


