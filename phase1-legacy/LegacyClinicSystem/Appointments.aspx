<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Appointments.aspx.cs" Inherits="LegacyClinicSystem.Appointments" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Appointments List</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Appointments List</h2>
            <asp:GridView ID="gvAppointments" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="PatientName" HeaderText="Patient" />
                    <asp:BoundField DataField="DoctorName" HeaderText="Doctor" />
                    <asp:BoundField DataField="AppointmentDate" HeaderText="Appointment Date" />
                    <asp:BoundField DataField="Reason" HeaderText="Reason" />
                    <asp:BoundField DataField="Status" HeaderText="Status" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>