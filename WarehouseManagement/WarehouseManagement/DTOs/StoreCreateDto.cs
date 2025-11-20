namespace WarehouseManagement.DTOs
{
    public class StoreCreateDto
    {
        public required string Name { get; set; }

        public string Location { get; set; } = null!;
    }
}
