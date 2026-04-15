<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LegacyClinicSystem.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <h1>Clinic Management System</h1>
    <div class="row">
        <div class="col-sm-6">
            <asp:Label ID="lblPatientCount" runat="server" CssClass="lead" Text="Patients: "></asp:Label>
        </div>
        <div class="col-sm-6">
            <asp:Label ID="lblAppointmentCount" runat="server" CssClass="lead" Text="Appointments Today: "></asp:Label>
        </div>
    </div>
    </div>
</asp:Content>
