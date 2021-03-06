﻿using System.ComponentModel.DataAnnotations;
using System.Web.ModelBinding;

namespace BoardGameShopMVC.Models
{
    public class UserData
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string CodeAndCity { get; set; }

        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Błędny format numeru telefonu.")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Błędy format adresu email.")]
        public string Email { get; set; }
    }
}