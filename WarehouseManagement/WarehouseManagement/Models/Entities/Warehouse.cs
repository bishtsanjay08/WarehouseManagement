namespace WarehouseManagement.Models.Entities
{
    public class Warehouse
    {
        public required int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Location { get; set; }

        public int CompanyId { get; set; }

        public required Company? Company { get; set; }

        public List<Inventory> Inventories { get; set; } = new List<Inventory>();
    }
}
