<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Billing.aspx.cs" Inherits="LegacyClinicSystem.Billing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Billing List</h2>
        <div class="card">
            <div class="card-header">
                <h3 class="card-title">Billing List</h3>
            </div>
            <div class="card-body">
                <asp:GridView ID="gvBilling" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
                        <asp:BoundField DataField="PatientName" HeaderText="Patient" SortExpression="PatientName" />
                        <asp:BoundField DataField="AppointmentDate" HeaderText="Appointment Date" DataFormatString="{0:yyyy-MM-dd}" SortExpression="AppointmentDate" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:C}" SortExpression="Amount" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                        <asp:BoundField DataField="BillingDate" HeaderText="Billing Date" DataFormatString="{0:yyyy-MM-dd}" SortExpression="BillingDate" />
                    </Columns>
                    <PagerStyle CssClass="pagination" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>