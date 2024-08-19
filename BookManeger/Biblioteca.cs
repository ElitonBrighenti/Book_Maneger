using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManeger
{
    public class Biblioteca
    {
        public List<Livro> listaLivros = new List<Livro>();
        public List<Emprestimo> listaEmprestimo = new List<Emprestimo>();
        public List<Leitor> listaLeitores = new List<Leitor>();

        public void AdicionarLibro(Livro libro)
        {
            listaLivros.Add(libro);
        }
    }
}
