using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.DTOs;
using WebApplication.Models;

namespace WebApplication.Services;

public interface IDbService
{
    public Task<ICollection<GetPatientDto>> GetPatient(int id);
    public Task CreatePrescription(PrescriptionCreateDTO prescription);
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

    public async Task CreatePrescription(PrescriptionCreateDTO fromRequest)
    {
        if (fromRequest.Medicaments.Count > 10)
        {
            throw new Exception("Too many Medicaments");
        }

        if (fromRequest.DueDate < fromRequest.Date)
        {
            throw new Exception("Due date cannot be greater than the current date");
        }
        
        var MedDTO = fromRequest.Medicaments.Select(m => m.IdMedicament).ToList();
        var MedDB = await data.Medicaments
            .Where(m => MedDTO.Contains(m.IdMedicament))
            .Select(m => m.IdMedicament).ToListAsync();
        var MedCheck = MedDTO.Except(MedDB).ToList();
        if (MedCheck.Any())
        {
            throw new Exception("No Medicaments");
        }

        var DocDTO = fromRequest.Doctor = new DoctorDto
        {
            IdDoctor = fromRequest.Doctor.IdDoctor,
        };
        var DocDB = await data.Doctors
            .Where(d => DocDTO.IdDoctor == d.IdDoctor)
            .Select(d => d.IdDoctor).ToListAsync();
        if (!DocDB.Contains(DocDTO.IdDoctor))
        {
            throw new Exception("Doctor not found");
        }

        var Patient = await data.Patients.FindAsync(fromRequest.Patient.IdPatient);
        if (Patient == null)
        {
            Patient = new Patient
            {
                FirstName = fromRequest.Patient.FirstName,
                LastName = fromRequest.Patient.LastName,
                Birthdate = fromRequest.Patient.Birthdate,
            };
            await data.Patients.AddAsync(Patient);
            await data.SaveChangesAsync();
        }

        var Prescription = new Prescription
        {
            Date = fromRequest.Date,
            DueDate = fromRequest.DueDate,
            Patient = Patient,
            IdDoctor = fromRequest.Doctor.IdDoctor,
            PrescriptionMedicaments = fromRequest.Medicaments
                .Select(m => new PrescriptionMedicament
                {
                    IdMedicament = m.IdMedicament,
                    Dose = m.Dose,
                    Details = m.Details,
                }).ToList(),
        };
        await data.Prescriptions.AddAsync(Prescription);
        await data.SaveChangesAsync();
        
    }
}
