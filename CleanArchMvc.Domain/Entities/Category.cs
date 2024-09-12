using CleanArchMvc.Domain.Validations;

namespace CleanArchMvc.Domain.Entities;

public sealed class Category : BaseEntity
{
    public string Name { get; private set; }

    public Category(string name)
    {
        ValidateDomain(name);
    }

    public Category(int id, string name)
    {   
        DomainExceptionValidation.
            When(id < 0, 
                "Id não pode ser menor que zero");
        Id = id;
        ValidateDomain(name);
    }
    public ICollection<Product> Products { get; set; }

    public void Update(string name)
    {
        ValidateDomain(name);
    }
    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.
            When(string.
                IsNullOrEmpty(name),
                "Nome Invalido. O nome não pode estar vazio");
        
        DomainExceptionValidation.
            When(name.
                Length < 3,
                "Invalido, nome muinto curto.");
        Name = name;
    }
}