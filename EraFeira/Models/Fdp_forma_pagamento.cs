using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.Models
{
    public class Fdp_forma_pagamento
    {
        [Key]
        public int Fpd_id { set; get; }

        [Display (Name = "Nome do Titular")]
        public string Fpd_nome_titular { set; get; }       

        [Display (Name = "Número do Cartão")]
        public string Fdp_numero_cartao { set; get; }

        [Display (Name = "Validade do Cartão")]
        public string Fdp_validade_cartao { set; get; }

        [Display (Name = "CVV")]
        public string Fdp_cvv_cartao { set; get; }

        [DataType(DataType.Date)]
        [Display (Name = "Data da Compra")]
        public DateTime Fpd_data_compra { set; get; }

        public int Ass_id { set; get; }
        public virtual Ass_assinatura Ass_Assinatura { set; get; }

        public int Stp_id { set; get; }
        public virtual Stp_status_pedido Stp_Status_Pedido { set; get; }
    }
}