﻿using System.ComponentModel.DataAnnotations;

namespace User_Management_WebApp.Areas.Admin.ViewModels
{
    public class RoleViewModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; } = string.Empty;

        [Display(Name = "Role Name")]
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Is Active")]
        public bool Active { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
