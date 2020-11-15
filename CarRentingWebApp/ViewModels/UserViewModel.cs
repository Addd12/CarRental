using System.ComponentModel.DataAnnotations;


namespace CarRentingWebApp.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public int UserIndex { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of birth")]
        public string DateOfBirth { set; get; }

        [Display(Name = "Gender")]
        public string Gender { set; get; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Admin")]
        public bool Admin { set; get; }
    }
}
