namespace AppCrud.Business.Models;

public class OrderItem : Entity
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal? UnitPrice { get; set; }

    public Order Order { get; set; }
    public Product Product { get; set; }

    protected OrderItem() { }

    public OrderItem(Guid productId, int quantity, decimal unitPrice)
    {
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    internal void AssociateProduct(Guid orderId)
    {
        OrderId = orderId;
    }

    internal void AddQuantity(int quantity)
    {
        Quantity += quantity;
    }

    internal decimal CalculateValue()
    {
        return Quantity * UnitPrice ?? 0;
    }
}
