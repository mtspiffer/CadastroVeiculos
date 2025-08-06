using System;
using System.Collections.Generic;

class Veiculo
{
    public string Nome { get; set; }
    public int Ano { get; set; }

    public override string ToString()
    {
        return $"Nome: {Nome} | Ano: {Ano}";
    }
}

class Program
{
    static List<Veiculo> veiculos = new List<Veiculo>();

    static void Main()
    {
        bool executando = true;

        while (executando)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1 - Adicionar veículo");
            Console.WriteLine("2 - Listar veículos");
            Console.WriteLine("3 - Buscar veículo por nome");
            Console.WriteLine("4 - Remover veículo por nome");
            Console.WriteLine("5 - Editar veículo por nome");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarVeiculo();
                    break;
                case "2":
                    ListarVeiculos();
                    break;
                case "3":
                    BuscarVeiculo();
                    break;
                case "4":
                    RemoverVeiculo();
                    break;
                case "5":
                    EditarVeiculo();
                    break;
                case "0":
                    executando = false;
                    Console.WriteLine("Saindo do programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    static void AdicionarVeiculo()
    {
        Console.Write("Digite o nome do veículo: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o ano do veículo: ");
        if (!int.TryParse(Console.ReadLine(), out int ano))
        {
            Console.WriteLine("Ano inválido! Tente novamente.");
            return;
        }

        veiculos.Add(new Veiculo { Nome = nome, Ano = ano });
        Console.WriteLine("Veículo adicionado com sucesso!");
    }

    static void ListarVeiculos()
    {
        Console.WriteLine("\nVeículos cadastrados:");

        if (veiculos.Count == 0)
        {
            Console.WriteLine("Nenhum veículo cadastrado.");
            return;
        }

        foreach (var v in veiculos)
        {
            Console.WriteLine(v);
        }
    }
    
    static void EditarVeiculo()
    {
    Console.Write("Digite o nome do veículo a editar: ");
    string nome = Console.ReadLine();

    var encontrados = veiculos.FindAll(v => 
        v.Nome.IndexOf(nome, StringComparison.OrdinalIgnoreCase) >= 0);

    if (encontrados.Count == 0)
    {
        Console.WriteLine("Nenhum veículo encontrado.");
        return;
    }

    Console.WriteLine("Veículos encontrados:");
    for (int i = 0; i < encontrados.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {encontrados[i]}");
    }

    Console.Write("Escolha o número do veículo para editar: ");
    if (int.TryParse(Console.ReadLine(), out int indice) &&
        indice > 0 && indice <= encontrados.Count)
    {
        var veiculo = encontrados[indice - 1];

        Console.Write("Novo nome: ");
        veiculo.Nome = Console.ReadLine();

        Console.Write("Novo ano: ");
        if (int.TryParse(Console.ReadLine(), out int novoAno))
        {
            veiculo.Ano = novoAno;
            Console.WriteLine("✅ Veículo atualizado com sucesso.");
        }
        else
        {
            Console.WriteLine("❌ Ano inválido. Edição cancelada.");
        }
    }
    else
    {
        Console.WriteLine("❌ Seleção inválida.");
    }
    }


    static void BuscarVeiculo()
    {
        Console.Write("Digite o nome do veículo para buscar: ");
        string textoBusca = Console.ReadLine();

        var encontrados = veiculos.FindAll(v =>
            v.Nome.IndexOf(textoBusca, StringComparison.OrdinalIgnoreCase) >= 0);

        if (encontrados.Count > 0)
        {
            Console.WriteLine($"{encontrados.Count} veículo(s) encontrado(s):");
            foreach (var v in encontrados)
            {
                Console.WriteLine(v);
            }
        }
        else
        {
            Console.WriteLine("Nenhum veículo encontrado");
        }
    }



    static void RemoverVeiculo()
    {
        Console.Write("Digite o nome do veículo para remover: ");
        string nome = Console.ReadLine();

        var veiculo = veiculos.Find(v => v.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

        if (veiculo != null)
        {
            veiculos.Remove(veiculo);
            Console.WriteLine("Veículo removido com sucesso.");
        }
        else
        {
            Console.WriteLine("Veículo não encontrado.");
        }
    }
}
