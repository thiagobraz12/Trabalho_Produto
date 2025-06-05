using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Produto.mapeamento
{
    internal class Produto
    {
        public int Id { get; set; }
        public string nomeproduto { get; set; }
        public double preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string categoria { get; set; }
        public DateOnly validade { get; set; }
        public string marca { get; set; }
        public string unidade { get; set; }

    }
}
