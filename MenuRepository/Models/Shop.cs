using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MenuRepository.Models
{
    public class Shop
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(10), MinLength(1)]
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
