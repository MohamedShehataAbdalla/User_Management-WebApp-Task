using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace User_Management_WebApp.Models
{
    public class Employee
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [MinLength(3), MaxLength(30)]
        [DataType(DataType.Text)]
        public string First_Name { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        [MinLength(3), MaxLength(30)]
        [DataType(DataType.Text)]
        public string Last_Name { get; set; } = string.Empty;

        [Display(Name = "Department")]
        [MinLength(2), MaxLength(30)]
        [DataType(DataType.Text)]
        public string? Department { get; set; }

        [Display(Name = "Id Card")]
        [MinLength(12), MaxLength(12)]
        [DataType(DataType.Text)]
        public string? IdCard { get; set; }

        [Display(Name = "Gender")]
        public bool Gender { get; set; }

        [Display(Name = "Job Ttitle")]
        [MinLength(2), MaxLength(50)]
        [DataType(DataType.Text)]
        public string? JobTtitle { get; set; }

        [Display(Name = "Email Address")]
        [MinLength(6), MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateOnly? BirthDate { get; set; }

        [Display(Name = "Hiring Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        [DataType(DataType.Date)]
        public DateOnly HireDate { get; set; }

        [Display(Name = "Salary")]
        [DataType(DataType.Text)]
        public Decimal Salary { get; set; }

        [Display(Name = "HasHealth Insurance")]
        public bool HasHealthInsurance { get; set; }

        [Display(Name = "Has Pension Plan")]
        public bool HasPensionPlan { get; set; }

        [Display(Name = "Skills")]
        [MaxLength(255)]
        [DataType(DataType.MultilineText)]
        public string? Skills { get; set; }

        [Display(Name = "Image")]
        [MaxLength(255)]
        [DataType(DataType.ImageUrl)]
        public string? ImageUser { get; set; }

        [Display(Name = "National ID")]
        [MinLength(14), MaxLength(14)]
        [DataType(DataType.Text)]
        public string? NationalId { get; set; }

        [Display(Name = "Is Active")]
        public bool Active { get; set; }

        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Created At")]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated At")]
        [DataType(DataType.Date)]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Deleted At")]
        [DataType(DataType.Date)]
        public DateTime? DeletedAt { get; set; }


    }
}
