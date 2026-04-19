using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace LegacyClinicSystem
{
    public partial class Billing : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBilling();
            }
        }

        private void LoadBilling()
        {
            // Anti-pattern: Hardcoded connection string in code-behind
            string connectionString = @"Data Source=DESKTOP-IH0NJ1K\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Anti-pattern: Raw ADO.NET with inline SQL query
                    // Anti-pattern: No paging, no optimization - gets all billing records
                    string query = @"SELECT b.Id, p.FirstName + ' ' + p.LastName AS PatientName, 
                                    a.AppointmentDate, b.Amount, b.Description, b.Status, b.BillingDate
                                    FROM Billing b
                                    INNER JOIN Appointments a ON b.AppointmentId = a.Id
                                    INNER JOIN Patients p ON b.PatientId = p.Id";
                                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    
                    // Anti-pattern: Direct data binding in code-behind
                    gvBilling.DataSource = dt;
                    gvBilling.DataBind();
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