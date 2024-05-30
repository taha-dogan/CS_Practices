using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO.Compression;

namespace AppointmentMaker.Models
{
    public class CustomerModel
    {
        [DisplayName("Enter your city name")]
        [DataType(DataType.Text)]
        public string CityName { get; set; }

        [DisplayName("Enter your street name")]
        [DataType(DataType.Text)]
        public string StreetName { get; set; }

        [DisplayName("ZIP Code")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [DisplayName("Your phone number")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string PhoneNumber { get; set; }

        [DisplayName("Your email address")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmailAddress { get; set; }
    }
}
