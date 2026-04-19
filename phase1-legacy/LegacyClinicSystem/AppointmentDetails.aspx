<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AppointmentDetails.aspx.cs" Inherits="LegacyClinicSystem.AppointmentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Appointment Details</h2>
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
                <asp:Label ID="lblStatus" runat="server" AssociatedControlID="lblStatusValue" CssClass="col-sm-2 control-label">Status</asp:Label>
                <div class="col-sm-4">
                    <asp:Label ID="lblStatusValue" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-4">
                    <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl="#" CssClass="btn btn-primary">Edit Appointment</asp:HyperLink>
                    <asp:HyperLink ID="lnkBack" runat="server" NavigateUrl="~/Appointments.aspx" CssClass="btn btn-secondary">Back to List</asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>