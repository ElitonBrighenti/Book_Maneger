using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManeger
{
    public class Leitor
    {
        public string  NomeCompleto { get; set; }
        public int Idade { get; set; }

        public int QuantidadeEmprestimo { get; set; }
        
        public Leitor(string nome, int idade) 
        {
            NomeCompleto = nome;
            Idade = idade;
        }
    }
}
