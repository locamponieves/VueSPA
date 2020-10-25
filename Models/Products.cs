using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Products
    {
        [Key]
        public int     IdProduct   { get; set; }
        public string  Name        { get; set; }
        public decimal Price       { get; set; }
        public string  Description { get; set; }
    }
}