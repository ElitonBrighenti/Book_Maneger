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
        public void ExibirLivrosDisponiveis()
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
        public void AdicionarLeitor(Leitor leitor)
        {
            listaLeitores.Add(leitor);
            Console.WriteLine("\nPressione qualquer tecla p/sair! ");
            Console.ReadKey();
            Console.Clear();
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
        public void SelecionarEmprestimo(int opcao)
        {
            if (opcao == 1)
                RealizarEmprestimo();
            if (opcao == 2)
                DevolverEmprestimo();
            if( opcao == 3)
                ExibirEmprestimos();
            else
                Console.WriteLine("Opcao invalida");
                return ;
        }
        public void RealizarEmprestimo()
        {
            Console.Clear();
            Console.WriteLine("REALIZANDO EMPRÉSTIMO: \n");

            Console.Write("Digite o ID do Livro: ");
            int idLivro = int.Parse(Console.ReadLine()!);
            
            Livro livro = livrosDisponiveis.FirstOrDefault(l => l.Id == idLivro)!;
            if (livro == null)
            {
                Console.WriteLine("\nLivro não encontrado, voltando para o menu");
                Thread.Sleep(1500);
                return;
            }

            Console.Write("Digite o ID do Leitor: ");
            int idLeitor = int.Parse(Console.ReadLine()!);

            Leitor leitor = listaLeitores.Find(c => c.Id == idLeitor)!;
            if (leitor == null)
            {
                Console.WriteLine("Leitor não encontrado.");
                return;
            }

            Console.Write("Digite a Data de Devolução (formato: yyyy-MM-dd): ");
            DateTime dataDevolucao = DateTime.Parse(Console.ReadLine()!);

            Emprestimo emprestimo = new Emprestimo(livro, leitor, dataDevolucao);
            listaEmprestimo.Add(emprestimo);
            livrosDisponiveis.Remove(livro);
            livrosEmprestados.Add(livro);
            Console.WriteLine("Empréstimo realizado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para sair.");
            Console.ReadKey();

        }
        public void DevolverEmprestimo()
        {
            Console.Clear();
            Console.WriteLine("REALIZANDO DEVOLUÇÃO: \n");

            Console.Write("Digite o ID do Livro: ");
            int idEmprestimo = int.Parse(Console.ReadLine()!);

            Emprestimo emprestimo = listaEmprestimo.FirstOrDefault(l => l.Id == idEmprestimo)!;
            if (emprestimo == null)
            {
                Console.WriteLine("\nLivro não encontrado, voltando para o menu");
                Thread.Sleep(1500);
                return;
            }
            Livro livroDevolvido = emprestimo.LivroEmprestado;


            livrosEmprestados.Remove(livroDevolvido);

            livrosDisponiveis.Add(livroDevolvido);

            listaEmprestimo.Remove(emprestimo);

            int valorMulta = (int)emprestimo.CalcularMulta(emprestimo.DataDevolucao);

            Console.WriteLine("Livro devolvido com Sucesso!");
            Console.WriteLine($"Valor de multa a pagar = R${valorMulta} reais");
            Console.ReadKey();
        }
        public void ExibirEmprestimos()
        {
            Console.Clear();
            Console.WriteLine("Exibindo empréstimos realizados: ");
            foreach (var item in listaEmprestimo)
            {
                Console.WriteLine($"\n Id empréstimo: {item.Id}");
                Console.WriteLine($"Livro Emprestado {item.LivroEmprestado.Titulo}");
                Console.WriteLine($"Leitor que Emprestou: {item.Leitor.NomeCompleto}\n");
            }    
            Console.ReadKey();
        }
    }
}
