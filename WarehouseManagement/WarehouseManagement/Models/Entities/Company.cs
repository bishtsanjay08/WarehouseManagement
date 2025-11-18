namespace WarehouseManagement.Models.Entities
{
    public class Company
    {
        public required int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public List<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
    }
}
