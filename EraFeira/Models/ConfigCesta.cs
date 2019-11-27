using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //biblioteca importada
using System.Linq;
using System.Web;

namespace EraFeira.Models
{
    public class ConfigCesta
    {
        //intervalo entre uma cesta e outra - tabela assinatura
        public int Tempo { set; get; }

        // descrição - tabela assinatura
        [Display (Name = "Dercrição")]
        public string Descricao { set; get; }

        //Se é cesta igual ou diferente - tabela assinatura
        public bool TipoCesta { set; get; }

        // Se está vigente ou encerrado, começa vigente - tabela assinatura
        public bool Status { set;  get; }

        // nome da cesta criada - tabela cesta
        public string Nome { set; get; }

        // marca o dia que a cesta foi criada - tabela cesta
        [DataType(DataType.Date)]
        public DateTime Criação { set; get; }

        // o preço da cesta - tabela cesta
        public double ValorTotal { set; get; }
    }
}