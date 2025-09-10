using System.ComponentModel.DataAnnotations;

namespace ICollection.Models
{
    public class StudentModel
    {
        [Display(Name = "Enrollment No.")]
        public int EnrollmentNo { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your mobile number.")]
        [Display(Name = "Mobile No.")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Please enter your address.")]
        [StringLength(200)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select your gender.")]
        public string Gender { get; set; }

        [Display(Name = "Playing Cricket?")]
        public bool PlayingCricket { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter your 12th percentage.")]
        [Display(Name = "12th Percentage")]
        public double Percentage12 { get; set; }

        [Display(Name = "Live in Rajkot?")]
        public bool LiveInRajkot { get; set; }
    }
}
