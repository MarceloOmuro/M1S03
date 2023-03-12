using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoPareAqui
{
    public class Ticket
    {
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public bool Ativo { get; set; }

        public Ticket()
        {
        }

        public Ticket(DateTime entrada, DateTime saida, bool ativo)
        {
            if (entrada > saida)
            {
                throw new ArgumentException("A data de entrada deve ser anterior à data de saída.");
            }
            Entrada = entrada;
            Saida = saida;
            Ativo = ativo;
        }

        public TimeSpan CalcularTempo()
        {
            return Saida - Entrada;
        }

        public decimal CalcularValor()
        {
            decimal valor = (decimal)CalcularTempo().TotalMinutes * 0.09m;
            return Math.Round(valor, 2);
        }
    }
}