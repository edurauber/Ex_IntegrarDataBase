using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data;
using MySql.Data.MySqlClient;
using Teste_Nova_DB.Entity;

namespace Teste_Nova_DB.Model
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
            Read();
            Console.Write("Digite o código do item que deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (MySqlConnection conn = new MySqlConnection(connectString))
            {
                var parametro = new { ID = id };
                string sql = "DELETE FROM PRODUTOS WHERE ID = @ID";
                conn.Execute(sql, parametro);
                Console.WriteLine("Produto excluído com sucesso!");
            }
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

        public void OutroModoRead()
        {
            MySqlConnection connect = new MySqlConnection(connectString);
            connect.Open();
            string sql = "SELECT * FROM PRODUTO";
            MySqlCommand command = new MySqlCommand(sql, connect);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ID"]} - {reader["NOME"]} - {reader["DESCRICAO"]}");
                }
            }
        }

        public void Update()
        {
            Read();
            Console.Write("Digite o id do produto para alterar: ");
            int id = Convert.ToInt32(Console.ReadLine());
            using (MySqlConnection connect = new MySqlConnection(connectString))
            {
                string sql = "SELECT * FROM PRODUTO WHERE ID = @id";
                var parametro = new { ID = id };
                connect.Execute(sql, parametro);

            }
            ProdutoEntity produto = 
        }
    }
}
