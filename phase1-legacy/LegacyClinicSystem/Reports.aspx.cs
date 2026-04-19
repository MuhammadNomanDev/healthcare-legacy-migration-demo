using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace LegacyClinicSystem
{
    public partial class Reports : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReports();
            }
        }

        private void LoadReports()
        {
            // Anti-pattern: Hardcoded connection string in code-behind
            string connectionString = @"Data Source=DESKTOP-IH0NJ1K\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Total Patients
                    string patientQuery = "SELECT COUNT(*) FROM Patients";
                    SqlCommand patientCmd = new SqlCommand(patientQuery, conn);
                    lblTotalPatients.Text = patientCmd.ExecuteScalar().ToString();
                    
                    // Total Doctors
                    string doctorQuery = "SELECT COUNT(*) FROM Doctors";
                    SqlCommand doctorCmd = new SqlCommand(doctorQuery, conn);
                    lblTotalDoctors.Text = doctorCmd.ExecuteScalar().ToString();
                    
                    // Total Appointments
                    string appointmentQuery = "SELECT COUNT(*) FROM Appointments";
                    SqlCommand appointmentCmd = new SqlCommand(appointmentQuery, conn);
                    lblTotalAppointments.Text = appointmentCmd.ExecuteScalar().ToString();
                    
                    // Total Revenue (sum of paid bills)
                    string revenueQuery = "SELECT ISNULL(SUM(Amount), 0) FROM Billing WHERE Status = 'Paid'";
                    SqlCommand revenueCmd = new SqlCommand(revenueQuery, conn);
                    lblTotalRevenue.Text = string.Format("{0:C}", revenueCmd.ExecuteScalar());
                    
                    // Appointments by Status
                    string appointmentStatusQuery = @"SELECT Status, COUNT(*) AS Count 
                                                    FROM Appointments 
                                                    GROUP BY Status";
                    SqlCommand appointmentStatusCmd = new SqlCommand(appointmentStatusQuery, conn);
                    SqlDataAdapter appointmentStatusAdapter = new SqlDataAdapter(appointmentStatusCmd);
                    DataTable appointmentStatusDt = new DataTable();
                    appointmentStatusAdapter.Fill(appointmentStatusDt);
                    gvAppointmentStatus.DataSource = appointmentStatusDt;
                    gvAppointmentStatus.DataBind();
                    
                    // Billing Status
                    string billingStatusQuery = @"SELECT Status, COUNT(*) AS Count, ISNULL(SUM(Amount), 0) AS Amount 
                                                  FROM Billing 
                                                  GROUP BY Status";
                    SqlCommand billingStatusCmd = new SqlCommand(billingStatusQuery, conn);
                    SqlDataAdapter billingStatusAdapter = new SqlDataAdapter(billingStatusCmd);
                    DataTable billingStatusDt = new DataTable();
                    billingStatusAdapter.Fill(billingStatusDt);
                    gvBillingStatus.DataSource = billingStatusDt;
                    gvBillingStatus.DataBind();
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