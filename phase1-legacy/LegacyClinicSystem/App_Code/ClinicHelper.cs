using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace LegacyClinicSystem
{
    /// <summary>
    /// God class anti-pattern: This class does everything - database connections, 
    /// business logic, string formatting, validation (none), and more.
    /// Violates Single Responsibility Principle and Separation of Concerns.
    /// </summary>
    public static class ClinicHelper
    {
        // Hardcoded connection string (anti-pattern)
        private static readonly string ConnectionString = 
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LegacyClinicDb;Integrated Security=True";

        // Database connection method - mixes data access with other concerns
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        // Patient registration method - mixes validation, business logic, and data access
        public static int RegisterPatient(string firstName, string lastName, string dob, 
                                        string phone, string email, string mrn)
        {
            // No input validation - accept anything (anti-pattern)
            // Business logic mixed with data access
            
            using (SqlConnection conn = GetConnection())
            {
                string query = @"INSERT INTO Patients (FirstName, LastName, DateOfBirth, Phone, Email, MedicalRecordNumber) 
                                VALUES (@FirstName, @LastName, @DateOfBirth, @Phone, @Email, @MedicalRecordNumber);
                                SELECT SCOPE_IDENTITY();";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@DateOfBirth", dob);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@MedicalRecordNumber", mrn);
                
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Get all patients method - no paging, no optimization
        public static DataTable GetAllPatients()
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT Id, FirstName, LastName, DateOfBirth, Phone, Email, MedicalRecordNumber FROM Patients";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Get patient by ID method
        public static DataTable GetPatientById(int patientId)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT * FROM Patients WHERE Id = @Id";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@Id", patientId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Appointment booking method - mixes validation, business logic, and data access
        public static int BookAppointment(int patientId, int doctorId, string appointmentDate, 
                                        string reason, string status)
        {
            // No validation of dates, availability, or input (anti-pattern)
            
            using (SqlConnection conn = GetConnection())
            {
                string query = @"INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Reason, Status) 
                                VALUES (@PatientId, @DoctorId, @AppointmentDate, @Reason, @Status);
                                SELECT SCOPE_IDENTITY();";
                
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PatientId", patientId);
                cmd.Parameters.AddWithValue("@DoctorId", doctorId);
                cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                cmd.Parameters.AddWithValue("@Reason", reason);
                cmd.Parameters.AddWithValue("@Status", status);
                
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Get appointments method - no filtering, no optimization
        public static DataTable GetAllAppointments()
        {
            using (SqlConnection conn = GetConnection())
            {
                // Raw SQL JOIN - mixing concerns
                string query = @"SELECT a.Id, p.FirstName + ' ' + p.LastName as PatientName, 
                                      d.FullName as DoctorName, a.AppointmentDate, a.Reason, a.Status
                               FROM Appointments a
                               INNER JOIN Patients p ON a.PatientId = p.Id
                               INNER JOIN Doctors d ON a.DoctorId = d.Id
                               ORDER BY a.AppointmentDate DESC";
                
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Update appointment status method
        public static bool UpdateAppointmentStatus(int appointmentId, string status)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "UPDATE Appointments SET Status = @Status WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Id", appointmentId);
                
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // String formatting method - shouldn't be in a data helper class
        public static string FormatPhoneNumber(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return string.Empty;
            
            // Simple formatting logic mixed in god class
            string cleaned = new string(System.Text.RegularExpressions.Regex.Match(phone, @"[\d]+").Value);
            if (cleaned.Length == 10)
                return $"({cleaned.Substring(0, 3)}) {cleaned.Substring(3, 3)}-{cleaned.Substring(6, 4)}";
            return phone;
        }

        // Email validation method - basic validation mixed in god class
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
                
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Calculate age method - business logic in data helper
        public static int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (DateTime.Today < dateOfBirth.AddYears(age))
                age--;
            return age;
        }

        // Get dashboard statistics method
        public static DataTable GetDashboardStats()
        {
            using (SqlConnection conn = GetConnection())
            {
                // Multiple queries in one method - no separation
                string query = @"SELECT 
                                    (SELECT COUNT(*) FROM Patients) as TotalPatients,
                                    (SELECT COUNT(*) FROM Appointments WHERE CAST(AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)) as TodaysAppointments,
                                    (SELECT COUNT(*) FROM Appointments WHERE Status = 'Scheduled') as ScheduledAppointments,
                                    (SELECT COUNT(*) FROM Doctors) as TotalDoctors";
                
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        // Method that does too many things - god class anti-pattern
        public static void ProcessPatientData(string patientData)
        {
            // This method does: parsing, validation, database operations, logging, etc.
            // All mixed together in one place
            
            if (string.IsNullOrEmpty(patientData))
                return;
                
            // Parse patient data (should be separate)
            string[] parts = patientData.Split('|');
            if (parts.Length >= 6)
            {
                // Validate data (should be separate)
                bool isValid = !string.IsNullOrEmpty(parts[0]) && !string.IsNullOrEmpty(parts[1]);
                
                if (isValid)
                {
                    // Database operation (should be separate)
                    RegisterPatient(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5]);
                    
                    // Logging (should be separate)
                    System.Diagnostics.Debug.WriteLine($"Patient registered: {parts[0]} {parts[1]}");
                }
            }
        }
    }
}