using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.ViewModels
{
    public class CadastroViewModel
    {
        [EmailAddress]
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        //[MaxLength(11)]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(18)]
        [DataType(DataType.Password)]
        [RegularExpression("^.*(?=.{8,})(?=.*[\\d])(?=.*[A-Z])(?=.*[a-z])(?=.*[\\W]).*$",
        ErrorMessage = "Senha deve conter no mínimo 8 caracteres e no máximo 18. Esses caracteres devem ter entre eles uma letra maíuscula e uma mínuscula, um número e um caracter especial")]
        public string Senha { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(18)]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        [Display(Name = "Confirmar senha")]
        public string ConfirmarSenha { get; set; }
    }
}