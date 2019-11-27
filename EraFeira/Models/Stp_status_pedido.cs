using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.Models
{
    public class Stp_status_pedido
    {
        [Key]
        public int Stp_id { set; get; }

        [Display (Name = "Descrição")]
        public string Descricao { set; get; }
    }
}