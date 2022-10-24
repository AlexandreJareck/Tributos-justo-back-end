namespace AppCrud.Business.Models;

public class Order : Entity
{
    public decimal TotalValue { get; set; }
    public Client Client { get; set; }
    public List<Product> Products { get; set; }

    public void AddProduct(Product product)
    {
        // adicionar e calcular valor total dos produtos;
    }

    public void RemoveProduct()
    {
        // remover produto do pedido;
    }
}
