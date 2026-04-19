<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Doctors.aspx.cs" Inherits="LegacyClinicSystem.Doctors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Doctors List</h2>
        <div class="card">
            <div class="card-header">
                <h3 class="card-title">Doctors List</h3>
            </div>
            <div class="card-body">
                <asp:GridView ID="gvDoctors" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false" AllowPaging="true" PageSize="10"  DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
                        <asp:BoundField DataField="FullName" HeaderText="Full Name" SortExpression="FullName" />
                        <asp:BoundField DataField="Specialisation" HeaderText="Specialisation" SortExpression="Specialisation" />
                        <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:TemplateField HeaderText="View Details">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkViewDetails" runat="server" Text="View Details" PostBackUrl='<%# "~/DoctorDetails.aspx?Id=" + Eval("Id") %>' CssClass="btn btn-sm btn-info me-1"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pagination" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
