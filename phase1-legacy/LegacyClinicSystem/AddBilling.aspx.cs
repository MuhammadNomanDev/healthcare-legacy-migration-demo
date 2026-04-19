using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LegacyClinicSystem
{
    public partial class AddBilling : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPatients();
                LoadAppointments();
            }
        }

        private void LoadPatients()
        {
            string connectionString = @"Data Source=DESKTOP-IH0NJ1K\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Id, FirstName + ' ' + LastName AS PatientName FROM Patients";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                ddlPatient.DataSource = reader;
                ddlPatient.DataTextField = "PatientName";
                ddlPatient.DataValueField = "Id";
                ddlPatient.DataBind();
                reader.Close();
            }
            
            // Add a default item at the beginning
            ddlPatient.Items.Insert(0, new ListItem("-- Select Patient --", ""));
        }

        private void LoadAppointments()
        {
            string connectionString = @"Data Source=DESKTOP-IH0NJ1K\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT a.Id, 
                                p.FirstName + ' ' + p.LastName AS PatientName,
                                d.FullName AS DoctorName,
                                a.AppointmentDate
                                FROM Appointments a
                                INNER JOIN Patients p ON a.PatientId = p.Id
                                INNER JOIN Doctors d ON a.DoctorId = d.Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                ddlAppointment.DataSource = reader;
                ddlAppointment.DataTextField = "PatientName"; // We'll show patient name, but we can adjust
                ddlAppointment.DataValueField = "Id";
                ddlAppointment.DataBind();
                reader.Close();
            }
            
            ddlAppointment.Items.Insert(0, new ListItem("-- Select Appointment --", ""));
        }

        protected void btnCreateBill_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-IH0NJ1K\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    string query = @"INSERT INTO Billing (AppointmentId, PatientId, Amount, Description, Status, BillingDate) 
                                     VALUES (@AppointmentId, @PatientId, @Amount, @Description, @Status, GETDATE())";
                                     
                    SqlCommand cmd = new SqlCommand(query, conn);
                    
                    cmd.Parameters.AddWithValue("@AppointmentId", ddlAppointment.SelectedValue);
                    cmd.Parameters.AddWithValue("@PatientId", ddlPatient.SelectedValue);
                    cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedValue);
                    
                    int result = cmd.ExecuteNonQuery();
                    
                    if (result > 0)
                    {
                        lblMessage.Text = "Bill created successfully!";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        
                        // Clear form
                        ddlPatient.ClearSelection();
                        ddlAppointment.ClearSelection();
                        txtAmount.Text = string.Empty;
                        txtDescription.Text = string.Empty;
                        ddlStatus.ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}