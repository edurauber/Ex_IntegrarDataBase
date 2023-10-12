using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Nova_DB
{
    public interface ICrud
    {
        public void Create();
        public void Read();
        public void Update();
        public void Delete();        
    }
}
