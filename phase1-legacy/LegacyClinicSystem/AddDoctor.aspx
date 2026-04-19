<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddDoctor.aspx.cs" Inherits="LegacyClinicSystem.AddDoctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Add New Doctor</h2>
        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label ID="lblFullName" runat="server" AssociatedControlID="txtFullName" CssClass="col-sm-2 control-label">Full Name</asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ControlToValidate="txtFullName" ErrorMessage="* Required" CssClass="text-danger" Display="Dynamic" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblSpecialisation" runat="server" AssociatedControlID="txtSpecialisation" CssClass="col-sm-2 control-label">Specialisation</asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtSpecialisation" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblPhone" runat="server" AssociatedControlID="txtPhone" CssClass="col-sm-2 control-label">Phone</asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" CssClass="col-sm-2 control-label">Email</asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-4">
                    <asp:Button ID="btnRegister" runat="server" Text="Register Doctor" CssClass="btn btn-primary" OnClick="btnRegister_Click" />
                </div>
            </div>
        </div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
    </div>
</asp:Content>