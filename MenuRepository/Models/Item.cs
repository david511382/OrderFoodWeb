using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MenuRepository.Models
{
    public class Item
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(10), MinLength(1)]
        public string Name { get; set; }

        [Required]
        public int ShopID { get; set; }

        [Required]
        public int Price { get; set; }
        
        public virtual Shop Shop{ get; set; }

        public virtual ICollection<ItemOption> ItemOptions { get; set; }
    }
}
