<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UpdateAppointmentStatus.aspx.cs" Inherits="LegacyClinicSystem.UpdateAppointmentStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Update Appointment Status</h2>
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
                <asp:Label ID="lblDate" runat="server" AssociatedControlID="lblDateValue" CssClass="col-sm-2 control-label">Date</asp:Label>
                <div class="col-sm-4">
                    <asp:Label ID="lblDateValue" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblReason" runat="server" AssociatedControlID="lblReasonValue" CssClass="col-sm-2 control-label">Reason</asp:Label>
                <div class="col-sm-4">
                    <asp:Label ID="lblReasonValue" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblCurrentStatus" runat="server" AssociatedControlID="lblCurrentStatusValue" CssClass="col-sm-2 control-label">Current Status</asp:Label>
                <div class="col-sm-4">
                    <asp:Label ID="lblCurrentStatusValue" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblNewStatus" runat="server" AssociatedControlID="ddlNewStatus" CssClass="col-sm-2 control-label">New Status</asp:Label>
                <div class="col-sm-4">
                    <asp:DropDownList ID="ddlNewStatus" runat="server" CssClass="form-control">
                        <asp:ListItem Value="Scheduled">Scheduled</asp:ListItem>
                        <asp:ListItem Value="Completed">Completed</asp:ListItem>
                        <asp:ListItem Value="Cancelled">Cancelled</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-4">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update Status" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                </div>
            </div>
        </div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
    </div>
</asp:Content>