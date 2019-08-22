using System.ComponentModel.DataAnnotations;

namespace MenuRepository.Models
{
    public class Selection
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(10), MinLength(1)]
        public string Name { get; set; }

        [Required]
        public int OptionID { get; set; }

        [Required]
        public int Price { get; set; }


        public virtual Option Option { get; set; }
    }
}
