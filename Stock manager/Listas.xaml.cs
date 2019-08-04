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
    /// Interaction logic for Listas.xaml
    /// </summary>
    public partial class Listas : Window
    {
        private ObservableCollection<Lista> _contentor;
        public Listas()
        {
            InitializeComponent();
            listar();
            resetForm();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "" && txtDono.Text != "")
            {
                Listas_Helper_CRUD lhc = new Listas_Helper_CRUD(App.ligacaoBD);
                Lista l = new Lista();

                l.Nome = txtName.Text;
                l.Dono = txtDono.Text;

                string status = lhc.inserir(l);
                if (status != "")
                {
                    MessageBox.Show("Erro: " + status);
                }
                else
                {
                    resetForm();
                    listar();
                }
            }
            else
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!!");
            }
        }

        private void ListViewLists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listar()
        {
            Listas_Helper_CRUD lhc = new Listas_Helper_CRUD(App.ligacaoBD);
            _contentor = new ObservableCollection<Lista>(lhc.list());
            ListViewLists.ItemsSource = _contentor;
        }

        private void resetForm()
        {
            txtName.Text = "";
            txtDono.Text = "";
        }
    }
}
