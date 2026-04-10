using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace LegacyClinicSystem
{
    public partial class Appointments : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAppointments();
            }
        }

        private void LoadAppointments()
        {
            // Anti-pattern: Hardcoded connection string
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LegacyClinicDb;Integrated Security=True";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Anti-pattern: Raw SQL query with JOIN - no optimization
                    // Anti-pattern: No paging, no filtering - gets all appointments
                    string query = @"SELECT a.Id, 
                                          p.FirstName + ' ' + p.LastName as PatientName,
                                          d.FullName as DoctorName,
                                          a.AppointmentDate,
                                          a.Reason,
                                          a.Status
                                   FROM Appointments a
                                   INNER JOIN Patients p ON a.PatientId = p.Id
                                   INNER JOIN Doctors d ON a.DoctorId = d.Id
                                   ORDER BY a.AppointmentDate DESC";
                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    
                    // Anti-pattern: Direct data binding in code-behind
                    gvAppointments.DataSource = dt;
                    gvAppointments.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Anti-pattern: No proper error handling
                // Let exception bubble up to user
                throw;
            }
        }
    }
}