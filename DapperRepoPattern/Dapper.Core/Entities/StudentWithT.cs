using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Core.Entities;
public class StudentWithT
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RollNo { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string? FamilyName { get; set; }
    [Required]
    public string? Address { get; set; }
    [Required]
    [RegularExpression("^[0-9]{10}$", ErrorMessage ="This should be 10 digit numeric data")]
    public string? Contact { get; set; }
    public DateTime AddedOn { get; set; }

    public DateTime ModifiedOn { get; set; }
}
