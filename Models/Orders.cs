using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Orders
    {
        [Key]
        public int     IdOrder  { get; set; }
        public decimal Iva      { get; set; }
        public decimal Total    { get; set; }
        public decimal SubTotal { get; set; }

        // Se hace una relación de clase
        public int     IdClient { get; set; }
        public Clients Client   { get; set; }

        public List<DetailOrders> ListDetailOrders { get; set; }
    }
}