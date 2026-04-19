using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace LegacyClinicSystem
{
    public partial class EditPatient : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get patient ID from query string
                if (Request.QueryString["id"] != null)
                {
                    LoadPatientDetails(Request.QueryString["id"]);
                }
                else
                {
                    lblMessage.Text = "Patient ID is required.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void LoadPatientDetails(string patientId)
        {
            // Anti-pattern: Hardcoded connection string in code-behind
            string connectionString = @"Data Source=DESKTOP-IH0NJ1K\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Anti-pattern: Raw ADO.NET with inline SQL query
                    string query = "SELECT Id, FirstName, LastName, DateOfBirth, Phone, Email, MedicalRecordNumber FROM Patients WHERE Id = @Id";
                                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", patientId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    if (reader.Read())
                    {
                        txtFirstName.Text = reader["FirstName"].ToString();
                        txtLastName.Text = reader["LastName"].ToString();
                        txtDateOfBirth.Text = Convert.ToDateTime(reader["DateOfBirth"]).ToString("yyyy-MM-dd");
                        txtPhone.Text = reader["Phone"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtMedicalRecordNumber.Text = reader["MedicalRecordNumber"].ToString();
                        // Store patient ID for update
                        ViewState["PatientId"] = patientId;
                    }
                    else
                    {
                        lblMessage.Text = "Patient not found.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // Anti-pattern: No proper error handling
                // In a real app we'd log this, but here we're showing poor practices
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState["PatientId"] == null)
            {
                lblMessage.Text = "Patient ID is missing.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Anti-pattern: Hardcoded connection string in code-behind
            string connectionString = @"Data Source=DESKTOP-IH0NJ1K\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Anti-pattern: Raw ADO.NET with inline SQL query
                    string query = @"UPDATE Patients SET 
                                    FirstName = @FirstName, 
                                    LastName = @LastName, 
                                    DateOfBirth = @DateOfBirth, 
                                    Phone = @Phone, 
                                    Email = @Email, 
                                    MedicalRecordNumber = @MedicalRecordNumber 
                                    WHERE Id = @Id";
                                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    
                    // Anti-pattern: Direct use of user input without validation
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", txtDateOfBirth.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@MedicalRecordNumber", txtMedicalRecordNumber.Text);
                    cmd.Parameters.AddWithValue("@Id", ViewState["PatientId"]);
                    
                    int result = cmd.ExecuteNonQuery();
                    
                    if (result > 0)
                    {
                        lblMessage.Text = "Patient updated successfully!";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "Failed to update patient.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
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