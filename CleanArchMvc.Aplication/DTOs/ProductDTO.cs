using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Aplication.DTOs;

public class ProductDto
{
    public int Id { get; init; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [MaxLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres")]
    [MinLength(3, ErrorMessage = "O nome não pode ter menos que 3 caracteres")]
    [DisplayName("Nome")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A descrição é obrigatória")]
    [MaxLength(200, ErrorMessage = "A descrição não pode ter mais que 200 caracteres")]
    [MinLength(5, ErrorMessage = "A descrição não pode ter menos que 3 caracteres")]
    [DisplayName("Descrição")]
    public string Description { get; set; }

    [Required(ErrorMessage = "O preço é obrigatório")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "O estoque é obrigatório")]
    [Range(1, 9999)]
    [DisplayName("Estoque")]
    public int Stock { get; set; }
    
    [MaxLength(250)]
    [DisplayName("Imagem do produto")]
    public string Image { get; set;}
    
    public Category Category { get; set; }
    
    public int CategoryId { get; set; }
}