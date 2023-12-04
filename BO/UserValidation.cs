using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                LinkSpotEntities1 db = new LinkSpotEntities1();
                string userEmailValue = value.ToString();
                int count = db.People.Where(x => x.UserEmail == userEmailValue).ToList().Count();
                if (count != 0)
                    return new ValidationResult("User Already Exist With This Email ID");
                return ValidationResult.Success;
            }
            else
            {
                return null;
            }

        }
    }

    public class UserValidation
    {
        [Required]
        [StringLength(15, ErrorMessage = "Please Enter a Valid Name !! :)")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [UniqueEmail]
        public string UserEmail { get; set; }

        [DataType(DataType.Password)]
        [StringLength(20,ErrorMessage ="Enter a Valid Password! (More than 6 characters)",MinimumLength = 6)]
        [Required]

        public string Password { get; set; }

        [DataType(DataType.Password)]
        
        [Required]        
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

    [MetadataType(typeof(UserValidation))]
    public partial class Person
    {
        public string ConfirmPassword { get; set; }
    }
}
