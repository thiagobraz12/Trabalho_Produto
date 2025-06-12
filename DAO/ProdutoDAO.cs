using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Produto.mapeamento;
using Trabalho_Produto.ultilitarios;

namespace Trabalho_Produto.DAO
{
    internal class ProdutoDAO
    {
        public void Insert(Produto produto)
        {
            try
            {
                string validade = produto.validade.ToString("yyyy-MM-dd");
                string sql = "INSERT INTO produto (nomeproduto,preco,quantidadeestoque,categoria,validade,marca,unidade) VALUES(@nomeproduto,@preco,@quantidadeestoque,@categoria,@validade,@marca,@unidade)";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                comando.Parameters.AddWithValue("@nomeproduto", produto.nomeproduto);
                comando.Parameters.AddWithValue("@preco", produto.preco);
                comando.Parameters.AddWithValue("@quantidadeestoque", produto.quantidadeestoque);
                comando.Parameters.AddWithValue("@categoria", produto.categoria);
                comando.Parameters.AddWithValue("@validade",validade);
                comando.Parameters.AddWithValue("@marca", produto.marca);
                comando.Parameters.AddWithValue("@unidade", produto.unidade);

                comando.ExecuteNonQuery();
                Console.WriteLine("");
                Console.WriteLine("Produto cadastrado com sucesso");
            }
            catch (Exception ex)
            {

                Console.WriteLine("erro " + ex.Message);
            }
        }
        public void Delete(Produto produto)
        {
            try
            {
                string sql = " DELETE FROM produto WHERE id_produto = @id_produto";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id_produto", produto.idproduto);
                comando.ExecuteNonQuery();
                Console.WriteLine("");
                Console.WriteLine("-- Produto excluido --");
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {

                throw new Exception($"erro: {ex.Message}");
            }
        }
        public void Update(Produto produto)
        {
            try
            {
                string validade = produto.validade.ToString("yyyy-MM-dd");
                string sql = "UPDATE produto SET nomeproduto = @nomeproduto, preco = @preco, quantidadeestoque = @quantidadeestoque, " +
                             "categoria = @categoria, validade = @validade, marca = @marca, unidade = @unidade where id_produto = @id_produto" +
                             "";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                comando.Parameters.AddWithValue("@nomeproduto", produto.nomeproduto);
                comando.Parameters.AddWithValue("@preco", produto.preco);
                comando.Parameters.AddWithValue("@quantidadeestoque", produto.quantidadeestoque);
                comando.Parameters.AddWithValue("@categoria", produto.categoria);
                comando.Parameters.AddWithValue("@validade", validade);
                comando.Parameters.AddWithValue("@marca", produto.marca);
                comando.Parameters.AddWithValue("@unidade", produto.unidade);
                comando.Parameters.AddWithValue("@id_produto", produto.idproduto);

                comando.ExecuteNonQuery();
                Console.WriteLine("");
                Console.WriteLine("-- Produto atualizado com sucesso --");
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }
        public List<Produto> List()
        {
            List<Produto> produtos = new List<Produto>();

            try
            {
                var sql = "SELECT * FROM produto ORDER BY nome";
                MySqlCommand command = new MySqlCommand(sql, Conexao.Conectar());
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Produto produto = new Produto();
                        produto.idproduto = dr.GetInt32("id_produto");
                        produto.nomeproduto = dr.GetString("nomeproduto");
                        produto.preco = dr.GetDouble("preco");
                        produto.quantidadeestoque = dr.GetInt32("quantidadeestoque");
                        produto.categoria = dr.GetString("categoria");
                        produto.validade = DateOnly.FromDateTime(dr.GetDateTime("validade"));
                        produto.marca = dr.GetString("marca");
                        produto.unidade = dr.GetString("unidade");
                        produtos.Add(produto);
                    }

                }
                Conexao.FecharConexao();

            }
            catch (Exception ex)
            {

                throw new Exception($"Erro{ex.Message}");
            }
            return produtos;
        }
    }
}
