using Microsoft.AspNetCore.Mvc;
using OrnekUygulama.Models.ModelMetadataTypes;
using System.ComponentModel.DataAnnotations;

namespace OrnekUygulama.Models
{
    [ModelMetadataType(typeof(ProductMetadata))]
    public class Product
    {
        public string ProductName { get; set; }
        
        public int ProductQuantity { get; set; }

        public string DeveloperEmail { get; set; }
    }
}
