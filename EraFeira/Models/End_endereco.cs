using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.Models
{
    public class End_endereco
    {
        [Key]
        public int End_id { get; set; }
       
        [Required]
        [Display(Name = "CEP")]
        public string End_cep { get; set; }

        [Required]
        [Display(Name = "Endereço")]
        public string End_logradouro { get; set; }

        [Required]
        [Display(Name = "Número")]
        public string End_numero { get; set; }

        [Required]
        [Display(Name = "Bairro")]
        public string End_bairro { get; set; }

        [Display(Name = "Complemento")]
        public string End_complemento { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        public string End_cidade { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string End_estado { get; set; }

        [Display(Name = "Instruções Especiais")]
        public string End_instrucao { get; set; }


        //public int Usu_id { get; set; }
        //public virtual Usu_usuario Usu_Usuario { get; set; }

        //public int Ent_id { get; set; }
        //public virtual Ent_entrega Ent_Entrega { set; get; }
    }
}