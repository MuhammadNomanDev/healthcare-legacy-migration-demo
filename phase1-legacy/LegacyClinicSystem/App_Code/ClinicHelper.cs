using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace LegacyClinicSystem
{
    public static class ClinicHelper
    {
        private static readonly string ConnectionString =
            @"Data Source=DESKTOP-IH0NJ1K\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static int RegisterPatient(string firstName, string lastName, string dob,
                                        string phone, string email, string mrn)
        {
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

        public static int BookAppointment(int patientId, int doctorId, string appointmentDate,
                                        string reason, string status)
        {
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

        public static DataTable GetAllAppointments()
        {
            using (SqlConnection conn = GetConnection())
            {
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

        public static string FormatPhoneNumber(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return string.Empty;

            string cleaned = System.Text.RegularExpressions.Regex.Match(phone, @"[\d]+").Value;

            if (cleaned.Length == 10)
                return string.Format("({0}) {1}-{2}",
                    cleaned.Substring(0, 3),
                    cleaned.Substring(3, 3),
                    cleaned.Substring(6, 4));

            return phone;
        }

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

        public static int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Today.Year - dateOfBirth.Year;
            if (DateTime.Today < dateOfBirth.AddYears(age))
                age--;
            return age;
        }

        public static DataTable GetDashboardStats()
        {
            using (SqlConnection conn = GetConnection())
            {
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

        public static void ProcessPatientData(string patientData)
        {
            if (string.IsNullOrEmpty(patientData))
                return;

            string[] parts = patientData.Split('|');
            if (parts.Length >= 6)
            {
                bool isValid = !string.IsNullOrEmpty(parts[0]) && !string.IsNullOrEmpty(parts[1]);

                if (isValid)
                {
                    RegisterPatient(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5]);

                    System.Diagnostics.Debug.WriteLine(
                        string.Format("Patient registered: {0} {1}", parts[0], parts[1])
                    );
                }
            }
        }
    }
}