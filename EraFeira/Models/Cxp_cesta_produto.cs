using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.Models
{
    public class Cxp_cesta_produto
    {
        [Key]
        [Display(Name = "ID")]
        public int Cxp_id { get; set; }

        [Required]
        [Display(Name = "Valor")]
        public double Cxp_valor { get; set; }

        [Required]
        [Display(Name = "Quantidade")]
        public int Cxp_quantidade { get; set; }

        [Display(Name = "Cesta")]
        public int Ces_id { get; set; }
        [Display(Name = "Produto")]
        public int Pro_id { get; set; }
        public virtual Ces_cesta Ces_Cesta { get; set; }
        public virtual Pro_produto Pro_Produto { get; set; }
    }
}