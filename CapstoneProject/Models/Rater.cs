﻿using System.ComponentModel.DataAnnotations;

namespace CapstoneProject.Models
{
    public class Rater
    {
        public int RaterID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "**")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "**")]
        public string LastName { get; set; }

        public string Role { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "**")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string Answers { get; set; }

        public int EvaluationID { get; set; }

        public virtual Evaluation Evaluation { get; set; }
    }
}