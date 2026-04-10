using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace LegacyClinicSystem
{
    public partial class Patients : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPatients();
            }
        }

        private void LoadPatients()
        {
            // Anti-pattern: Hardcoded connection string in code-behind
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LegacyClinicDb;Integrated Security=True";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Anti-pattern: Raw ADO.NET with inline SQL query
                    // Anti-pattern: No paging, no optimization - gets all patients
                    string query = "SELECT Id, FirstName, LastName, DateOfBirth, Phone, Email, MedicalRecordNumber FROM Patients";
                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    
                    // Anti-pattern: Direct data binding in code-behind
                    gvPatients.DataSource = dt;
                    gvPatients.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Anti-pattern: No proper error handling
                // In a real app we'd log this, but here we're showing poor practices
                throw; // Let exception bubble up to user
            }
        }
    }
}