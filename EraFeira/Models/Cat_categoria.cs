using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.Models
{
    public class Cat_categoria
    {
        [Key]
        [Display(Name = "ID")]
        public int Cat_id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [MaxLength(45)]
        public string Cat_nome { get; set; }

        [Required]
        [Display(Name = "Dercrição")]
        public string Cat_descricao { get; set; }

        [Display(Name = "Status")]
        public Boolean Cat_status { get; set; }
        //public enum Tipo { ativo = 1, inativo = 0 }
    }
}