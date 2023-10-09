using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        // this will be the primary key in the DB table

        [Key]
        public int Id { get; set; }    
        
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
