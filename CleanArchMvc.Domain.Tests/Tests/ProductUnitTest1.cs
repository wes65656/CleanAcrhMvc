using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validations;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Criar produto com parâmetros válidos")]
        public void CriarProduto_ComParametrosValidos_DeveCriarProduto()
        {
            Action action = () => new Product("Product Name", "Product Description", 10.5m, 5, "image.png");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar produto com id negativo deve resultar em erro")]
        public void CriarProduto_ComIdNegativo_DeveResultarErro()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 10.5m, 5, "image.png");
            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Id não pode ser menor que zero");
        }

        [Fact(DisplayName = "Criar produto com nome vazio deve resultar em Sucesso")]
        public void CriarProduto_ComNomeVazio_DeveResultarSucesso()
        {
            Action action = () => new Product("", "Product Description", 10.5m, 5, "image.png");
            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O nome não pode estar vazio!");
        }

        [Fact(DisplayName = "Criar produto com nome menor que 3 caracteres deve resultar em sucesso")]
        public void CriarProduto_ComNomeMenorQueTresCaracteres_DeveResultarSucesso()
        {
            Action action = () => new Product("Pr", "Product Description", 10.5m, 5, "image.png");
            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O nome não pode ser menor que 3 char!");
        }

        [Fact(DisplayName = "Criar produto com descrição menor que 5 caracteres deve resultar em Sucesso")]
        public void CriarProduto_ComDescricaoMenorQueCincoCaracteres_DeveResultarSucesso()
        {
            Action action = () => new Product("Product Name", "Desc", 10.5m, 5, "image.png");
            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("A descrição não pode ser menor que 5 char!");
        }

        [Fact(DisplayName = "Criar produto com preço negativo deve resultar em Sucesso")]
        public void CriarProduto_ComPrecoNegativo_DeveResultarSucesso()
        {
            Action action = () => new Product("Product Name", "Product Description", -10.5m, 5, "image.png");
            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O valor não pode estar vazio!");
        }

        [Fact(DisplayName = "Criar produto com estoque negativo deve resultar em Sucesso")]
        public void CriarProduto_ComEstoqueNegativo_DeveResultarSucesso()
        {
            Action action = () => new Product("Product Name", "Product Description", 10.5m, -5, "image.png");
            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O valor não deve estar zerado!");
        }

        [Fact(DisplayName = "Criar produto com caminho de imagem maior que 250 caracteres deve resultar em Sucesso")]
        public void CriarProduto_ComImagemComMaisDe250Caracteres_DeveResultarSucesso()
        {
            var longImagePath = new string('a', 251);
            Action action = () => new Product("Product Name", "Product Description", 10.5m, 5, longImagePath);
            action
                .Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("O diretorio para imagem ultrapassa os 250 char!");
        }
        
        [Fact(DisplayName = "Criar produto com imagem nula deve não lançar exceção")]
        public void CriarProduto_ComImagemNula_NãoDeveLancarDomainExcecao()
        {
            Action action = () => new Product("Produto A", "Descrição válida", 10.99m, 5, null);
            action.Should().NotThrow<DomainExceptionValidation>("porque a imagem pode ser nula se não há validação específica");
        }
        [Fact(DisplayName = "Criar produto com imagem nula não deve lançar exceção")]
        public void CriarProduto_ComImagemNula_DeveLancaReferencerExcecao()
        {
            Action action = () => new Product("Produto A", "Descrição válida", 10.99m, 5, null);
            action.Should().NotThrow<NullReferenceException>("porque a imagem pode ser nula se não há validação específica");
        }
    }
}