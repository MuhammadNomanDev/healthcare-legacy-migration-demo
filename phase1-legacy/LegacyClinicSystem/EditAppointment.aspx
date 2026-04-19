<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditAppointment.aspx.cs" Inherits="LegacyClinicSystem.EditAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Edit Appointment</h2>
        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label ID="lblPatient" runat="server" AssociatedControlID="lblPatientValue" CssClass="col-sm-2 control-label">Patient</asp:Label>
                <div class="col-sm-4">
                    <asp:Label ID="lblPatientValue" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblDoctor" runat="server" AssociatedControlID="lblDoctorValue" CssClass="col-sm-2 control-label">Doctor</asp:Label>
                <div class="col-sm-4">
                    <asp:Label ID="lblDoctorValue" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblDate" runat="server" AssociatedControlID="txtAppointmentDate" CssClass="col-sm-2 control-label">Date</asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtAppointmentDate" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtAppointmentDate" ErrorMessage="* Required" CssClass="text-danger" Display="Dynamic" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblReason" runat="server" AssociatedControlID="txtReason" CssClass="col-sm-2 control-label">Reason</asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfvReason" runat="server" ControlToValidate="txtReason" ErrorMessage="* Required" CssClass="text-danger" Display="Dynamic" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblStatus" runat="server" AssociatedControlID="ddlStatus" CssClass="col-sm-2 control-label">Status</asp:Label>
                <div class="col-sm-4">
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                        <asp:ListItem Value="Scheduled">Scheduled</asp:ListItem>
                        <asp:ListItem Value="Completed">Completed</asp:ListItem>
                        <asp:ListItem Value="Cancelled">Cancelled</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-4">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update Appointment" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                </div>
            </div>
        </div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
    </div>
</asp:Content>