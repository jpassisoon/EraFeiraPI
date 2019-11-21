using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.Models
{
    public class Pro_produto
    {
        [Key]
        [Display(Name = "ID")]
        public int Pro_id { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Pro_descricao { get; set; }

        [Required]
        [Display(Name = "Valor de Venda")]
        public double Pro_valor_venda { get; set; }

        [Display(Name = "Desconto")]
        public int Pro_desconto { get; set; }
                
        //[Required]
        [Display(Name = "Imagem")]
        [MaxLength(100)]
        public string Pro_foto { get; set; }

        [Display(Name = "Categoria")]
        public int Cat_id { get; set; }
        public virtual Cat_categoria Cat_Categoria { get; set; }

        [Display(Name = "Imagens")]
        public ICollection<Img_imagem> Img_Imagems { get; set; }
    }
}