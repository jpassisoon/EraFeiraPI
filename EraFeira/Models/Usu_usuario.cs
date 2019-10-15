using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.Models
{
    public class Usu_usuario
    {
        [Key]
        public int Usu_id { get; set; }

        [MaxLength(15)]
        [Display(Name = "Nome")]
        public string Usu_nome { get; set; }

        [MaxLength(15)]
        [Display(Name = "Sobrenome")]
        public string Usu_sobrenome { get; set; }

        [Required]
        [MaxLength(45)]
        [Display(Name = "E-mail")]
        public string Usu_email { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Usu_senha { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de nascimento")]
        public DateTime Usu_data_nascimento { get; set; }

        [Required]
        //[MaxLength(11)]
        [Display(Name = "CPF")]
        public string Usu_Cpf { get; set; }

        [EnumDataType(typeof(Tipo))]
        [Display(Name = "Sexo")]
        public Tipo Usu_sexo { get; set; }
        public enum Tipo { feminino, masculino }

        //[MaxLength(10)]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string Usu_telefone { get; set; }

        //[MaxLength(11)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Celular")]
        public string Usu_celular { get; set; }
    }
}