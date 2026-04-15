<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Patients.aspx.cs" Inherits="LegacyClinicSystem.Patients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <h2>Patients List</h2>
    <asp:GridView ID="gvPatients" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
            <asp:BoundField DataField="DateOfBirth" HeaderText="DOB" DataFormatString="{0:yyyy-MM-dd}" SortExpression="DateOfBirth" />
            <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="MedicalRecordNumber" HeaderText="MRN" SortExpression="MedicalRecordNumber" />
        </Columns>
        <PagerStyle CssClass="pagination" />
    </asp:GridView>
    </div>
</asp:Content>
