using System.ComponentModel.DataAnnotations;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.CustomValidaton
{
    public class Min18YrsIfAMember : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var customerDto = (Customer)validationContext.ObjectInstance;

            if(customerDto.MembershipTypeId == MembershipType.Unknown || customerDto.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if(customerDto.BirthDate == null)
            {
                return new ValidationResult("Birthdate  is required!");
            }

            var age = DateTime.Today.Year - customerDto.BirthDate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success : 
                new ValidationResult("Customer should be at least 18 years old to get a membership");
        }
    }
}
