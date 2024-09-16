using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Aplication.DTOs;

public class CategoryDto
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome é obrigatorio")]
    [MaxLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres")]
    [MinLength(3, ErrorMessage = "O nome não pode ter menos que 3 caracteres")]
    public string Name { get; set; }
}
    
    