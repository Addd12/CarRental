using CarRentingWebApp.Models;
using System.Collections.Generic;

namespace CarRentingWebApp.ViewModels
{
    public class CarViewModel
    {
        public List<Car> Cars;
        public List<Review> Reviews;

        public string Search { get; set; }
    }
}
