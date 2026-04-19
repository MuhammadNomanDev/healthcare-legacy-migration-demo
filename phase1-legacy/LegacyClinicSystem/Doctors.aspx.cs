using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace LegacyClinicSystem
{
    public partial class Doctors : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Anti-pattern: Hardcoded data instead of database query initially
                // Later we'll change this to use raw SQL queries
                //LoadDoctorsHardcoded();
                LoadDoctorsFromDatabase();
            }
        }

        private void LoadDoctorsHardcoded()
        {
            // Anti-pattern: Mixing display logic with business logic
            // Anti-pattern: Hardcoded data in code-behind
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("FullName", typeof(string));
            dt.Columns.Add("Specialisation", typeof(string));
            dt.Columns.Add("Phone", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            
            // Hardcoded doctor data
            dt.Rows.Add(1, "Dr. John Smith", "Cardiology", "555-0101", "john.smith@clinic.com");
            dt.Rows.Add(2, "Dr. Sarah Johnson", "Pediatrics", "555-0102", "sarah.johnson@clinic.com");
            dt.Rows.Add(3, "Dr. Michael Brown", "Orthopedics", "555-0103", "michael.brown@clinic.com");
            dt.Rows.Add(4, "Dr. Emily Davis", "Dermatology", "555-0104", "emily.davis@clinic.com");
            dt.Rows.Add(5, "Dr. Robert Wilson", "Neurology", "555-0105", "robert.wilson@clinic.com");
            
            gvDoctors.DataSource = dt;
            gvDoctors.DataBind();
        }
        
        // This method would be used later to replace the hardcoded version
        // Demonstrating the anti-pattern of having multiple ways to do the same thing
        private void LoadDoctorsFromDatabase()
        {
            // Anti-pattern: Hardcoded connection string
            string connectionString = @"Data Source=DESKTOP-IH0NJ1K\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Anti-pattern: Raw SQL query in code-behind
                    string query = "SELECT Id, FullName, Specialisation, Phone, Email FROM Doctors";
                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    
                    gvDoctors.DataSource = dt;
                    gvDoctors.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Anti-pattern: No error handling
                throw;
            }
        }
    }
}