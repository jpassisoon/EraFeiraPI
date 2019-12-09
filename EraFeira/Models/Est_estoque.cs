using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.Models
{
    public class Est_estoque
    {
        [Key]
        [Display(Name = "ID")]
        public int Est_id { get; set; }

        //[Required]
        [Display(Name = "Quantidade de entrada")]
        public int Est_quantidade_entrada { get; set; }

        [Display(Name = "Quantidade de saída")]
        public int Est_quantidade_saida { set; get; }

        //[Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de entrada")]
        public DateTime Est_entrada { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de saída")]
        public DateTime Est_saida { get; set; }

        [Display(Name = "Motivo da saída")]
        public string Est_motivo_saida { get; set; }

       // [Required]
        [Display(Name = "Valor de Entrada")]
        public double Est_valor_entrada { get; set; }

       // [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data do vencimento")]
        public DateTime Est_data_vencimento { get; set; }

        public int Pro_id { set; get; }
        public virtual Pro_produto Pro_Produto { set; get; }

    }
}