﻿using System.ComponentModel.DataAnnotations;

namespace User_Management_WebApp.Areas.Admin.ViewModels
{
    public class UserViewModel
    {

        [Display(Name = "Id")]
        public string Id { get; set; } = string.Empty;

        [Display(Name = "Username")]
        public string UserName { get; set; } = string.Empty;

        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;



        [Display(Name = "Phone Number")]
        [StringLength(11, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 11)]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; } = string.Empty;


        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string First_Name { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Last_Name { get; set; } = string.Empty;

        [Display(Name = "Bio")]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        [DataType(DataType.MultilineText)]
        public string? Bio { get; set; }

        [Display(Name = "User Image")]
        [DataType(DataType.Upload)]
        public byte[]? Image { get; set; }

        [Display(Name = "Gender")]
        public bool Gender { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateOnly? DateOfBirth { get; set; }

        [Display(Name = "Is Active")]
        public bool Active { get; set; }

        public IEnumerable<string>? RolesName { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


    }
}
