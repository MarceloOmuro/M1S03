using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoPareAqui
{
    public class Carro
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Marca { get; set; }
        public List<Ticket> Tickets { get; set; }

        public Carro()
        {
            Tickets = new List<Ticket>();
        }

        public Carro(string placa, string modelo, string cor, string marca)
        {
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
            Marca = marca;
            Tickets = new List<Ticket>();
        }
    }

}