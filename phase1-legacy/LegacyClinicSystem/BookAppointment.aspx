<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookAppointment.aspx.cs" Inherits="LegacyClinicSystem.BookAppointment" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Appointment</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Book Appointment</h2>
            <table>
                <tr>
                    <td>Patient:</td>
                    <td>
                        <asp:DropDownList ID="ddlPatients" runat="server">
                            <!-- Will be populated in code-behind -->
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Doctor:</td>
                    <td>
                        <asp:DropDownList ID="ddlDoctors" runat="server">
                            <!-- Will be populated in code-behind -->
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Appointment Date:</td>
                    <td><asp:TextBox ID="txtAppointmentDate" runat="server" /></td>
                </tr>
                <tr>
                    <td>Reason:</td>
                    <td><asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Rows="4" Columns="30" /></td>
                </tr>
                <tr>
                    <td>Status:</td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" runat="server">
                            <asp:ListItem Value="Scheduled">Scheduled</asp:ListItem>
                            <asp:ListItem Value="Completed">Completed</asp:ListItem>
                            <asp:ListItem Value="Cancelled">Cancelled</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnBook" runat="server" Text="Book Appointment" OnClick="btnBook_Click" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
        </div>
    </form>
</body>
</html>