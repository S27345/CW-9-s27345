using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models;

[Table("Prescription_Medicament")]
[PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))]
public class PrescriptionMedicament
{
    public int IdMedicament { get; set; }
    public int IdPrescription { get; set; }
    public int? Dose { get; set; }
    [MaxLength(100)] public string Details { get; set; } = null!;
    
    [ForeignKey(nameof(IdMedicament))]
    public virtual Medicament Medicament { get; set; } = null!;
    [ForeignKey(nameof(IdPrescription))]
    public virtual Doctor Doctor { get; set; } = null!;
}