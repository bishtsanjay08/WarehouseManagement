namespace WarehouseManagement.Models
{
    public class StoreHistory
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime DeletedAt { get; set; }
    }
}
