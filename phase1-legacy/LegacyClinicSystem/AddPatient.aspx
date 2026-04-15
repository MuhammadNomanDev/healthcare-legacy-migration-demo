<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AddPatient.aspx.cs" Inherits="LegacyClinicSystem.AddPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <h2>Add New Patient</h2>
    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstName" CssClass="col-sm-2 control-label">First Name</asp:Label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="* Required" CssClass="text-danger" Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName" CssClass="col-sm-2 control-label">Last Name</asp:Label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="* Required" CssClass="text-danger" Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="lblDOB" runat="server" AssociatedControlID="txtDateOfBirth" CssClass="col-sm-2 control-label">DOB</asp:Label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDateOfBirth" ErrorMessage="* Required" CssClass="text-danger" Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="lblPhone" runat="server" AssociatedControlID="txtPhone" CssClass="col-sm-2 control-label">Phone</asp:Label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
                <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhone" ValidationExpression="^\\d{10}$" ErrorMessage="* 10‑digit number" CssClass="text-danger" Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" CssClass="col-sm-2 control-label">Email</asp:Label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="^[\\w\\.-]+@[\\w\\.-]+\\.[a-zA-Z]{2,6}$" ErrorMessage="* Invalid email" CssClass="text-danger" Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="lblMRN" runat="server" AssociatedControlID="txtMedicalRecordNumber" CssClass="col-sm-2 control-label">MRN</asp:Label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtMedicalRecordNumber" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvMRN" runat="server" ControlToValidate="txtMedicalRecordNumber" ErrorMessage="* Required" CssClass="text-danger" Display="Dynamic" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-4">
                <asp:Button ID="btnRegister" runat="server" Text="Register Patient" CssClass="btn btn-primary" OnClick="btnRegister_Click" />
            </div>
        </div>
    </div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
    </div>
</asp:Content>
