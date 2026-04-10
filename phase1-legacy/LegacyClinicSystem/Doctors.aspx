<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Doctors.aspx.cs" Inherits="LegacyClinicSystem.Doctors" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Doctors List</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Doctors List</h2>
            <asp:GridView ID="gvDoctors" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                    <asp:BoundField DataField="Specialisation" HeaderText="Specialisation" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>