﻿using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stock_manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStock_Click(object sender, RoutedEventArgs e)
        {
            Stock JanelaStock = new Stock();
            this.Close();
            JanelaStock.ShowDialog();
        }

        private void BtnListas_Click(object sender, RoutedEventArgs e)
        {
            Listas JanelaListas = new Listas();
            this.Close();
            JanelaListas.ShowDialog();
        }
    }
}
