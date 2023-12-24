namespace MyBizAPI.DTOs.BookDTOs
{
    public class CreateEmployeeDTO
    {
        public string FullName { get; set; }
        public string Description { get; set; }
        public int PositionId { get; set; }
        public string RedirectUrl { get; set; }
    }
}
