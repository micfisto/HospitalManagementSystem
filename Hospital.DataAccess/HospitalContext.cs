using Microsoft.EntityFrameworkCore;
using Models.Departments;
using Models.Diagnoses;
using Models.DoctorAppointments;
using Models.Employees;
using Models.Patients;

namespace Hospital.DataAccess;

public class HospitalContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<DoctorAppointment> DoctorAppointments { get; set; }
    public DbSet<Diagnosis> Diagnoses { get; set; }
    
    public DbSet<DepartmentType> DepartmentTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=hospital.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasMany(department => department.Employees)
            .WithOne(employee => employee.Department).HasForeignKey(employee => employee.DepartmentId);

        modelBuilder.Entity<Doctor>().HasMany(doctor => doctor.Specialization)
            .WithMany(specialization => specialization.Doctors);

        modelBuilder.Entity<Nurse>().HasMany(nurse => nurse.Qualifications)
            .WithMany(qualification => qualification.Nurses);

        modelBuilder.Entity<Patient>().HasOne(patient => patient.Department).WithMany(department => department.Patients)
            .HasForeignKey(patient => patient.DepartmentId);

        modelBuilder.Entity<Patient>().HasOne(patient => patient.MedicalRecord)
            .WithOne(medicalRecord => medicalRecord.Patient)
            .HasForeignKey<MedicalRecord>(medicalRecord => medicalRecord.PatientId);

        modelBuilder.Entity<DoctorAppointment>().HasOne(appointment => appointment.Patient)
            .WithMany(patient => patient.DoctorAppointments).HasForeignKey(appointment => appointment.PatientId);

        modelBuilder.Entity<DoctorAppointment>().HasOne(appointment => appointment.Doctor)
            .WithMany(doctor => doctor.DoctorAppointments).HasForeignKey(appointment => appointment.DoctorId);

        modelBuilder.Entity<Treatment>().HasOne(treatment => treatment.Patient).WithMany(patient => patient.Treatments)
            .HasForeignKey(treatment => treatment.PatientId);

        modelBuilder.Entity<Treatment>().HasOne(treatment => treatment.Nurse).WithMany(nurse => nurse.Treatments)
            .HasForeignKey(treatment => treatment.NurseId);

        modelBuilder.Entity<Patient>().Property(patient => patient.Sex).HasConversion<string>(
            value => value == Sex.Male ? "М" : "Ж",
            value => value == "М" ? Sex.Male : Sex.Female);
        modelBuilder.Entity<Diagnosis>().HasMany(diagnosis => diagnosis.Symptoms)
            .WithMany(symptom => symptom.Diagnoses);

        modelBuilder.Entity<Diagnosis>().HasMany(diagnosis => diagnosis.MedicalRecords)
            .WithMany(medicalRecord => medicalRecord.Diagnoses);

        modelBuilder.Entity<MedicalRecord>().HasOne(medicalRecord => medicalRecord.Epicrisis)
            .WithOne(epicrisis => epicrisis.MedicalRecord)
            .HasForeignKey<Epicrisis>(epicrisis => epicrisis.MedicalRecordId);

        modelBuilder.Entity<MedicalRecord>().HasMany(medicalRecord => medicalRecord.Treatments)
            .WithOne(treatment => treatment.MedicalRecord).HasForeignKey(treatment => treatment.MedicalRecordId);

        modelBuilder.Entity<MedicalRecord>().HasMany(medicalRecord => medicalRecord.DoctorAppointments)
            .WithOne(appointment => appointment.MedicalRecord).HasForeignKey(appointment => appointment.MedicalRecordId);

        modelBuilder.Entity<Department>().HasOne(department => department.DepartmentType)
            .WithMany(departmentType => departmentType.Departments).HasForeignKey(department=>department.DepartmentTypeId);
        
        base.OnModelCreating(modelBuilder);
    }
}