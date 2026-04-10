<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPatient.aspx.cs" Inherits="LegacyClinicSystem.AddPatient" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Patient</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Add New Patient</h2>
            <table>
                <tr>
                    <td>First Name:</td>
                    <td><asp:TextBox ID="txtFirstName" runat="server" /></td>
                </tr>
                <tr>
                    <td>Last Name:</td>
                    <td><asp:TextBox ID="txtLastName" runat="server" /></td>
                </tr>
                <tr>
                    <td>Date of Birth:</td>
                    <td><asp:TextBox ID="txtDateOfBirth" runat="server" /></td>
                </tr>
                <tr>
                    <td>Phone:</td>
                    <td><asp:TextBox ID="txtPhone" runat="server" /></td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td><asp:TextBox ID="txtEmail" runat="server" /></td>
                </tr>
                <tr>
                    <td>Medical Record Number:</td>
                    <td><asp:TextBox ID="txtMedicalRecordNumber" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnRegister" runat="server" Text="Register Patient" OnClick="btnRegister_Click" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
        </div>
    </form>
</body>
</html>