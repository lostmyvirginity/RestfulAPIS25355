using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTOs;

public class AnimalUpdateDTO
{
    [Required] [MaxLength(200)] public String Name { get; set; }
    [Required] [MaxLength(200)] public String Description { get; set; }
    [Required] [MaxLength(200)] public String Category { get; set; }
    [Required] [MaxLength(200)] public String Area { get; set; }
}