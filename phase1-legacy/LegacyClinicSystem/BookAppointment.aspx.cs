using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LegacyClinicSystem
{
    public partial class BookAppointment : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPatients();
                LoadDoctors();
            }
        }

        private void LoadPatients()
        {
            // Anti-pattern: Hardcoded connection string
            string connectionString = @"Data Source=DESKTOP-IH0NJ1K\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Anti-pattern: Raw SQL query
                    string query = "SELECT Id, FirstName + ' ' + LastName as FullName FROM Patients ORDER BY LastName, FirstName";
                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    
                    ddlPatients.DataSource = dt;
                    ddlPatients.DataTextField = "FullName";
                    ddlPatients.DataValueField = "Id";
                    ddlPatients.DataBind();
                    
                    // Add default item
                    ddlPatients.Items.Insert(0, new ListItem("-- Select Patient --", "0"));
                }
            }
            catch (Exception ex)
            {
                // Anti-pattern: No error handling
                throw;
            }
        }

        private void LoadDoctors()
        {
            // Anti-pattern: Hardcoded connection string
            string connectionString = @"Data Source=DESKTOP-IH0NJ1K\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Anti-pattern: Raw SQL query
                    string query = "SELECT Id, FullName FROM Doctors ORDER BY FullName";
                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    
                    ddlDoctors.DataSource = dt;
                    ddlDoctors.DataTextField = "FullName";
                    ddlDoctors.DataValueField = "Id";
                    ddlDoctors.DataBind();
                    
                    // Add default item
                    ddlDoctors.Items.Insert(0, new ListItem("-- Select Doctor --", "0"));
                }
            }
            catch (Exception ex)
            {
                // Anti-pattern: No error handling
                throw;
            }
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            // Anti-pattern: Business logic directly in code-behind
            // Anti-pattern: No input validation - accept anything
            // Anti-pattern: Raw ADO.NET with inline SQL
            // Anti-pattern: Hardcoded connection string
            // Anti-pattern: No error handling - raw exceptions bubble up
            
            // Validate that patient and doctor are selected
            if (ddlPatients.SelectedValue == "0" || ddlDoctors.SelectedValue == "0")
            {
                lblMessage.Text = "Please select both a patient and a doctor.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }
            
            string connectionString = @"Data Source=DESKTOP-IH0NJ1K\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // Anti-pattern: Inline SQL query
                    string query = @"INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Reason, Status, CreatedAt) 
                                    VALUES (@PatientId, @DoctorId, @AppointmentDate, @Reason, @Status, GETDATE())";
                                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    
                    // Anti-pattern: Direct use of user input without proper validation
                    cmd.Parameters.AddWithValue("@PatientId", ddlPatients.SelectedValue);
                    cmd.Parameters.AddWithValue("@DoctorId", ddlDoctors.SelectedValue);
                    cmd.Parameters.AddWithValue("@AppointmentDate", txtAppointmentDate.Text);
                    cmd.Parameters.AddWithValue("@Reason", txtReason.Text);
                    cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedValue);
                    
                    int result = cmd.ExecuteNonQuery();
                    
                    if (result > 0)
                    {
                        lblMessage.Text = "Appointment booked successfully!";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        
                        // Anti-pattern: Clearing form in code-behind
                        ddlPatients.SelectedIndex = 0;
                        ddlDoctors.SelectedIndex = 0;
                        txtAppointmentDate.Text = string.Empty;
                        txtReason.Text = string.Empty;
                        ddlStatus.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Anti-pattern: No proper error handling
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}