<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PatientDetails.aspx.cs" Inherits="LegacyClinicSystem.PatientDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Patient Details</h2>
        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="lblFirstNameValue" CssClass="col-sm-2 control-label">First Name</asp:Label>
                <div class="col-sm-4">
                    <asp:Label ID="lblFirstNameValue" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblLastName" runat="server" AssociatedControlID="lblLastNameValue" CssClass="col-sm-2 control-label">Last Name</asp:Label>
                <div class="col-sm-4">
                    <asp:Label ID="lblLastNameValue" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblDOB" runat="server" AssociatedControlID="lblDOBValue" CssClass="col-sm-2 control-label">Date of Birth</asp:Label>
                <div class="col-sm-4">
                    <asp:Label ID="lblDOBValue" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPhone" runat="server" AssociatedControlID="lblPhoneValue" CssClass="col-sm-2 control-label">Phone</asp:Label>
                <div class="col-sm-4">
                    <asp:Label ID="lblPhoneValue" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblEmail" runat="server" AssociatedControlID="lblEmailValue" CssClass="col-sm-2 control-label">Email</asp:Label>
                <div class="col-sm-4">
                    <asp:Label ID="lblEmailValue" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblMRN" runat="server" AssociatedControlID="lblMRNValue" CssClass="col-sm-2 control-label">Medical Record Number</asp:Label>
                <div class="col-sm-4">
                    <asp:Label ID="lblMRNValue" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-4">
                    <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl="#" CssClass="btn btn-primary">Edit Patient</asp:HyperLink>
                    <asp:HyperLink ID="lnkBack" runat="server" NavigateUrl="~/Patients.aspx" CssClass="btn btn-secondary">Back to List</asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>