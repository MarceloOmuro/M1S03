using System;
using System.Collections.Generic;
using EstacionamentoPareAqui;

List<Carro> ListaDeCarros = new List<Carro>();

while (true)
{
    Console.WriteLine("Bem vindo ao Estacionamento Pare Aqui, escolha uma opção:");
    Console.WriteLine("1 - Cadastrar Carro");
    Console.WriteLine("2 - Marcar Entrada");
    Console.WriteLine("3 - Marcar Saída");
    Console.WriteLine("4 - Consultar Histórico");
    Console.WriteLine("5 - Sair");
    Console.WriteLine();

    string opcao = Console.ReadLine();

    if (opcao == "1")
    {
        CadastrarCarro();
    }
    else if (opcao == "2")
    {
        MarcarEntrada();
    }

    else if (opcao == "3")
    {
        MarcarSaida();
    }
    else if (opcao == "4")
    {
        ConsultarHistórico();
    }
    else if (opcao == "5")
    {
        break; // quebra o loop while e encerra o programa
    }
    else
    {
        Console.WriteLine("Opção inválida, tente novamente.");
    }
}

void CadastrarCarro()
{
    Carro novoCarro = new Carro();

    Console.Write("Digite a placa do carro: ");
    novoCarro.Placa = Console.ReadLine();

    Console.Write("Digite o modelo do carro: ");
    novoCarro.Modelo = Console.ReadLine();

    Console.Write("Digite a cor do carro: ");
    novoCarro.Cor = Console.ReadLine();

    Console.Write("Digite a marca do carro: ");
    novoCarro.Marca = Console.ReadLine();

    ListaDeCarros.Add(novoCarro);

    Console.WriteLine("Carro cadastrado com sucesso.");
}

void MarcarEntrada()
{
    Carro carro = ObterCarro();
    if (carro == null)
    {
        Console.WriteLine(" Placa não cadastrada, favor cadastrar antes para gerar entrada. ");
        return;
    }
    else
    {
        if (carro.Tickets.Count == 0)
        {
            Ticket novoTicket = new Ticket();
            novoTicket.Entrada = DateTime.Now;
            novoTicket.Ativo = true;
            Console.WriteLine($" O Veículo placa {carro.Placa} entrou em {novoTicket.Entrada}. ");
            carro.Tickets.Add(novoTicket);
        }
        else
        {
            for (int index = 0; index < carro.Tickets.Count(); index++)
            {
                if (carro.Tickets[index].Ativo == false)
                {
                    Ticket novoTicket = new Ticket();
                    novoTicket.Entrada = DateTime.Now;
                    novoTicket.Ativo = true;
                    Console.WriteLine($" O Veículo placa {carro.Placa} entrou em {novoTicket.Entrada}. ");
                    carro.Tickets.Add(novoTicket);
                }
                else
                {
                    Console.WriteLine(" Este veículo já possui ticket ativo. ");
                }
            }
        }
    }
}
void MarcarSaida()
{
    Carro carro = ObterCarro();
    if (carro == null)
    {
        Console.WriteLine(" Veículo não encontrado. ");
        return;
    }
    if (carro.Tickets.Count == 0)
    {
        Console.WriteLine(" Veículo sem bilhete cadastrado. ");
        return;
    }
    for (int index = 0; index < carro.Tickets.Count(); index++)
    {
        if (carro.Tickets[index].Ativo == true)
        {
            carro.Tickets[index].Saida = DateTime.Now;
            carro.Tickets[index].Ativo = false;
            Console.WriteLine($" O Veículo placa {carro.Placa} saiu em {carro.Tickets[index].Saida} e deve pagar {carro.Tickets[index].CalcularValor()}. ");
            return;
        }
    }
    Console.WriteLine(" Veículo sem bilhete ativo. ");
}

void ConsultarHistórico()
{
    Carro carro = ObterCarro();
    if (carro.Tickets.Count == 0)
    {
        Console.WriteLine(" Veículo sem bilhete cadastrado. ");
    }
    for (int index = 0; index < carro.Tickets.Count(); index++)
    {
        if (carro.Tickets[index].Ativo == true)
        {
            Console.WriteLine($" Entrada veículo {carro.Placa} registrada. ");
        }
        else
        {
            Console.WriteLine($" O Veículo placa {carro.Placa} entro em {carro.Tickets[index].Entrada}, saiu em {carro.Tickets[index].Saida} e pagou{carro.Tickets[index].CalcularValor()}. ");
        }
    }
}

Carro ObterCarro()
{
    Console.WriteLine("Digite a placa do carro: ");
    string buscarPlaca = Console.ReadLine();

    // Verifica se a placa digitada está cadastrada na lista de carros
    foreach (Carro carro in ListaDeCarros)
    {
        if (buscarPlaca == carro.Placa)
        {
            return carro;
        }
    }
    Console.WriteLine("Placa não encontrada.");
    return null;
}
