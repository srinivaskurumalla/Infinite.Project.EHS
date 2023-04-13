using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace EHS_API.Models
{
   // [Index("IX_UserDetailsId_UserRolesId", IsUnique = true)]
    public class UserRoleMappings
    {
        public int Id { get; set; }


        public UserRoles UserRoles { get; set; }
        public UserDetails UserDetails { get; set; }

        [ForeignKey("UserDetails"),Column(Order =0)]
        public int UserDetailsId { get; set; }

        [ForeignKey("UserRoles"), Column(Order = 1)]
        public int UserRolesId { get; set; }
    }
}
