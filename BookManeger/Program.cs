using System.Security.Cryptography.X509Certificates;

namespace BookManeger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca01 = new Biblioteca();
            Menu menu = new Menu();

            while (true)
            {
                int opcao = menu.Cabecalho();
                //if (opcao == 0)
                //{
                //}
                AcessoMenu(opcao);
            }

            void AcessoMenu(int opcao)
            {
                switch (opcao)
                {
                    case 1:
                        biblioteca01.AdicionarLivro(menu.CadastroLivro());
                        return;
                    case 2:
                        biblioteca01.AdicionarLeitor(menu.CadastroLeitor());
                        return;
                    case 3:
                        biblioteca01.SelecionarEmprestimo(menu.MenuEmprestimo());
                        return;
                    case 4:
                        biblioteca01.ExibirLivrosDisponiveis();
                        return;
                    case 5:
                        biblioteca01.ExibirLeitores();
                        return;
                    case 6:
                        return;
                    case 0:
                        break;
                }
            }
            //DateTime dataDevolucao = new DateTime(2024, 8, 15);
        }
    }
}
