namespace AppCrud.Business.Models;

public class Order : Entity
{
    public decimal TotalValue { get; set; }
    public Client Client { get; set; }
    public List<Product> Products { get; set; }

    public void AddProduct(Product product)
    {
        Products.Add(product);
        // calcular total dos items
    }

    public void RemoveProduct()
    {

    }
}
