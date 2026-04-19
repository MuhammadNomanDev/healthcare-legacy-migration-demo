<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="LegacyClinicSystem.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1 class="mb-4">City Clinic Dashboard</h1>
        <div class="row">
            <div class="col-md-3">
                <div class="card stat-card bg-primary text-white h-100">
                    <div class="card-body">
                        <h5 class="card-title">Total Patients</h5>
                        <p class="card-text display-4"><asp:Label ID="lblPatientCount" runat="server" Text="0"></asp:Label></p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card stat-card bg-success text-white h-100">
                    <div class="card-body">
                        <h5 class="card-title">Total Doctors</h5>
                        <p class="card-text display-4"><asp:Label ID="lblDoctorCount" runat="server" Text="0"></asp:Label></p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card stat-card bg-info text-white h-100">
                    <div class="card-body">
                        <h5 class="card-title">Total Appointments</h5>
                        <p class="card-text display-4"><asp:Label ID="lblAppointmentCount" runat="server" Text="0"></asp:Label></p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card stat-card bg-warning text-white h-100">
                    <div class="card-body">
                        <h5 class="card-title">Today's Appointments</h5>
                        <p class="card-text display-4"><asp:Label ID="lblTodayAppointments" runat="server" Text="0"></asp:Label></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
