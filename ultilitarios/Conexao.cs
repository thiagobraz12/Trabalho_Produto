using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Produto.ultilitarios
{
    internal class Conexao
    {
        public static MySqlConnection conexao;

        public static MySqlConnection Conectar()
        {
            try
            {
                string strconexao = "server=localhost;port=3306;uid=root;pwd=123456;database=CadastroProdutos";
                conexao = new MySqlConnection(strconexao);
                conexao.Open();
                //Console.WriteLine("Conectado!");
            }
            catch (Exception ex)
            {

                throw new Exception("erro ao conectar" + ex.Message);
            }
            return conexao;
        }
        public static void FecharConexao()
        {
            conexao.Clone();
        }
    }
}

