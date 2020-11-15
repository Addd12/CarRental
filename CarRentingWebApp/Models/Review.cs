using System;

namespace CarRentingWebApp.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public string ReviewContent { get; set; }
        public double? Rating { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
