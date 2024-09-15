using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validations;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Criar categoria com estado válido")]
        public void CriarCategoria_ComParametrosValidos_DeveResultarObjetoValido()
        {
            Action action = () => new Category(14, "Category Name");
            
            action.Should()
                .NotThrow<DomainExceptionValidation>("porque todos os parâmetros são válidos");
        }

        [Fact(DisplayName = "Criar categoria com id negativo deve resultar sucesso")]
        public void CriarCategoria_ComIdNegativo_DeveResultarEmSucesso()
        {
            Action action = () => new Category(-14, "Category Name");
            
            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Id não pode ser menor que zero");
        }
        
        [Fact(DisplayName = "Criar categoria sem nome deve resultar em sucesso")]
        public void CriarCategoria_SemNome_DeveResultarEmSucesso()
        {
            Action action = () => new Category(14, "");
            
            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Nome Invalido. O nome não pode estar vazio");
        }
        
        [Fact(DisplayName = "Criar categoria com nome menor que 3 char deve resultar sucesso")]
        public void CriarCategoria_ComNomeMenor_DeveResultarEmSucesso()
        {
            Action action = () => new Category(14, "ab");
            
            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalido, nome muinto curto.");
        }
        [Fact(DisplayName = "Criar categoria com null deve resultar em sucesso")]
        public void CriarCategoria_ComNomeNull_DeveResultarEmSucesso()
        {
            Action action = () => new Category(14, null);
            
            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Nome Invalido. O nome não pode estar vazio");
        }
    }
}