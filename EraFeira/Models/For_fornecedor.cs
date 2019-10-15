using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.Models
{
    public class For_fornecedor
    {
        [Key]
        [Display(Name = "ID")]
        public int For_id { get; set; }

        public string For_nome { get; set; }

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string For_telefone { get; set; }

        [Required]
        [Display(Name = "CPF/CNPJ")]
        [MaxLength(15)]
        public string For_documento { get; set; }

        public int End_id { get; set; }
        public virtual End_endereco End_Endereco { get; set; }
    }
}