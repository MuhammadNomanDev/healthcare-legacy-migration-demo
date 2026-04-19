<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Patients.aspx.cs" Inherits="LegacyClinicSystem.Patients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2 class="mb-4">Patients List</h2>
        <div class="card">
            <div class="card-header">
                <h3 class="card-title">Patients List</h3>
            </div>
            <div class="card-body">
                <asp:GridView ID="gvPatients" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" AllowSorting="true" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                        <asp:BoundField DataField="DateOfBirth" HeaderText="DOB" DataFormatString="{0:yyyy-MM-dd}" SortExpression="DateOfBirth" />
                        <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                        <asp:BoundField DataField="MedicalRecordNumber" HeaderText="MRN" SortExpression="MedicalRecordNumber" />
                        <asp:TemplateField HeaderText="View Details">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkViewDetails" runat="server" Text="View Details" PostBackUrl='<%# "~/PatientDetails.aspx?Id=" + Eval("Id") %>' CssClass="btn btn-sm btn-info me-1"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" PostBackUrl='<%# "~/EditPatient.aspx?Id=" + Eval("Id") %>' CssClass="btn btn-sm btn-success me-1"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pagination" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
