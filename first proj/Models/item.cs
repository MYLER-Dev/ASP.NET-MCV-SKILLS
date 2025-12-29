using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace first_proj.Models
{
    public class item
    {
        [Key] // primely key
        public int Id { get; set; }
        [Required] // not null
        public string Name { get; set; }
        [Required]
        [DisplayName("The Price")]
        [Range(10, 1000 ,ErrorMessage ="Value Must be betwen 0 and 10 ")]
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
