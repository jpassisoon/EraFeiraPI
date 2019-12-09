using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EraFeira.Models
{
    public class getItens
    {
        string id;
        double valor;
        string qtd;
        double total;
        string nomeCestausu;
        string identificacao;
        int entregas;

        public string Id { get => id; set => id = value; }
        public double Valor { get => valor; set => valor = value; }
        public string Qtd { get => qtd; set => qtd = value; }
        public double Total { get => total; set => total = value; }
        public string NomeCestausu { get => nomeCestausu; set => nomeCestausu = value; }
        public string Identificacao { get => identificacao; set => identificacao = value; }
        public int Entregas { get => entregas; set => entregas = value; }
    }
}