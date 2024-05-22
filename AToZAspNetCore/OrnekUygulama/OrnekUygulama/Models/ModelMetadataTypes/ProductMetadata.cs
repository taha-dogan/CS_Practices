using System.ComponentModel.DataAnnotations;

namespace OrnekUygulama.Models.ModelMetadataTypes
{
    public class ProductMetadata
    {

        [Required(ErrorMessage = "Product name can't be null!")] 
        [StringLength(100, ErrorMessage = "Please set product name less than 100!")]
        public string ProductName { get; set; }

        [EmailAddress(ErrorMessage = "Please set a standart e-mail address!")]
        public string DeveloperEmail { get; set; }

    }
}
