<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LegacyClinicSystem.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Clinic Management System</h1>
        <asp:Label ID="lblPatientCount" runat="server" Text="Patients: "></asp:Label><br />
        <asp:Label ID="lblAppointmentCount" runat="server" Text="Appointments Today: "></asp:Label>
    </div>
</asp:Content>