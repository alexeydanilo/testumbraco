﻿using System.ComponentModel.DataAnnotations;
using Umbraco.Core.Models.PublishedContent;

namespace testumbraco.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "You must enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your message")]
        [MaxLength(500, ErrorMessage = "Your message must be no longer than 500 characters")]
        public string Message { get; set; }
        public bool? Succes { get; set; }

    }
}