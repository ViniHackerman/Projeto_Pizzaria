﻿using System;
using System.Collections.Generic;

class Pizza
{
    public string Nome { get; set; }
    public List<string> Sabores { get; set; }
    public decimal Preco { get; set; }
    public string TelefoneCliente { get; set; } 

    public Pizza(string nome, List<string> sabores, decimal preco, string telefoneCliente)
    {
        Nome = nome;
        Sabores = sabores;
        Preco = preco;
        TelefoneCliente = telefoneCliente; 
    }
}

class Program
{
    static List<Pizza> listaDePizzas = new List<Pizza>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("ESCOLHA UMA OPÇÃO:");
            Console.WriteLine("1 - Adicionar pizza");
            Console.WriteLine("2 - Lista de pizzas");
            Console.WriteLine("3 - Sair");

            int opcao;
            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                switch (opcao)
                {
                    case 1:
                        CriarPizza();
                        break;
                    case 2:
                        ListarPizzas();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }
    }

   static void CriarPizza()
{
    do
    {
        Console.WriteLine("Digite o nome da pizza:");
        string nomePizza = Console.ReadLine();

        Console.WriteLine("Digite os sabores da pizza (separados por vírgula):");
        string saboresStr = Console.ReadLine();
        List<string> sabores = new List<string>(saboresStr.Split(','));

        Console.WriteLine("Digite o preço da pizza:");
        decimal preco;
        if (decimal.TryParse(Console.ReadLine(), out preco))
        {
            Console.WriteLine("Digite o telefone do cliente:");
            string telefoneCliente = Console.ReadLine();

            Pizza pizza = new Pizza(nomePizza, sabores, preco, telefoneCliente);
            listaDePizzas.Add(pizza);
            Console.WriteLine($"Pizza '{pizza.Nome}' adicionada com sucesso!");

            Console.WriteLine("Deseja adicionar outra pizza? (1 para Sim, 2 para Não)");
            int escolha;
            if (int.TryParse(Console.ReadLine(), out escolha) && escolha == 2)
            {
                break; 
            }
        }
        else
        {
            Console.WriteLine("Preço inválido. A pizza não foi adicionada.");
        }
    } while (true);
}


    static void ListarPizzas()
    {
        Console.WriteLine("Lista de pizzas:");
        foreach (var pizza in listaDePizzas)
        {
            Console.WriteLine($"Nome: {pizza.Nome}");
            Console.WriteLine("Sabores:");
            foreach (var sabor in pizza.Sabores)
            {
                Console.WriteLine($"- {sabor}");
            }
            Console.WriteLine($"Preço: R${pizza.Preco}");
            Console.WriteLine($"Telefone do Cliente: {pizza.TelefoneCliente}"); 
            Console.WriteLine();
        }
    }
}
