using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace LegacyClinicSystem
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDashboardCounts();
            }
        }

        private void LoadDashboardCounts()
        {
            // Anti-pattern: Hardcoded connection string in code-behind
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LegacyClinicDb;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Anti-pattern: Raw SQL queries for dashboard
                    string patientQuery = "SELECT COUNT(*) FROM Patients";
                    SqlCommand patientCmd = new SqlCommand(patientQuery, conn);
                    int patientCount = (int)patientCmd.ExecuteScalar();
                    lblPatientCount.Text = $"Patients: {patientCount}";

                    // Anti-pattern: Raw SQL query for today's appointments
                    string appointmentQuery = "SELECT COUNT(*) FROM Appointments WHERE CAST(AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)";
                    SqlCommand appointmentCmd = new SqlCommand(appointmentQuery, conn);
                    int appointmentCount = (int)appointmentCmd.ExecuteScalar();
                    lblAppointmentCount.Text = $"Appointments Today: {appointmentCount}";
                }
            }
            catch (Exception ex)
            {
                // Anti-pattern: No error handling - let exceptions bubble up
                throw ex;
            }
        }
    }
}