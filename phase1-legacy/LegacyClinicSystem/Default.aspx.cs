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
            string connectionString = @"Data Source=DESKTOP-IH0NJ1K\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string patientQuery = "SELECT COUNT(*) FROM Patients";
                    SqlCommand patientCmd = new SqlCommand(patientQuery, conn);
                    int patientCount = (int)patientCmd.ExecuteScalar();
                    lblPatientCount.Text = patientCount.ToString();

                    string doctorQuery = "SELECT COUNT(*) FROM Doctors";
                    SqlCommand doctorCmd = new SqlCommand(doctorQuery, conn);
                    int doctorCount = (int)doctorCmd.ExecuteScalar();
                    lblDoctorCount.Text = doctorCount.ToString();

                    string appointmentQuery = "SELECT COUNT(*) FROM Appointments";
                    SqlCommand appointmentCmd = new SqlCommand(appointmentQuery, conn);
                    int appointmentCount = (int)appointmentCmd.ExecuteScalar();
                    lblAppointmentCount.Text = appointmentCount.ToString();

                    string todayAppointmentQuery = "SELECT COUNT(*) FROM Appointments WHERE CAST(AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)";
                    SqlCommand todayAppointmentCmd = new SqlCommand(todayAppointmentQuery, conn);
                    int todayAppointmentCount = (int)todayAppointmentCmd.ExecuteScalar();
                    lblTodayAppointments.Text = todayAppointmentCount.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}