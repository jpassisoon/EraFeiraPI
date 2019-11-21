using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EraFeira.Models
{
    public class getItens
    {
        string id;
        string valor;
        string qtd;
        string total;
        string nomeCestausu;
        string identificacao;

        public string Id { get => id; set => id = value; }
        public string Valor { get => valor; set => valor = value; }
        public string Qtd { get => qtd; set => qtd = value; }
        public string Total { get => total; set => total = value; }
        public string NomeCestausu { get => nomeCestausu; set => nomeCestausu = value; }
        public string Identificacao { get => identificacao; set => identificacao = value; }
    }
}