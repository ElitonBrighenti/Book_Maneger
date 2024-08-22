using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManeger
{
    public class Emprestimo
    {
        // Variável estática para armazenar o próximo ID disponível
        private static int proximoId = 1;
        // Propriedade para armazenar o ID de cada instância
        public int Id { get; private set; }
        public Livro LivroEmprestado { get; set; }
        public Leitor Leitor { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        public Emprestimo() 
        {
            Id = proximoId;
            proximoId++;
        } 
        public Emprestimo(Livro livro, Leitor leitor, DateTime dataDevolucao)
        {
            Id = proximoId;
            proximoId++;
            LivroEmprestado = livro;
            Leitor = leitor;
            DataEmprestimo = DateTime.Now;
            DataDevolucao = dataDevolucao;
        }

        public double CalcularMulta(DateTime dataDevolucao)
        {
            const double VALOR_MULTA = 2;
            int diasAtraso = (DateTime.Now - dataDevolucao).Days;

            if (diasAtraso > 0)
            {
                return diasAtraso * VALOR_MULTA;
            }
            return 0;
        }
    }
}
