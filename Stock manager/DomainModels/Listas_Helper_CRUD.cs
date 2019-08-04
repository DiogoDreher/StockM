using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_manager.DomainModels
{
    class Listas_Helper_CRUD
    {
        private string _ligacao;

        public Listas_Helper_CRUD(string ligacaoAUtilizar)
        {
            _ligacao = ligacaoAUtilizar;
        }

        public List<Lista> list()
        {
            List<Lista> listaADevolver = new List<Lista>();
            DataTable listaBruta = new DataTable();

            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlCommand pedido = new SqlCommand();
            SqlConnection numero = new SqlConnection(_ligacao);

            pedido.CommandType = CommandType.Text;
            pedido.CommandText = "SELECT * FROM Listas";

            telefone.SelectCommand = pedido;
            telefone.SelectCommand.Connection = numero;
            numero.Open();
            telefone.Fill(listaBruta);
            numero.Close();

            foreach (DataRow linha in listaBruta.Rows)
            {
                Lista l = new Lista(linha["guidLista"].ToString());
                l.Nome = linha["nome"].ToString();
                l.Dono = linha["dono"].ToString();
                l.Image = linha["image"].ToString();
                l.DataCriacao = Convert.ToDateTime(linha["dtCriacao"]);
                listaADevolver.Add(l);
            }

            return listaADevolver;
        }

        public string inserir(Lista l)
        {
            string erros = "";
            string sql1 = "INSERT INTO Listas (nome, dono, image) VALUES (@nome, @dono, @image)";
            
            try
            {
                SqlCommand pedido = new SqlCommand();
                pedido.Connection = new SqlConnection(_ligacao);
                pedido.CommandText = sql1;                

                pedido.CommandType = CommandType.Text;

                string nome = l.Nome.ToLower();
                nome = nome.Replace(" ", string.Empty);

                pedido.Parameters.AddWithValue("@nome", l.Nome);
                pedido.Parameters.AddWithValue("@dono", l.Dono);
                pedido.Parameters.AddWithValue("@image", nome + ".jpg");

                pedido.Connection.Open();
                pedido.ExecuteNonQuery();
                pedido.Connection.Close();
                pedido.Connection.Dispose();
                erros = "";
            }
            catch (Exception ex)
            {
                erros = ex.Message;
            }
            return erros;
        }
    }
}
