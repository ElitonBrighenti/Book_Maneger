namespace BookManeger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Livro livro1 = new Livro("O alquimista", "Paulo Celho", 1998, 5);
            Livro livro2 = new Livro("Banana", "Aleatorio", 2005, 10);

            Biblioteca biblioteca01 = new Biblioteca();

            biblioteca01.AdicionarLibro(livro1);
            biblioteca01.AdicionarLibro(livro2);






            DateTime dataDevolucao = new DateTime(2024, 8, 15);
        }
    }
}
