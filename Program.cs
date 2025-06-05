using MySql.Data.MySqlClient;
using System;
using ZstdSharp.Unsafe;
using Trabalho_Produto.ultilitarios;

class Program
{
    static void Main(string[] args)
    {
        int opcao;
        do
        {
            Console.WriteLine("=== Menu Cadastro Produtos ===");
            Console.WriteLine("");
            Console.WriteLine("1 - Cadastrar Produtos");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Atualizar Produtos");
            Console.WriteLine("4 - Deletar Produtos");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("");
                    CadastrarProdutos();
                    Console.WriteLine("");
                    break;
                case 2:
                    Console.WriteLine("");
                    ListarProdutos();
                    Console.WriteLine("");
                    break;
                case 3:
                    Console.WriteLine("");
                    AtualizarProdutos();
                    Console.WriteLine("");
                    break;
                case 4:
                    Console.WriteLine("");
                    DeletarProdutos();
                    Console.WriteLine("");
                    break;
                case 0:
                    Console.WriteLine("");
                    Console.WriteLine("Saindo...");
                    Console.WriteLine("");
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }

        } while (opcao != 0);
    }

    static void CadastrarProdutos()
    {
        try
        {
            Conexao.Conectar();
            Produtos prod = new Produtos();

            Console.Write("Nome Produto: ");
            prod.nomeproduto = Console.ReadLine();

            Console.Write("Preço: ");
            prod.preco = Console.ReadLine();

            Console.Write("Quantidade Estoque: ");
            prod.QuantidadeEstoque = Console.ReadLine();

            Console.Write("Categoria: ");
            prod.categoria = Console.ReadLine();

            Console.Write("Data de Validade (AAAA-MM-DD): ");
            prod.validade = DateOnly.Parse(Console.ReadLine());

            Console.Write("Marca: ");
            prod.marca = Console.ReadLine();

            Console.Write("Unidade: ");
            prod.unidade = Console.ReadLine();

            Cadastro_Produto cadastro_prod = new Cadastro_Produto();
            cadastro_prod.Insert(prod);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    static void ListarProdutos()
    {
        try
        {
            Cadastro_Produto cadastro_prod = new Cadastro_Produto();
            var produto = cadastro_prod.List();

            foreach (var produto in produto)
            {
                Console.WriteLine($"ID: {produto.idProduto}, Nome: {produto.nomeproduto}, Preço: {produto.preco}, Quantidade Estoque: {produto.QuantidadeEstoque}, Categoria: {produto.categoria}, Data de Validade: {produto.validade}, Marca: {produto.marca}, Unidade: {produto.unidade}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void AtualizarProduto()
    {
        try
        {
            Conexao.Conectar();
            Produto prod = new Produto();

            Console.Write("ID do Produto a ser atualizado: ");
            prod.idProduto = int.Parse(Console.ReadLine());

            Console.Write("Novo Nome do Produto: ");
            prod.pruduto = Console.ReadLine();

            Console.Write("Novo Preço: ");
            prod.preco = Console.ReadLine();

            Console.Write("Nova Quantidade: ");
            prod.QuantidadeEstoque = Console.ReadLine();

            Console.Write("Nova Categoria: ");
            prod.categoria = Console.ReadLine();

            Console.Write("Nova Data de Validade (AAAA-MM-DD): ");
            prod.validade = DateOnly.Parse(Console.ReadLine());

            Console.Write("Novo Marca: ");
            prod.marca = Console.ReadLine();

            Console.Write("Nova Unidade: ");
            prod.unidade = Console.ReadLine();

            Cadastro_Produto cadastro_prod = new Cadastro_Produto();
            cadastro_prod.Update(prod);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void DeletarProduto()
    {
        try
        {
            Conexao.Conectar();
            Produto prod = new Produto();

            Console.Write("ID do Produto a ser deletado: ");
            prod.idProduto = int.Parse(Console.ReadLine());

            Cadastro_Produto cadastro_prod = new Cadastro_Produto();
            cadastro_prod.Delete(prod);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}