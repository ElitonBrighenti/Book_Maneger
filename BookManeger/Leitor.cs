using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManeger
{
    public class Leitor
    {
        // Variável estática para armazenar o próximo ID disponível
        private static int proximoId = 1;

        // Propriedade para armazenar o ID de cada instância
        public int Id { get; private set; }
        public string  NomeCompleto { get; set; }
        public int Idade { get; set; }

        public int QuantidadeEmprestimo { get; set; }
        
        public Leitor(string nome, int idade) 
        {
            Id = proximoId;
            proximoId++;
            NomeCompleto = nome;
            Idade = idade;
        }
    }
}
