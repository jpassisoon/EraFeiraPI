using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.Models
{
    public class Img_imagem
    {
        [Key]
        [Display(Name = "ID")]
        public int Img_id { get; set; }

        [Display(Name = "Produto")]
        public int Pro_id { get; set; }
        public virtual Pro_produto Pro_Produto { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [MaxLength(45)]
        public string Img_nome { get; set; }

        [Required]
        [Display(Name = "Imagem")]
        [MaxLength(100)]
        public string Img_foto { get; set; }

    }
}