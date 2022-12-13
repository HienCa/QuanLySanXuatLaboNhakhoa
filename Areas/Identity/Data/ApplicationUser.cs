using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySanXuat.Areas.Identity.Data
{
    public class ApplicationUser:IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string HoTen { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string SDT { get; set; }


    }
}
