namespace WarehouseManagement.Models.Entities
{
    public class Item
    {
        public required int Id { get; set; }

        public required string SKU { get; set; }

        public string Name { get; set; } = null!;

        public string? UnitOfMeasure { get; set; }

        public List<Inventory> Inventories { get; set; } = new List<Inventory>();
    }
}
