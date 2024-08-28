using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManeger
{
    public class Biblioteca : IBiblioteca
    {
        private List<Livro> livrosDisponiveis = new List<Livro>();
        private List<Livro> livrosEmprestados = new List<Livro>();
        private List<Leitor> listaLeitores = new List<Leitor>();
        private List<Emprestimo> listaEmprestimo = new List<Emprestimo>();

        public IReadOnlyList<Livro> LivrosDisponiveis => livrosDisponiveis.AsReadOnly();
        public IReadOnlyList<Livro> LivrosEmprestados => livrosEmprestados.AsReadOnly();
        public IReadOnlyList<Leitor> ListaLeitores => listaLeitores.AsReadOnly();
        public IReadOnlyList<Emprestimo> ListaEmprestimo => listaEmprestimo.AsReadOnly();

        public void AdicionarLivro(Livro livro)
        {
            livrosDisponiveis.Add(livro);
            ExibirMensagemESair("\nPressione qualquer tecla p/sair! ");
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
            ExibirMensagemESair("\nPressione qualquer tecla p/sair! ");
        }
        public void AdicionarLeitor(Leitor leitor)
        {
            listaLeitores.Add(leitor);
            ExibirMensagemESair("\nPressione qualquer tecla p/sair! ");
        }
        public void ExibirLeitores()
        {
            if (listaLeitores.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("LISTA VAZIA");
                ExibirMensagemESair("\nPressione qualquer tecla p/continuar! ");
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
            switch (opcao)
            {
                case 1:
                    RealizarEmprestimo();
                    break;
                case 2:
                    DevolverEmprestimo();
                    break;
                case 3:
                    ExibirEmprestimos();
                    break;
                default:
                    Console.WriteLine("Opcao invalida");
                    break;
            }
        }
        public void RealizarEmprestimo()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("REALIZANDO EMPRÉSTIMO: \n");

                var livro = ObterLivroPorId();
                if (livro == null) return;

                var leitor = ObterLeitorPorId();
                if (leitor == null) return;

                var dataDevolucao = ObterDataDevolucao();
                if (dataDevolucao == DateTime.MinValue) return;

                CriarEmprestimo(livro, leitor, dataDevolucao);
                ExibirMensagemESair("Empréstimo realizado com sucesso!");
            }
            catch (Exception ex)
            {
                ExibirMensagemESair($"Ocorreu um erro: {ex.Message}. Pressione qualquer tecla para continuar.");
            }
        }

        private Livro ObterLivroPorId()
        {
            Console.Write("Digite o ID do Livro: ");
            if (!int.TryParse(Console.ReadLine(), out int idLivro))
            {
                ExibirMensagemESair("ID de Livro inválido. Pressione qualquer tecla para voltar ao menu.");
                return null;
            }

            return livrosDisponiveis.FirstOrDefault(l => l.Id == idLivro);
        }

        private Leitor ObterLeitorPorId()
        {
            Console.Write("Digite o ID do Leitor: ");
            if (!int.TryParse(Console.ReadLine(), out int idLeitor))
            {
                ExibirMensagemESair("ID de Leitor inválido. Pressione qualquer tecla para voltar ao menu.");
                return null;
            }

            return listaLeitores.Find(c => c.Id == idLeitor);
        }

        private DateTime ObterDataDevolucao()
        {
            Console.Write("Digite a Data de Devolução (formato: yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataDevolucao))
            {
                ExibirMensagemESair("Data de devolução inválida. Pressione qualquer tecla para voltar ao menu.");
                return DateTime.MinValue;
            }

            return dataDevolucao;
        }

        private void CriarEmprestimo(Livro livro, Leitor leitor, DateTime dataDevolucao)
        {
            var emprestimo = new Emprestimo(livro, leitor, dataDevolucao);
            listaEmprestimo.Add(emprestimo);
            livrosDisponiveis.Remove(livro);
            livrosEmprestados.Add(livro);
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
        private void ExibirMensagemESair(string mensagem)
        {
            Console.WriteLine(mensagem);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
