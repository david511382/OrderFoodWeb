using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MenuRepository.Models
{
    public class Option

    {
        [Required]
        public int ID { get; set; }

        [Required]
        public int SelectNum { get; set; }


        public virtual ICollection<ItemOption> ItemOptions { get; set; }

        public virtual ICollection<Selection> Selections { get; set; }
    }
}
