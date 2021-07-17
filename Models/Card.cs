using System;

namespace ASB.Models
{
    public class Card
    {
        public string Name { get; set; }

        public int CardNumber { get; set; }

        public int CVC {get; set;}

        public DateTime ExpiryDate { get; set; }
    }
}
