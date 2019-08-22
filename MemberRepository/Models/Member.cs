using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MemberRepository.Models
{
    public class Member
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
