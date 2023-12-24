using System.ComponentModel.DataAnnotations.Schema;

namespace MyBizAPI.Entity
{
    public class Employee:BaseEntity
    {
        public string FullName {  get; set; }
        public Position Position { get; set; }
        public int PositionId {  get; set; }
        public string Description {  get; set; }
        public string RedirectUrl {  get; set; }
        public string ImageUrl {  get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
