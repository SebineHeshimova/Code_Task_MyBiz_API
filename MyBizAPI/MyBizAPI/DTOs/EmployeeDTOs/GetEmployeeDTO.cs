namespace MyBizAPI.DTOs.BookDTOs
{
    public class GetEmployeeDTO
    {
        public string FullName { get; set; }
        public string Description { get; set; }
        public int PositionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }    
    }
}
