﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CapstoneProject.Models
{
    public class Employee
    {
        private const int MAX_NAME_LENGTH = 50;

        [Display(Name = "Employee ID")]
        [Range(0, int.MaxValue, ErrorMessage = "ID must be a non-negative whole number")]
        [Required(ErrorMessage = "Employee must have ID")]
        public int EmployeeID { get; set; }

        [Display(Name = "First Name")]
        [StringLength(MAX_NAME_LENGTH)]
        [Required(ErrorMessage = "Employee must have first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(MAX_NAME_LENGTH)]
        [Required(ErrorMessage = "Employee must have last name")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Employee must have address")]
        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone number required")]
        // TODO Add phone number validation
        public string Phone { get; set; }

        public int CohortID { get; set; }

        public Cohort Cohort { get; set; }

        public int SupervisorID { get; set; }

        public Employee Supervisor { get; set; }

        public int ManagerID { get; set; }

        public Employee Manager { get; set; }

        public ICollection<Evaluation> Evaluations { get; set; }
    }
}