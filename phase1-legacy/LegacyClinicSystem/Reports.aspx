<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="LegacyClinicSystem.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Clinic Reports</h2>
        <div class="row">
            <div class="col-md-3">
                <div class="card text-white bg-primary mb-3">
                    <div class="card-header">Total Patients</div>
                    <div class="card-body">
                        <h5 class="card-title"><asp:Label ID="lblTotalPatients" runat="server" Text="0"></asp:Label></h5>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card text-white bg-success mb-3">
                    <div class="card-header">Total Doctors</div>
                    <div class="card-body">
                        <h5 class="card-title"><asp:Label ID="lblTotalDoctors" runat="server" Text="0"></asp:Label></h5>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card text-white bg-info mb-3">
                    <div class="card-header">Total Appointments</div>
                    <div class="card-body">
                        <h5 class="card-title"><asp:Label ID="lblTotalAppointments" runat="server" Text="0"></asp:Label></h5>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card text-white bg-warning mb-3">
                    <div class="card-header">Total Revenue</div>
                    <div class="card-body">
                        <h5 class="card-title"><asp:Label ID="lblTotalRevenue" runat="server" Text="$0"></asp:Label></h5>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-4">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">Appointments by Status</div>
                    <div class="card-body">
                        <asp:GridView ID="gvAppointmentStatus" runat="server" CssClass="table table-striped" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                <asp:BoundField DataField="Count" HeaderText="Count" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">Billing Status</div>
                    <div class="card-body">
                        <asp:GridView ID="gvBillingStatus" runat="server" CssClass="table table-striped" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                <asp:BoundField DataField="Count" HeaderText="Count" />
                                <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:C}" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>