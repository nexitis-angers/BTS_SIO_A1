using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyHome.Web.Models.Account
{
    public class RegisterViewModel
    {
        #region Properties
        [Display(Name ="Prénom")]
        [Required(), StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Nom de famille")]
        [Required(), StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(), StringLength(125)]
        public string Email { get; set; }

        [Display(Name = "Mot de passe")]
        [Required(), StringLength(50)]
        public string Password { get; set; }

        #endregion
    }
}
