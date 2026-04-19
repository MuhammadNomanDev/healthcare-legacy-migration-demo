using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace LegacyClinicSystem
{
    public partial class AppointmentDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get appointment ID from query string
                if (Request.QueryString["id"] != null)
                {
                    LoadAppointmentDetails(Request.QueryString["id"]);
                    // Set edit link URL
                    lnkEdit.NavigateUrl = "~/EditAppointment.aspx?id=" + Request.QueryString["id"];
                }
                else
                {
                    // Redirect back to appointments list if no ID provided
                    Response.Redirect("~/Appointments.aspx");
                }
            }
        }

        private void LoadAppointmentDetails(string appointmentId)
        {
            // Anti-pattern: Hardcoded connection string in code-behind
            string connectionString = @"Data Source=DESKTOP-IH0NJ1K\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Anti-pattern: Raw ADO.NET with inline SQL query
                    string query = @"SELECT a.Id, 
                                    p.FirstName + ' ' + p.LastName AS PatientName,
                                    d.FullName AS DoctorName,
                                    a.AppointmentDate,
                                    a.Reason,
                                    a.Status
                                    FROM Appointments a
                                    INNER JOIN Patients p ON a.PatientId = p.Id
                                    INNER JOIN Doctors d ON a.DoctorId = d.Id
                                    WHERE a.Id = @Id";
                                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", appointmentId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    if (reader.Read())
                    {
                        lblPatientValue.Text = reader["PatientName"].ToString();
                        lblDoctorValue.Text = reader["DoctorName"].ToString();
                        lblDateValue.Text = Convert.ToDateTime(reader["AppointmentDate"]).ToString("yyyy-MM-dd");
                        lblReasonValue.Text = reader["Reason"].ToString();
                        lblStatusValue.Text = reader["Status"].ToString();
                    }
                    else
                    {
                        // Appointment not found, redirect back to list
                        Response.Redirect("~/Appointments.aspx");
                    }
                    
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // Anti-pattern: No proper error handling
                // In a real app we'd log this, but here we're showing poor practices
                // For simplicity, redirect back to appointments list on error
                Response.Redirect("~/Appointments.aspx");
            }
        }
    }
}