using Dapper;
using SistemaCadastroProd.DBContext;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace SistemaCadastroProd.Models
{
    public class ProductDAL : IProductDAL
    {
        string connectionString = @"Data Source=localhost\SQLEXPRESS;Database=xpto;Trusted_Connection=True";
        public void AddProduto(Produto produto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "INSERT INTO Produto(CodigoProduto, Descricao, TipoProduto, DataLancamento, Valor) VALUES(@CodigoProduto, @Descricao, @TipoProduto, @DataLancamento, @Valor)";

                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CodigoProduto", produto.CodigoProduto);
                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@TipoProduto", produto.TipoProduto);
                cmd.Parameters.AddWithValue("@DataLancamento", produto.DataLancamento);
                cmd.Parameters.AddWithValue("@Valor", produto.Valor);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteProduto(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Delete from Produto where Id = @Id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public IEnumerable<Produto> GetAllProdutos()
        {
            List<Produto> lstproduto = new List<Produto>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT Id, CodigoProduto,Descricao,TipoProduto,DataLancamento, Valor from Produto", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Produto produto = new Produto();
                    produto.Id = Convert.ToInt32(rdr["Id"]);
                    produto.CodigoProduto = rdr["CodigoProduto"].ToString();
                    produto.Descricao = rdr["Descricao"].ToString();
                    produto.TipoProduto = rdr["TipoProduto"].ToString();
                    produto.DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]);
                    produto.Valor = Convert.ToInt32(rdr["Valor"]);
                    lstproduto.Add(produto);
                }
                con.Close();
            }
            return lstproduto;
        }

        public Produto GetProduto(int? id)
        {
            Produto produto= new Produto();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Produto WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    produto.Id = Convert.ToInt32(rdr["Id"]);
                    produto.CodigoProduto = rdr["CodigoProduto"].ToString();
                    produto.Descricao = rdr["Descricao"].ToString();
                    produto.TipoProduto = rdr["TipoProduto"].ToString();
                    produto.DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]);
                    produto.Valor = Convert.ToInt32(rdr["Valor"]);
                }
            }
            return produto;
        }

        public void UpdateProduto(Produto produto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Update Produto set CodigoProduto = @CodigoProduto, Descricao = @Descricao, TipoProduto =@TipoProduto, DataLancamento = @DataLancamento, Valor= @Valor where Id = @Id";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", produto.Id);
                cmd.Parameters.AddWithValue("@CodigoProduto", produto.CodigoProduto);
                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@TipoProduto", produto.TipoProduto);
                cmd.Parameters.AddWithValue("@DataLancamento", produto.DataLancamento);
                cmd.Parameters.AddWithValue("@Valor", produto.Valor);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
