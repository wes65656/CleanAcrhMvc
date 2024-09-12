using CleanArchMvc.Domain.Validations;

namespace CleanArchMvc.Domain.Entities;

public sealed class Product : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Image { get; private set; }

    public Product(string name, string description, decimal price, int stock, string image)
    {
        ValidateDomain(name, description, price, stock, image);
    }
    
    public Product(int id, string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.
            When(id < 0,
                "Id não pode ser menor que zero");
        Id = id;
        ValidateDomain(name, description, price, stock, image);
    }
    public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
    {
        ValidateDomain(name, description, price, stock, image);
        CategoryId = categoryId;
    }
    
    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.
            When(string.
            IsNullOrEmpty(name), 
                "O nome não pode estar vazio!");
        
        DomainExceptionValidation.
            When(name.
                Length < 3,
                "O nome não pode ser menor que 3 char!");
        
        DomainExceptionValidation.
            When(description.Length < 5,
                "A descrição não pode ser menor que 5 char!");
        
        DomainExceptionValidation.
            When(price < 0,
                "O valor não pode estar vazio!");
        
        DomainExceptionValidation.
            When(stock < 0,
            "O valor não deve estar zerado!");
        
        DomainExceptionValidation.
            When(image?.Length > 250,
                "O diretorio para imagem ultrapassa os 250 char!");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
    }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}