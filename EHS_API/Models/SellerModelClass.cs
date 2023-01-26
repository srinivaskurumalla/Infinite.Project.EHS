using Microsoft.AspNetCore.Mvc;
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

       
        public ICollection<House> Houses { get; set; }

       
     
    }

    //House Details
    public class House
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string PropertyType { get; set; }

        [Required]
        [MaxLength(50)]
        public string PropertyName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string Region { get; set; }

        [Required]
        [MaxLength(50)]
        public string PropertyOption { get; set; }
        public string Description { get; set; }

        [Required]
       
        public decimal PriceRange { get; set; }
        [Required]
       
        public decimal InitialDeposit { get; set; }
        public string Landmark { get; set; }
        public DateTime UploadDate { get; set; }

        //Seller Foreign key
        public int SellerId { get; set; }
        public int CityId { get; set; }

        //navingation property
        public Seller Seller { get; set; }
        public City City { get; set; }
       // public int HouseImageId { get; set; }
        public ICollection<HouseImage> HouseImages { get; set; }

    }

    //House Image Details
    [Consumes("multipart/form-data")]
    public class HouseImage
    {
        public int Id { get; set; }
        [Required]
       
        public byte[] Image { get; set; }

        //House Foreign key
        public int HouseId { get; set; }
        //navingation property
        public House House { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }

        //Foreign key
        public int StateId { get; set; }
        public State State { get; set; }

        public ICollection<House> Houses { get; set; }
    }
    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }

      //  public Seller seller { get; set; }
        public ICollection<City> Cities { get; set; }

    }

  
}
