using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace CarRentingWebApp.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public DateTime DateTaken { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
