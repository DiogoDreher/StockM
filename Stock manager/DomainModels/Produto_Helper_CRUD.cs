using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_manager.DomainModels
{
    class Produto_Helper_CRUD
    {
        private string _ligacao;

        public Produto_Helper_CRUD(string ligacaoAUtilizar)
        {
            _ligacao = ligacaoAUtilizar;
        }

        public List<Produto> list()
        {
            List<Produto> listaADevolver = new List<Produto>();
            DataTable listaBruta = new DataTable();

            SqlDataAdapter telefone = new SqlDataAdapter();
            SqlCommand pedido = new SqlCommand();
            SqlConnection numero = new SqlConnection(_ligacao);

            pedido.CommandType = CommandType.Text;
            pedido.CommandText = "SELECT * FROM Produtos";

            telefone.SelectCommand = pedido;
            telefone.SelectCommand.Connection = numero;
            numero.Open();
            telefone.Fill(listaBruta);
            numero.Close();

            foreach (DataRow linha in listaBruta.Rows)
            {
                Produto p = new Produto(linha["guidProduto"].ToString());
                p.Nome = linha["nome"].ToString();
                p.Categoria = linha["categoria"].ToString();
                p.Image = linha["image"].ToString();
                p.Preco = Convert.ToDecimal(linha["preco"]);
                p.Stock = Convert.ToInt32(linha["stock"]);
                if (p.Stock == Convert.ToInt32(0))
                {
                    p.Color = "Red";
                }
                else
                {
                    p.Color = "Transparent";
                }
                listaADevolver.Add(p);
            }

            return listaADevolver;
        }
    }
}
