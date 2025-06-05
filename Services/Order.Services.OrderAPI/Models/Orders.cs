namespace Order.Services.OrderAPI.Models
{
    public class Orders
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public string ProName { get; set; }

        public int ProPrice { get; set; }

        public string OrderDate { get; set; }
    }
}
