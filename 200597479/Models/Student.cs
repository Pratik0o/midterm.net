using System.ComponentModel.DataAnnotations;

public class Student
{
    public int StudentId { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Display(Name = "Email Address")]
    [EmailAddress]
    public string EmailAddress { get; set; }
}
