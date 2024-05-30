using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Activity2.Models
{
    public class ProductModel
    {
        [DisplayName("Id Number")]
        public int Id { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }

        [DisplayName("Cost to Customer")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DisplayName("Description of the Product")]
        public string Description { get; set; }
    }
}
