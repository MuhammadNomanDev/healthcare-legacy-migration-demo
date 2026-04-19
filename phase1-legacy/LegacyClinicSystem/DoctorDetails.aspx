<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DoctorDetails.aspx.cs" Inherits="LegacyClinicSystem.DoctorDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Doctor Details</h2>
        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label ID="lblFullName" runat="server" AssociatedControlID="lblFullNameValue" CssClass="col-sm-2 control-label">Full Name</asp:Label>
                <div class="col-sm-4">
                    <asp:Label ID="lblFullNameValue" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblSpecialisation" runat="server" AssociatedControlID="lblSpecialisationValue" CssClass="col-sm-2 control-label">Specialisation</asp:Label>
                <div class="col-sm-4">
                    <asp:Label ID="lblSpecialisationValue" runat="server" CssClass="form-control-plaintext"></asp:Label>
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
                <div class="col-sm-offset-2 col-sm-4">
                    <asp:HyperLink ID="lnkBack" runat="server" NavigateUrl="~/Doctors.aspx" CssClass="btn btn-secondary">Back to List</asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>