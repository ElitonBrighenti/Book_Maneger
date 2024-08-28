using System.Security.Cryptography.X509Certificates;

namespace BookManeger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBiblioteca biblioteca = new Biblioteca();
            var menu = new Menu(biblioteca);

            while (true)
            {
                int opcao = menu.Cabecalho();
                menu.ProcessarOpcao(opcao);
                
            }
        }
    }
}

