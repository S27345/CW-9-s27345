using WebApplication.Models;

namespace WebApplication.DTOs;

public class GetPatientDto
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthdate { get; set; }
    public ICollection<GetpatientPrescriptionDto> Prescriptions { get; set; } = null!;
}

public class GetpatientPrescriptionDto
{
    public int IdPrescription { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
    public ICollection<GetPrescriptionMedicamentDto> PrescriptionMedicaments { get; set; } = null!;
    public GetDoctorDto Doctor { get; set; } = null!;
}

public class GetPrescriptionMedicamentDto
{
    public int IdMedicament { get; set; }
    public GetMedicamentDto Medicament { get; set; } = null!;
    public int? Dose { get; set; }
    public string Details { get; set; } = null!;
}

public class GetMedicamentDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    
}

public class GetDoctorDto
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; } = null!;
}