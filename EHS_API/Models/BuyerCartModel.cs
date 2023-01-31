using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EHS_API.Models;

namespace EHS_API.Models
{
    public class BuyerCartModel
    {
        [Required]
        public int Id { get; set; }
        public House House { get; set; }
        public UserDetails UserDetails { get; set; }
        [ForeignKey("UserDetails"), Column(Order = 0)]
        public int UserDetaisId { get; set; }
        [ForeignKey("House"), Column(Order = 1)]

        public int HouseId { get; set; }
    }
}