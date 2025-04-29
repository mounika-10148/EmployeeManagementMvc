using System.ComponentModel.DataAnnotations;

using System;
using System.ComponentModel.DataAnnotations;

namespace CrudOperations.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }

        public bool Subscribed { get; set; }
    }
}

