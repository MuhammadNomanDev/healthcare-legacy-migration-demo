<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LegacyClinicSystem.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Clinic Management System</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Clinic Management System</h1>
            <asp:Label ID="lblPatientCount" runat="server" Text="Patients: "></asp:Label><br />
            <asp:Label ID="lblAppointmentCount" runat="server" Text="Appointments Today: "></asp:Label>
        </div>
    </form>
</body>
</html>