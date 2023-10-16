using Teste_Nova_DB.Model;

namespace Teste_Nova_DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProdutoModel produto = new ProdutoModel();
            produto.Create();
        }
    }
}