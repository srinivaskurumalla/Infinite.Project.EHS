using EHS_API.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace EHS_API.DTO
{
    public class SellerHouseDto
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

        //Seller Foreign key

        public int CityId { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }



        public string PhoneNumber { get; set; }

        public string FullName { get; set; }

        //navingation property

        public string Status { get; set; }



        //House Image Details



        public int HouseId { get; set; }
        //navingation property


        public string CityName { get; set; }




        public string StateName { get; set; }


        public int UserDetailsId { get; set; }


    }


}