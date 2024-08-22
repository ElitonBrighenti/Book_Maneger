using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManeger
{
    public class Biblioteca
    {
        public List<Livro> livrosDisponiveis = new List<Livro>();
        public List<Livro> livrosEmprestados = new List<Livro>();
        public List<Leitor> listaLeitores = new List<Leitor>();
        public List<Emprestimo> listaEmprestimo = new List<Emprestimo>();

        public void AdicionarLivro(Livro livro)
        {
            livrosDisponiveis.Add(livro);
            Console.WriteLine("\nPressione qualquer tecla p/sair! ");
            Console.ReadKey();
            Console.Clear();

        }
        public void AdicionarLeitor(Leitor leitor)
        {
            listaLeitores.Add(leitor);
            Console.WriteLine("\nPressione qualquer tecla p/sair! ");
            Console.ReadKey();
            Console.Clear();
        }
        public void ExibirLivros()
        {
            Console.Clear();
            Console.WriteLine("Exibindo Livros: \n");
            foreach (var item in livrosDisponiveis)
            {
                Console.WriteLine($"ID Livro: {item.Id}");
                Console.WriteLine(item.Titulo);
                Console.WriteLine(item.Autor);
                Console.WriteLine(item.AnoPublicacao);
                Console.WriteLine($"{item.QuantidadeDisponivel}\n");
            }
            Console.WriteLine("Pressione qualquer tecla p/continuar! ");
            Console.ReadKey();
        }
        public void ExibirLeitores()
        {
            if(listaLeitores.Capacity == 0)
            {
                Console.Clear();
                Console.WriteLine("LISTA VAZIA");
                Console.WriteLine("\nPressione qualquer tecla p/continuar! ");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
            Console.Clear();
            Console.WriteLine("Exibindo Leiores: \n");
            foreach (var item in listaLeitores)
            {
                Console.WriteLine($"ID Leitor: {item.Id}");
                Console.WriteLine(item.NomeCompleto);
                Console.WriteLine($"{item.Idade}\n");
            }
            Console.WriteLine("Pressione qualquer tecla p/continuar! ");
            Console.ReadKey();
            Console.Clear();

            }
        }
        public void AdicionarEmprestimo()
        {
            Console.Clear();
            Console.WriteLine("REALIZANDO EMPRÉSTIMO: ");

            Console.Write("Digite o ID do Livro: ");
            int idLivro = int.Parse(Console.ReadLine()!);
            Console.Write("Digite o ID do Leitor: ");
            int idLeitor = int.Parse(Console.ReadLine()!);
            Console.Write("Digite a Data de Devolução (formato: yyyy-MM-dd): ");
            DateTime dataDevolucao = DateTime.Parse(Console.ReadLine()!);

            //Livro livro = null!;
            //foreach (var item in livrosDisponiveis)
            //{
            //    if (item.Id == idLivro)
            //    {
            //        livro = item;
            //        break;
            //    }
            //}

            Livro livro = livrosDisponiveis.FirstOrDefault(l => l.Id == idLivro)!;


            //Leitor leitor = null!;
            //foreach (var item in listaLeitores)
            //{
            //    if (item.Id == idLeitor)
            //    {
            //        leitor = item;
            //        break;
            //    }
            //}

            Leitor leitor = listaLeitores.Find(c => c.Id == idLeitor)!;

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            if (leitor == null)
            {
                Console.WriteLine("Leitor não encontrado.");
                return;
            }

            Emprestimo emprestimo = new Emprestimo(livro, leitor, dataDevolucao);
            listaEmprestimo.Add(emprestimo);
            livrosDisponiveis.Remove(livro);
            livrosEmprestados.Add(livro);
            Console.WriteLine("Empréstimo realizado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para sair.");
            Console.ReadKey();

        }
    }
}
