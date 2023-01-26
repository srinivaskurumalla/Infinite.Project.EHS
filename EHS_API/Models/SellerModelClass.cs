using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EHS_API.Models
{
    //Seller Details
    public class Seller
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        //  public List<House> Houses { get; set; }

       /* [Required]
        public string Password { get; set; }*/
        public ICollection<House> Houses { get; set; }
    }

    //House Details
    public class House
    {

        public int Id { get; set; }
        public string PropertyType { get; set; }
        public string PropertyName { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }
        public string PropertyOption { get; set; }
        public string Description { get; set; }
        public decimal PriceRange { get; set; }
        public decimal InitialDeposit { get; set; }
        public string Landmark { get; set; }
        public DateTime UploadDate { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public List<HouseImage> HouseImages { get; set; }

    }

    //House Image Details
    public class HouseImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public int HouseId { get; set; }
        public House House { get; set; }
    }


}
