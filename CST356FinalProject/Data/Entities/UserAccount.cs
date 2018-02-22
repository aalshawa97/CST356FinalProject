using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CST356FinalProject.Models
{
  public class UserAccount
  {
    [Key]
    public int UserID { get; set; }

    [Required(ErrorMessage = "First Name Is Required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name Is Required")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email Is Required")]
    [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "User Name Is Required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password Is Required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "Please confirm your password.")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
  }
}