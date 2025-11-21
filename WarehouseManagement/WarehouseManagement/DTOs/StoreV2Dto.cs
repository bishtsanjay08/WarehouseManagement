namespace WarehouseManagement.DTOs
{
    public class StoreV2Dto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string Location { get; set; } = null!;
    }
}
