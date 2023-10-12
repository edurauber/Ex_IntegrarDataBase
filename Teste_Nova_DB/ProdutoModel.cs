using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Teste_Nova_DB
{
    public class ProdutoModel : ICrud
    {
        public string connectString = "Server=localhost;Database=teste_db;User=root;Password=root;";
 
        public void Create()
        {
            ProdutoEntity produto = new ProdutoEntity();
            Console.Write("Digite o nome do produto: ");
            produto.NOME = Console.ReadLine();
            Console.Write("Digite a descrição: ");
            produto.DESCRICAO = Console.ReadLine();

            using (MySqlConnection conn = new MySqlConnection(connectString))
            {
                string sql = "INSERT INTO PRODUTO VALUE (NULL, @NOME, @DESCRICAO)";
                conn.Execute(sql, produto);
                Console.WriteLine($"Produto criado com sucesso em: {produto.ID} - {produto.NOME} {produto.DESCRICAO}");
            }

        }
        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            using (MySqlConnection conn = new MySqlConnection())
            {
                IEnumerable<ProdutoEntity> produtos = conn.Query<ProdutoEntity>("SELECT * FROM PRODUTO");
                foreach (ProdutoEntity produto in produtos)
                {
                    produto.Mostrar();
                }
            }
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
