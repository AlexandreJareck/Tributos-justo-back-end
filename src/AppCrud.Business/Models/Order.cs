namespace AppCrud.Business.Models;

public class Order : Entity
{
    public Order()
    {
        CreatedAt = DateTime.Now;
        Items = new List<OrderItem>();
    }

    public Guid ClientId { get; set; }
    public decimal TotalValue { get; set; }
    public Client Client { get; set; }
    public List<OrderItem> Items { get; set; }
    public DateTime? CreatedAt { get; set; }

    public void AddItem(OrderItem item)
    {
        item.AssociateProduct(Id);

        if (ExistingOrder(item))
        {
            var existingItem = Items.FirstOrDefault(p => p.ProductId == item.ProductId)!;

            existingItem.AddQuantity(item.Quantity);

            item = existingItem;

            Items.Remove(existingItem);
        }

        Items.Add(item);
    }    
    public void RemoveItem(OrderItem item)
    {
        ValidationOrderItemNonExistent(item);

        Items.Remove(item);
        CalculateTotal();
    }

    public void CalculateTotal()
    {
        TotalValue = Items.Sum(p => p.CalculateValue());
    }

    public bool ExistingOrder(OrderItem item)
    {
        return Items.Any(p => p.ProductId == item.ProductId);
    }
    private void ValidationOrderItemNonExistent(OrderItem item)
    {
        if (!ExistingOrder(item))
            throw new Exception("O item não pertence ao pedido");
    }
}
