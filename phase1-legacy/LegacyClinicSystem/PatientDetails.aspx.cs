using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace LegacyClinicSystem
{
    public partial class PatientDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get patient ID from query string
                if (Request.QueryString["id"] != null)
                {
                    LoadPatientDetails(Request.QueryString["id"]);
                    // Set edit link URL
                    lnkEdit.NavigateUrl = "~/EditPatient.aspx?id=" + Request.QueryString["id"];
                }
                else
                {
                    // Redirect back to patients list if no ID provided
                    Response.Redirect("~/Patients.aspx");
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
                        lblFirstNameValue.Text = reader["FirstName"].ToString();
                        lblLastNameValue.Text = reader["LastName"].ToString();
                        lblDOBValue.Text = Convert.ToDateTime(reader["DateOfBirth"]).ToString("yyyy-MM-dd");
                        lblPhoneValue.Text = reader["Phone"].ToString();
                        lblEmailValue.Text = reader["Email"].ToString();
                        lblMRNValue.Text = reader["MedicalRecordNumber"].ToString();
                    }
                    else
                    {
                        // Patient not found, redirect back to list
                        Response.Redirect("~/Patients.aspx");
                    }
                    
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // Anti-pattern: No proper error handling
                // In a real app we'd log this, but here we're showing poor practices
                // For simplicity, redirect back to patients list on error
                Response.Redirect("~/Patients.aspx");
            }
        }
    }
}