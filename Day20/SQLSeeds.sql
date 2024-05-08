-- Create database if not exists
CREATE DATABASE DoctorsAppointmentManager;
GO
-- Use the database
USE DoctorsAppointmentManager;
GO
-- Create Doctor table
CREATE TABLE Doctor (
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(20) NOT NULL,
    ContactNumber VARCHAR(20) NOT NULL,
    Email VARCHAR(20) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Age AS DATEDIFF(YEAR, DateOfBirth, GETDATE()),
    Address NVARCHAR(255) NOT NULL,
    Experience INT CHECK (Experience >= 0 AND Experience <= 48)
);

-- Create Qualification table
CREATE TABLE Qualification (
    DoctorId INT,
    Qualification NVARCHAR(255),
    FOREIGN KEY (DoctorId) REFERENCES Doctor(Id)
);

-- Create Specialization table
CREATE TABLE Specialization (
    DoctorId INT,
    Specialization NVARCHAR(255),
    FOREIGN KEY (DoctorId) REFERENCES Doctor(Id)
);

-- Create Patient table
CREATE TABLE Patient (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(255) NOT NULL,
    ContactNumber NVARCHAR(20) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Age AS DATEDIFF(YEAR, DateOfBirth, GETDATE()),
    Address NVARCHAR(255) NOT NULL,
    InsuranceProvider NVARCHAR(255) NOT NULL,
    MedicalHistory NVARCHAR(MAX) NOT NULL
);

-- Create Appointment table
CREATE TABLE Appointment (
    Id INT PRIMARY KEY IDENTITY,
    DoctorId INT,
    PatientId INT,
    AppointmentDateTime DATETIME NOT NULL,
    Purpose NVARCHAR(MAX),
    FOREIGN KEY (DoctorId) REFERENCES Doctor(Id),
    FOREIGN KEY (PatientId) REFERENCES Patient(Id)
);

GO

-- Insert data into Doctor table
INSERT INTO Doctor (Name, ContactNumber, Email, DateOfBirth, Address, Experience)
VALUES ('Dr. John Smith', '+1234567890', 'john.smith@example.com', '1980-05-15', '123 Main St, City', 20);

-- Insert data into Qualification table
INSERT INTO Qualification (DoctorId, Qualification)
VALUES (1, 'MD'), (2, 'PhD');

-- Insert data into Specialization table
INSERT INTO Specialization (DoctorId, Specialization)
VALUES (1, 'Cardiology'), (2, 'Neurology');

-- Insert data into Patient table
INSERT INTO Patient (Name, ContactNumber, Email, DateOfBirth, Address, InsuranceProvider, MedicalHistory)
VALUES ('Alice Johnson', '+1987654321', 'alice.johnson@example.com', '1990-10-20', '456 Elm St, City', 'ABC Insurance', 'Hypertension, Allergies');

-- Insert data into Appointment table
INSERT INTO Appointment (DoctorId, PatientId, AppointmentDateTime, Purpose)
VALUES (1, 1, '2024-05-15 10:00:00', 'Regular check-up');
