using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace LegacyClinicSystem
{
    public partial class AddPatient : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // No validation or security checks
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Anti-pattern: Business logic directly in code-behind
            // Anti-pattern: No input validation - accept anything
            // Anti-pattern: Raw ADO.NET with inline SQL
            // Anti-pattern: Hardcoded connection string
            // Anti-pattern: No error handling - raw exceptions bubble up
            
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LegacyClinicDb;Integrated Security=True";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Anti-pattern: Inline SQL query with string concatenation (though using parameters here, still inline)
                    string query = @"INSERT INTO Patients (FirstName, LastName, DateOfBirth, Phone, Email, MedicalRecordNumber, CreatedAt) 
                                    VALUES (@FirstName, @LastName, @DateOfBirth, @Phone, @Email, @MedicalRecordNumber, GETDATE())";
                                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    
                    // Anti-pattern: Direct use of user input without validation
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", txtDateOfBirth.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@MedicalRecordNumber", txtMedicalRecordNumber.Text);
                    
                    int result = cmd.ExecuteNonQuery();
                    
                    if (result > 0)
                    {
                        lblMessage.Text = "Patient registered successfully!";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        
                        // Anti-pattern: Clearing form in code-behind instead of using proper patterns
                        txtFirstName.Text = string.Empty;
                        txtLastName.Text = string.Empty;
                        txtDateOfBirth.Text = string.Empty;
                        txtPhone.Text = string.Empty;
                        txtEmail.Text = string.Empty;
                        txtMedicalRecordNumber.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                // Anti-pattern: No proper error handling - let exception bubble up or show raw error
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                // In a real app, we might log this, but here we're demonstrating poor practices
            }
        }
    }
}