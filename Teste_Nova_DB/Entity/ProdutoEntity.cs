using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Nova_DB.Entity
{
    public class ProdutoEntity
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string DESCRICAO { get; set; }
        public void Mostrar()
        {
            Console.WriteLine($"{ID} - {NOME} - {DESCRICAO}");
        }
    }
}
