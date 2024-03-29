﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.Models
{
    public class Ces_cesta
    {
        [Key]
        [Display(Name = "ID")]
        public int Ces_id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Ces_nome { get; set; }

        //[Required]
        [Display(Name = "Data criada")]
        public DateTime Ces_criacao { get; set; }

        //[Required]
        [Display(Name = "Data Entrega")]
        public DateTime Ces_data_entrega { get; set; }

        //[Required]
        [Display(Name = "Total")]
        public double Ces_valor { get; set; }

        public int Usu_id { get; set; }
        public virtual Usu_usuario Usu_Usuario { get; set; }

        public int Ass_id { get; set; }
        public virtual Ass_assinatura Ass_Assinatura { get; set; }

    }
}