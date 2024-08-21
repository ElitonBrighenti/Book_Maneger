using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManeger
{
    public class Menu
    {

        public int Cabecalho()
        {
            Console.Clear();
            int opcao;
            Console.WriteLine("SYSTEM BOOK MANEGER \n");
            Console.WriteLine("1 - Cadastrar Livro");
            Console.WriteLine("2 - Cadastrar Leitor");
            Console.WriteLine("3 - Realizar emprestimo");
            Console.WriteLine("4 - Listar livros disponiveis");
            Console.WriteLine("5 - Listando leitores disponiveis");
            Console.WriteLine("6 - Listar livros emprestados");
            Console.WriteLine("0 - Sair \n");

            Console.Write("Digite a sua opção: ");
            opcao = int.Parse(Console.ReadLine()!);
            return opcao;
        }

        public Livro CadastroLivro()
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
        public Leitor CadastroLeitor()
        {
            Console.Clear();
            Console.Write("Nome Leitor: ");
            string nomeLeitor = Console.ReadLine() !;
            Console.Write("Idade Leitor: ");
            int idadeLeitor = int.Parse(Console.ReadLine()!) ;
            Leitor leitor = new Leitor(nomeLeitor, idadeLeitor);
            return leitor;
        }

        public Emprestimo RealizarEmprestimo()
        {
            
            Console.WriteLine("Digite o nome do Leitor");
            return new Emprestimo();
        }
    }
}


