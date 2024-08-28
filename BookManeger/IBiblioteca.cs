using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManeger
{
    public interface IBiblioteca
    {
        void AdicionarLivro(Livro livro);
        void ExibirLivrosDisponiveis();
        void AdicionarLeitor(Leitor leitor);
        void ExibirLeitores();
        void SelecionarEmprestimo(int opcao);
        void RealizarEmprestimo();
        void DevolverEmprestimo();
        void ExibirEmprestimos();
    }
}
