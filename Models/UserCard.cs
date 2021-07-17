using System;
using System.ComponentModel.DataAnnotations;

namespace ASB.Models
{
    public class UserCard
    {
        public string ID { get; set; }

        [Required,RegularExpression(@"^[a-zA-Z0-9]*")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public long CardNumber { get; set; }

        [Required]
        public int CVC {get; set;}

        [Required]
        public DateTime ExpiryDate { get; set; }
    }
}
