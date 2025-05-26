using System.ComponentModel.DataAnnotations;

namespace WebApplication.DTOs;

public class PrescriptionCreateDTO
{
    public DateOnly Date {get; set;}
    public DateOnly DueDate {get; set;}
    public DoctorDto Doctor {get; set;}
    public PatientDto Patient {get; set;}
    public ICollection<CreatePrescriptionMedicamentsDto> Medicaments {get; set;}
}

public class DoctorDto
{
    public int IdDoctor { get; set; }
}

public class PatientDto
{
    public int IdPatient { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    [Required]
    public DateOnly Birthdate { get; set; }
}

public class CreatePrescriptionMedicamentsDto
{
    [Required]
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    [Required]
    [MaxLength(100)]
    public string Details {get; set;}
}