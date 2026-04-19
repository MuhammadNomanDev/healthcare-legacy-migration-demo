using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace LegacyClinicSystem
{
    public partial class DoctorDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get doctor ID from query string
                if (Request.QueryString["id"] != null)
                {
                    LoadDoctorDetails(Request.QueryString["id"]);
                    // Set edit link URL
                   // lnkEdit.NavigateUrl = "~/EditDoctor.aspx?id=" + Request.QueryString["id"];
                }
                else
                {
                    // Redirect back to doctors list if no ID provided
                    Response.Redirect("~/Doctors.aspx");
                }
            }
        }

        private void LoadDoctorDetails(string doctorId)
        {
            // Anti-pattern: Hardcoded connection string in code-behind
            string connectionString = @"Data Source=DESKTOP-IH0NJ1K\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Anti-pattern: Raw ADO.NET with inline SQL query
                    string query = "SELECT Id, FullName, Specialisation, Phone, Email FROM Doctors WHERE Id = @Id";
                                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", doctorId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    if (reader.Read())
                    {
                        lblFullNameValue.Text = reader["FullName"].ToString();
                        lblSpecialisationValue.Text = reader["Specialisation"].ToString();
                        lblPhoneValue.Text = reader["Phone"].ToString();
                        lblEmailValue.Text = reader["Email"].ToString();
                    }
                    else
                    {
                        // Doctor not found, redirect back to list
                        Response.Redirect("~/Doctors.aspx");
                    }
                    
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // Anti-pattern: No proper error handling
                // In a real app we'd log this, but here we're showing poor practices
                // For simplicity, redirect back to doctors list on error
                Response.Redirect("~/Doctors.aspx");
            }
        }
    }
}