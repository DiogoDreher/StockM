using Stock_manager.DomainModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Stock_manager
{
    /// <summary>
    /// Interaction logic for Stock.xaml
    /// </summary>
    public partial class Stock : Window
    {
        private ObservableCollection<Produto> _contentor;
        private Produto _editProduto;
        private string nome = "";
        public Stock()
        {
            InitializeComponent();
            listar(nome);
            resetForm();
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            nome = txtNome.Text;
            listar(nome);
            if (nome == "")
            {
                Header.Text = "Produtos";
            }
            else
            {
                Header.Text = nome;
            }

            resetForm();
        }

        private void ListViewProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _editProduto = ListViewProducts.SelectedItem as Produto;
            if (_editProduto != null)
            {
                //MessageBox.Show(_editProduto.getInfo());
                txtName.Text = _editProduto.Nome;
                txtCat.Text = _editProduto.Categoria;
                txtPreco.Text = _editProduto.Preco.ToString();
                txtStock.Text = _editProduto.Stock.ToString();
                btnAttStk.Content = "Atualizar Stock";
            }
        }

        private void BtnAttStk_Click(object sender, RoutedEventArgs e)
        {
            if (txtStock.Text != "")
            {
                Produto_Helper_CRUD phc = new Produto_Helper_CRUD(App.ligacaoBD);
                Produto p;

                if (_editProduto == null)
                {
                    p = new Produto();
                }
                else
                {
                    p = _editProduto;
                }
                p.Nome = txtName.Text;
                p.Categoria = txtCat.Text;
                p.Preco = Convert.ToDecimal(txtPreco.Text);
                try
                {
                    p.Stock = Convert.ToInt32(txtStock.Text);
                }
                catch 
                {
                    p.Stock = 0;
                }
                string status = phc.atualizar(p);
                if (status != "")
                {
                    MessageBox.Show("Erro: " + status);
                }
                else
                {
                    resetForm();
                    nome = "";
                    listar(nome);
                }

            }
            else
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!!");
            }
        }

        private void listar(string nome)
        {
            Produto_Helper_CRUD phc = new Produto_Helper_CRUD(App.ligacaoBD);
            if (nome == "")
            {
                _contentor = new ObservableCollection<Produto>(phc.list());
            }
            else
            {
                _contentor = new ObservableCollection<Produto>(phc.list(nome));
            }

            ListViewProducts.ItemsSource = _contentor;
        }

        private void resetForm()
        {
            txtName.Text = "";
            txtCat.Text = "";
            txtPreco.Text = "";
            txtStock.Text = "";
            _editProduto = null;
            btnAttStk.Content = "Adicionar";
        }
    }
}
