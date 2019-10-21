using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.Models
{
    public class Pxf_produto_fornecedor
    {
        [Key]
        [Display(Name = "ID")]
        public int Pxf_id { get; set; }

        [Required]
        [Display(Name = "Valor da entrada")]
        public double Pxf_valor_entrada { get; set; }

        [Required]
        [Display(Name = "Quantidade")]
        public int Pxf_quantidade { get; set; }

        [Display(Name = "Produto")]
        public int Pro_id { get; set; }
        [Display(Name = "Fornecedor")]
        public int For_id { get; set; }
        public virtual Pro_produto Pro_Produto { get; set; }
        public virtual For_fornecedor For_Fornecedor { get; set; }
    }
}