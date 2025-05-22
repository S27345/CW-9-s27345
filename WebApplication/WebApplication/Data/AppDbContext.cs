using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Data;

public class AppDbContext : DbContext
{
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var Medicament = new Medicament
        {
            IdMedicament = 1,
            Name = "Medicament",
            Description = "Take in case of a \"MAS\" induced headache",
            Type = "PainKiller",
        };

        var Doctor = new Doctor
        {
            IdDoctor = 1,
            FirstName = "Doctor",
            LastName = "Doctor",
            Email = "doctor@ihavegreatnamingconventions.com"
        };

        var Patient = new Patient
        {
            IdPatient = 1,
            FirstName = "Patient",
            LastName = "Patient",
            Email = "Patient@ihavegreatnamingconventions.com"
        };

        var Prescription = new Prescription
        {
            IdPrescription = 1,
            Date = DateOnly.FromDateTime(DateTime.Now),
            DueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(30)),
            IdPatient = 1,
            IdDoctor = 1,
        };

        var PrescriptionMedicament = new PrescriptionMedicament
        {
            IdMedicament = 1,
            IdPrescription = 1,
            Dose = 3,
            Details = "Amazing details here"
        };

        modelBuilder.Entity<Doctor>().HasData(Doctor);
        modelBuilder.Entity<Patient>().HasData(Patient);
        modelBuilder.Entity<Medicament>().HasData(Medicament);
        modelBuilder.Entity<Prescription>().HasData(Prescription);
        modelBuilder.Entity<PrescriptionMedicament>().HasData(PrescriptionMedicament);

    }
}