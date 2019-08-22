using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenuRepository.Models
{
    public class ItemOption

    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int OptionID { get; set; }

        [Required]
        public int ItemID { get; set; }
        
        public virtual Item Item { get; set; }

        public virtual Option Option{ get; set; }
    }
}
