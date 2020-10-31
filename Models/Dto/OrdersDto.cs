using System.Collections.Generic;

namespace Models.Dto
{
    public class OrdersDto
    {
        public int     IdOrder  { get; set; }
        public decimal Iva      { get; set; }
        public decimal Total    { get; set; }
        public decimal SubTotal { get; set; }

        public List<DetailOrdersDto> ListDetailOrders { get; set; }
    }
}