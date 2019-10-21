using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Nome")]
        [MaxLength(45)]
        public string Pro_nome { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Pro_descricao { get; set; }

        [Required]
        [Display(Name = "Valor da Venda")]
        public double Pro_valor_venda { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data da chegada")]
        public DateTime Pro_data_chegada { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data do vencimento")]
        public DateTime Pro_data_vencimento { get; set; }

        [Display(Name = "Desconto")]
        public int Pro_desconto { get; set; }

        [Required]
        [Display(Name = "Quantidade")]
        public int Pro_quantidade { get; set; }

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