using ProjetoAula05.Controllers;

namespace ProjetoAula05
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var produtoController = new ProdutoController();

            try
            {
                Console.WriteLine("(1) Cadastrar Produto");
                Console.WriteLine("(2) Atualizar Produto");
                Console.WriteLine("(3) Excluir Produto");
                Console.WriteLine("(4) Consultar Produtos");

                Console.Write("\nEntre com a opção desejada: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        produtoController.CadastrarProduto();
                        break;

                    case 2:
                        produtoController.AtualizarProduto();
                        break;

                    case 3:
                        produtoController.ExcluirProduto();
                        break;

                    case 4:
                        produtoController.ConsultarProdutos();
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida.");
                        break;
                }

                Console.Write("\nDeseja continuar? (S, N)..: ");
                var escolha = Console.ReadLine();

                if (escolha == "S")
                {
                    Console.Clear(); //limpar a tela do Console
                    Main(args); //recursividade
                }
                else
                {
                    Console.WriteLine("\nFIM DO PROGRAMA!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nErro: {e.Message}");
            }

            Console.ReadKey();
        }
    }
}



