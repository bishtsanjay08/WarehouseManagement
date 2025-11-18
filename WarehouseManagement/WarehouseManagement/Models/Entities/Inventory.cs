namespace WarehouseManagement.Models.Entities
{
    public class Inventory
    {
        public int WarehouseId { get; set; }

        public Warehouse? Warehouse { get; set; }

        public int ItemId { get; set; }

        public Item? Item { get; set; }

        public int Quantity { get; set; }

        public int ReservedQuantity { get; set; }
    }
}
