-- Patients table
CREATE TABLE Patients (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Phone NVARCHAR(20),
    Email NVARCHAR(100),
    MedicalRecordNumber NVARCHAR(20) UNIQUE NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Doctors table
CREATE TABLE Doctors (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Specialisation NVARCHAR(100),
    Phone NVARCHAR(20),
    Email NVARCHAR(100),
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Appointments table
CREATE TABLE Appointments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    AppointmentDate DATETIME NOT NULL,
    Reason NVARCHAR(200),
    Status NVARCHAR(20) DEFAULT 'Scheduled',
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (PatientId) REFERENCES Patients(Id),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(Id)
);

-- Billing table
CREATE TABLE Billing (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    AppointmentId INT NOT NULL,
    PatientId INT NOT NULL,
    Amount DECIMAL(10,2) NOT NULL,
    Description NVARCHAR(200),
    Status NVARCHAR(20) DEFAULT 'Pending', -- Paid/Unpaid/Pending
    BillingDate DATETIME NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (AppointmentId) REFERENCES Appointments(Id),
    FOREIGN KEY (PatientId) REFERENCES Patients(Id)
);