using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BookManeger
{
    public class Livro
    {
        // Variável estática para armazenar o próximo ID disponível
        private static int proximoId = 1;
        // Propriedade para armazenar o ID de cada instância
        public int Id { get; private set; }

        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public int QuantidadeDisponivel { get; set; }

        public Livro() { }

        public Livro(string titulo, string autor, int anoPublicacao, int quantidadeDisponivel)
        {
            Id = proximoId;
            proximoId++;
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            QuantidadeDisponivel = quantidadeDisponivel;    
        }
    }
}
