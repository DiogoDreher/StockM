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
        public Stock()
        {
            InitializeComponent();
            listar();
        }

        private void listar()
        {
            Produto_Helper_CRUD phc = new Produto_Helper_CRUD(App.ligacaoBD);
            _contentor = new ObservableCollection<Produto>(phc.list());
            ListViewProducts.ItemsSource = _contentor;
        }
    }
}
