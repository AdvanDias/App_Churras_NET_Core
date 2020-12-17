using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace APPTESTE.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the Usuario class
    public class Usuario : IdentityUser
    {
        
        [PersonalData]
        [Column(TypeName = "Nvarchar(100)")]
        public string Nome { get; set; }

        
        [PersonalData]
        [Column(TypeName = "Nvarchar(100)")]
        public string SobreNome { get; set; }
    }
}
