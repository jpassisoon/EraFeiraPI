using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.Models
{
    public class Ent_entrega
    {
        [Key]
        public int Ent_id { set; get; }

        [Display (Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime Ent_data { set; get; }

        [Display(Name = "Anotação")]
        public string Ent_anotacao { set; get; }

        //se foi entregue ou não
        [Display(Name = "Entregue")]
        public bool Ent_entregue { set; get; }

        public int Ces_id { set; get; }
        public virtual Ces_cesta Ces_Cesta { set; get; }
    }
}