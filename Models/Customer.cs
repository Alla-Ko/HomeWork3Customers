using System.ComponentModel.DataAnnotations;

namespace HomeWork3Customers.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string? Email { get; set; }
    }
}
