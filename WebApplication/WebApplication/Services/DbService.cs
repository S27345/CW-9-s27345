using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.DTOs;
using WebApplication.Models;

namespace WebApplication.Services;

public interface IDbService
{
    public Task<ICollection<GetPatientDto>> GetPatient(int id);
}

public class DbService(AppDbContext data) : IDbService
{
    public async Task<ICollection<GetPatientDto>> GetPatient(int id)
    {
        return await data.Patients.Select(pt => new GetPatientDto
        {
            IdPatient = pt.IdPatient,
            FirstName = pt.FirstName,
            LastName = pt.LastName,
            Birthdate = pt.Birthdate,
            Prescriptions = pt.Prescriptions.Select(pr => new GetpatientPrescriptionDto
            {
                IdPrescription = pr.IdPrescription,
                Date = pr.Date,
                DueDate = pr.DueDate,
                PrescriptionMedicaments = pr.PrescriptionMedicaments.Select(prm => new GetPrescriptionMedicamentDto
                {
                    IdMedicament = prm.IdMedicament,
                    Dose = prm.Dose,
                    Details = prm.Details,
                    Medicament = new GetMedicamentDto
                    {
                        Name = prm.Medicament.Name,
                        Description = prm.Medicament.Description
                    }
                }).ToList(),
                Doctor = new GetDoctorDto
                {
                    IdDoctor = pr.Doctor.IdDoctor,
                    FirstName = pr.Doctor.FirstName
                }
            }).ToList(),
        }).Where(pt => pt.IdPatient == id).ToListAsync();
    }
}