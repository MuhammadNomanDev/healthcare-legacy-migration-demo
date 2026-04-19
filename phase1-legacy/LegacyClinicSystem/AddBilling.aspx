<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddBilling.aspx.cs" Inherits="LegacyClinicSystem.AddBilling" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Add New Bill</h2>
        <div class="card">
            <div class="card-header">
                <h3 class="card-title">Add New Bill</h3>
            </div>
            <div class="card-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label ID="lblPatient" runat="server" AssociatedControlID="ddlPatient" CssClass="col-sm-2 control-label">Patient</asp:Label>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="ddlPatient" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfvPatient" runat="server" ControlToValidate="ddlPatient" InitialValue="" ErrorMessage="* Required" CssClass="text-danger" Display="Dynamic" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblAppointment" runat="server" AssociatedControlID="ddlAppointment" CssClass="col-sm-2 control-label">Appointment</asp:Label>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="ddlAppointment" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfvAppointment" runat="server" ControlToValidate="ddlAppointment" InitialValue="" ErrorMessage="* Required" CssClass="text-danger" Display="Dynamic" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblAmount" runat="server" AssociatedControlID="txtAmount" CssClass="col-sm-2 control-label">Amount</asp:Label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfvAmount" runat="server" ControlToValidate="txtAmount" ErrorMessage="* Required" CssClass="text-danger" Display="Dynamic" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblDescription" runat="server" AssociatedControlID="txtDescription" CssClass="col-sm-2 control-label">Description</asp:Label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblStatus" runat="server" AssociatedControlID="ddlStatus" CssClass="col-sm-2 control-label">Status</asp:Label>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                <asp:ListItem Value="Pending">Pending</asp:ListItem>
                                <asp:ListItem Value="Paid">Paid</asp:ListItem>
                                <asp:ListItem Value="Unpaid">Unpaid</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-4">
                            <asp:Button ID="btnCreateBill" runat="server" Text="Create Bill" CssClass="btn btn-primary" OnClick="btnCreateBill_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
    </div>
</asp:Content>