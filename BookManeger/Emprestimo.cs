using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManeger
{
    public class Emprestimo
    {
        public Livro LivroEmprestado { get; set; }
        public Leitor Leitor { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        public Emprestimo() { } 
        public Emprestimo(Livro livro, Leitor leitor, DateTime dataDevolucao)
        {
            LivroEmprestado = livro;
            Leitor = leitor;
            DataEmprestimo = DateTime.Now;
            DataDevolucao = dataDevolucao;
        }

        public double CalcularMulta()
        {
            const double VALOR_MULTA = 2;
            int diasAtraso = (DateTime.Now - DataDevolucao).Days;

            if (diasAtraso > 0)
            {
                return diasAtraso + VALOR_MULTA;
            }
            return 0;
        }
    }
}
