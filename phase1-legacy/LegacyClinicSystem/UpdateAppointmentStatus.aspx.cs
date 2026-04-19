using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace LegacyClinicSystem
{
    public partial class UpdateAppointmentStatus : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get appointment ID from query string
                if (Request.QueryString["id"] != null)
                {
                    LoadAppointmentDetails(Request.QueryString["id"]);
                }
                else
                {
                    lblMessage.Text = "Appointment ID is required.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
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
                        lblCurrentStatusValue.Text = reader["Status"].ToString();
                        // Store appointment ID for update
                        ViewState["AppointmentId"] = appointmentId;
                    }
                    else
                    {
                        lblMessage.Text = "Appointment not found.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // Anti-pattern: No proper error handling
                // In a real app we'd log this, but here we're showing poor practices
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState["AppointmentId"] == null)
            {
                lblMessage.Text = "Appointment ID is missing.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Anti-pattern: Hardcoded connection string in code-behind
            string connectionString = @"Data Source=DESKTOP-IH0NJ1K\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Anti-pattern: Raw ADO.NET with inline SQL query
                    string query = "UPDATE Appointments SET Status = @Status WHERE Id = @Id";
                                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", ddlNewStatus.SelectedValue);
                    cmd.Parameters.AddWithValue("@Id", ViewState["AppointmentId"]);
                    
                    int result = cmd.ExecuteNonQuery();
                    
                    if (result > 0)
                    {
                        lblMessage.Text = "Appointment status updated successfully!";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        
                        // Update current status label
                        lblCurrentStatusValue.Text = ddlNewStatus.SelectedValue;
                    }
                    else
                    {
                        lblMessage.Text = "Failed to update appointment status.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                // Anti-pattern: No proper error handling - let exception bubble up or show raw error
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                // In a real app, we might log this, but here we're demonstrating poor practices
            }
        }
    }
}