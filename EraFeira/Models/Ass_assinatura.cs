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

        public int Ass_tempo { get; set; }

        public string Ass_descricao { get; set; }

        [EnumDataType(typeof(Status))]
        [Display(Name = "Status")]
        public Status Ass_status { get; set; }
        public enum Status { vigente, encerrado }

        [EnumDataType(typeof(TipoCesta))]
        [Display(Name = "")]
        public TipoCesta Ass_tipo_cesta { get; set; }
        public enum TipoCesta { igual, diferente }

        public int Usu_id { get; set; }
        public virtual Usu_usuario Usu_Usuario { get; set; }
    }
}