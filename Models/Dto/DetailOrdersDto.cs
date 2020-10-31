namespace Models.Dto
{
    public class DetailOrdersDto
    {
        public int     IdDetailOrder { get; set; }
        public decimal UnitPrice     { get; set; }
        public int     Quantity      { get; set; }
        public decimal Iva           { get; set; }
        public decimal Total         { get; set; }
        public decimal SubTotal      { get; set; }
    }
}