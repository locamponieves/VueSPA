using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class DetailOrders
    {
        [Key]
        public int     IdDetailOrder { get; set; }
        public decimal UnitPrice     { get; set; }
        public int     Quantity      { get; set; }
        public decimal Iva           { get; set; }
        public decimal Total         { get; set; }
        public decimal SubTotal      { get; set; }

        // Se hace una relación de clase
        public int      IdOrder   { get; set; }
        public Orders   Order     { get; set; }
        public int      IdProduct { get; set; }
        public Products Products  { get; set; }
    }
}