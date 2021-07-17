using System;
using System.ComponentModel.DataAnnotations;

namespace ASB.Models
{
    public class ValidCard
    {
        public string ID { get; set; }
        [Required]
        public long CardNumber { get; set; }

    }
}
