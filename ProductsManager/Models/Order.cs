namespace ProductsManager.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string DeliveryDetails { get; set; }
        public int OrderQuantity { get; set; }
        public bool IsOrderDelivered { get; set; }
    }
}
