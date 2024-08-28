using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManeger
{
    public class Menu
    {
        private readonly IBiblioteca _biblioteca;

        public Menu(IBiblioteca biblioteca)
        {
            _biblioteca = biblioteca;
        }

        public void ProcessarOpcao(int opcao)
        {
            try
            {
                switch (opcao)
                {
                    case 1:
                        _biblioteca.AdicionarLivro(MenuCadastroLivro());
                        break;
                    case 2:
                        _biblioteca.AdicionarLeitor(MenuCadastroLeitor());
                        break;
                    case 3:
                        _biblioteca.SelecionarEmprestimo(MenuEmprestimo());
                        break;
                    case 4:
                        _biblioteca.ExibirLivrosDisponiveis();
                        break;
                    case 5:
                        _biblioteca.ExibirLeitores();
                        break;
                    case 6:
                        _biblioteca.ExibirEmprestimos();
                        break;
                    case 0:
                        Environment.Exit(0); // Encerra o aplicativo
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }
        public int Cabecalho()
        {
            Console.Clear();
            Console.WriteLine("SYSTEM BOOK MANEGER \n");
            Console.WriteLine("1 - Cadastrar Livro");
            Console.WriteLine("2 - Cadastrar Leitor");
            Console.WriteLine("3 - Menu Emprestimo");
            Console.WriteLine("4 - Listar livros disponiveis");
            Console.WriteLine("5 - Listar leitores cadastrados");
            Console.WriteLine("6 - Listar livros emprestados");
            Console.WriteLine("0 - Sair \n");

            return ObterOpcaoMenu("Digite a sua opção: ");
        }

        public Livro MenuCadastroLivro()
        {
            Console.Clear();
            Console.Write("Titulo Livro: ");
            string nomeLivro = Console.ReadLine()!;
            Console.Write("Autor Livro: ");
            string autorLivro = Console.ReadLine()!;
            Console.WriteLine("Ano Publicação: ");
            int anoPublicacao = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Quantidade Disponivel: ");
            int quantidadeDisponivel = int.Parse(Console.ReadLine()!);
            Livro livro = new Livro(nomeLivro, autorLivro, anoPublicacao, quantidadeDisponivel);
            return livro;
        }
        public Leitor MenuCadastroLeitor()
        {
            Console.Clear();
            Console.Write("Nome Leitor: ");
            string nomeLeitor = Console.ReadLine() !;
            Console.Write("Idade Leitor: ");
            int idadeLeitor = int.Parse(Console.ReadLine()!) ;
            Leitor leitor = new Leitor(nomeLeitor, idadeLeitor);
            return leitor;
        }

        public int MenuEmprestimo()
        {
            Console.Clear();
            Console.Write("FAÇA SEU EMPRESTIMO OU DEVOLUÇÃO: \n\n" +
                "1 - EMPRESTAR LIVRO\n" +
                "2 - DEVOLVER LIVRO\n" +
                "3 - EXIBIR EMPRÉSTIMOS: \n\n" +
                "Digite a opção: ");
            return int.Parse(Console.ReadLine()!);
        }
        private int ObterOpcaoMenu(string mensagem)
        {
            int opcao;
            while (true) 
            {
                Console.Write(mensagem); 
                if (int.TryParse(Console.ReadLine(), out opcao)) 
                {
                    return opcao; 
                }
                Console.WriteLine("Opção inválida. Tente novamente."); 
            }
        }

    }
}


