<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Patients.aspx.cs" Inherits="LegacyClinicSystem.Patients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Patients List</h2>
        <asp:GridView ID="gvPatients" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="DateOfBirth" HeaderText="Date of Birth" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="MedicalRecordNumber" HeaderText="Medical Record #" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>