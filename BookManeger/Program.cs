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
                        biblioteca01.AdicionarEmprestimo();
                        return;
                    case 4:
                        biblioteca01.ExibirLivros();
                        return;
                    case 5:
                        biblioteca01.ExibirLeitores();
                        return;
                    case 0:
                        return;
                }
            }
            //DateTime dataDevolucao = new DateTime(2024, 8, 15);
        }
    }
}
