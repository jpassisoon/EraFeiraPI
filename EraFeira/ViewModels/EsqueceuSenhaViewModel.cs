using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.ViewModels
{
    public class EsqueceuSenhaViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="E-mail")]
        public string Email { get; set; }
    }
}