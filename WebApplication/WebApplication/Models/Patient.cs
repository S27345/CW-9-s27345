using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models;

public class Patient
{
    [Key] public int IdPatient { get; set; }
    [MaxLength(100)] public string FirstName { get; set; } = null!;
    [MaxLength(100)] public string LastName { get; set; } = null!;
    public DateOnly Birthdate { get; set; }
    
    public virtual ICollection<Prescription> Prescriptions { get; set; } = null!;
}