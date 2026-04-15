<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Appointments.aspx.cs" Inherits="LegacyClinicSystem.Appointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <h2>Appointments List</h2>
    <asp:GridView ID="gvAppointments" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
            <asp:BoundField DataField="PatientName" HeaderText="Patient" SortExpression="PatientName" />
            <asp:BoundField DataField="DoctorName" HeaderText="Doctor" SortExpression="DoctorName" />
            <asp:BoundField DataField="AppointmentDate" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" SortExpression="AppointmentDate" />
            <asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
        </Columns>
        <PagerStyle CssClass="pagination" />
    </asp:GridView>
    </div>
</asp:Content>
