<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Doctors.aspx.cs" Inherits="LegacyClinicSystem.Doctors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <h2>Doctors List</h2>
    <asp:GridView ID="gvDoctors" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
            <asp:BoundField DataField="FullName" HeaderText="Full Name" SortExpression="FullName" />
            <asp:BoundField DataField="Specialisation" HeaderText="Specialisation" SortExpression="Specialisation" />
            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        </Columns>
        <PagerStyle CssClass="pagination" />
    </asp:GridView>
    </div>
</asp:Content>
