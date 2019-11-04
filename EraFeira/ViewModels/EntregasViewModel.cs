using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.ViewModels
{
    public class EntregasViewModel
    {
        public int QntCesta { get; set; }

        public int Intervalo { get; set; }

        //[EnumDataType(typeof(TipoCesta))]
        [Display(Name = "")]
        public TipoCesta Ass_tipo_cesta { get; set; }
        public enum TipoCesta { igual, diferente }
    }
}