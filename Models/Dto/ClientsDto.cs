using System.ComponentModel.DataAnnotations;

namespace Models.Dto
{
    public class ClientsDto
    {
        public int    IdClient { get; set; }
        [Required]
        public string Name     { get; set; }
    }
}