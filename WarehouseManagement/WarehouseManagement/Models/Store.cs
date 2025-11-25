namespace WarehouseManagement.Models
{
    public class Store
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string Location { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}