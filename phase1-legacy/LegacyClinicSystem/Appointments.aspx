<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Appointments.aspx.cs" Inherits="LegacyClinicSystem.Appointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Appointments List</h2>
        <div class="card">
            <div class="card-header">
                <h3 class="card-title">Appointments List</h3>
            </div>
            <div class="card-body">
                <asp:GridView ID="gvAppointments" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
                        <asp:BoundField DataField="PatientName" HeaderText="Patient" SortExpression="PatientName" />
                        <asp:BoundField DataField="DoctorName" HeaderText="Doctor" SortExpression="DoctorName" />
                        <asp:BoundField DataField="AppointmentDate" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" SortExpression="AppointmentDate" />
                        <asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason" />
                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                        <asp:TemplateField HeaderText="View Details">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkViewDetails" runat="server" Text="View Details" PostBackUrl='<%# "~/AppointmentDetails.aspx?Id=" + Eval("Id") %>' CssClass="btn btn-sm btn-info me-1"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" PostBackUrl='<%# "~/EditAppointment.aspx?Id=" + Eval("Id") %>' CssClass="btn btn-sm btn-success me-1"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Update Status">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkUpdateStatus" runat="server" Text="Update Status" PostBackUrl='<%# "~/UpdateAppointmentStatus.aspx?Id=" + Eval("Id") %>' CssClass="btn btn-sm btn-warning me-1"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pagination" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
