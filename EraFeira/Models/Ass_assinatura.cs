using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.Models
{
    public class Ass_assinatura
    {
        [Key]
        public int Ass_id { get; set; }

        public int Ass_qtd_cesta { set; get; }

        public int Ass_tempo { get; set; }

        //public string Ass_descricao { get; set; }
                
        [Display(Name = "Status")]
        public bool Ass_status { get; set; }
       
        [Display(Name = "")]
        public bool Ass_tipo_cesta { get; set; }

        //total de todas as cestas
        public double Ass_valor_total { set; get; }

        public int Usu_id { get; set; }
        public virtual Usu_usuario Usu_Usuario { get; set; }
    }
}