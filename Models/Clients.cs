using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Clients
    {
        [Key]
        public int    IdClient { get; set; }
        public string Name     { get; set; }
    }
}