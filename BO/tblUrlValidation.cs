using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class UniqueUrlAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {            
            if(value != null)
            {
                LinkSpotEntities1 db = new LinkSpotEntities1();
                string urlValue = value.ToString();
                int count = db.Links.Where(x => x.Url == urlValue).ToList().Count();
                if (count != 0)
                    return new ValidationResult("Url Already Exist");
                return ValidationResult.Success;
            }
            else
            {
                return null;
            }
                          
        }
    }
    public class tblUrlValidation
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [Url]
        [UniqueUrl]
        public string Url { get; set; }

        [Required]
        public string Description { get; set; }
    }

    [MetadataType(typeof(tblUrlValidation))]
    public partial class Link
    {

    }
}
