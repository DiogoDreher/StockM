using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_manager.DomainModels
{
    class Produto
    {
        public const int MAXNOME = 40;

        private string _guidProduto;
        private string _nome;
        private string _categoria;
        private string _image;
        private string _color;
        private decimal _preco;
        private int _stock;


        public string GuidProduto {
            get {
                return _guidProduto;
            }
        }

        public string Nome {
            get {
                return _nome;
            }
            set {
                _nome = value;
                if (_nome.Length > MAXNOME)
                {
                    _nome = _nome.Substring(0, MAXNOME);
                }
            }
        }

        public string Categoria {
            get {
                return _categoria;
            }
            set {
                _categoria = value;
            }
        }

        public string Image {
            get {
                return _image;
            }
            set {
                _image = "/Assets/" + value;
            }
        }

        public decimal Preco {
            get {
                return _preco;
            }
            set {
                _preco = Convert.ToDecimal(value);
            }
        }

        public int Stock {
            get {
                return _stock;
            }
            set {
                _stock = value;
                if (_stock < 0)
                {
                    _stock = Convert.ToInt32(0);
                }
            }
        }

        public string Color {
            get {
                return _color;
            }
            set {
                _color = value;
            }
        }

        public Produto()
        {
            _guidProduto = "";
            Nome = "";
            Categoria = "";
            Image = "";
            Preco = 0M;
            Stock = 0;
        }

        public Produto(string guidProduto)
        {
            _guidProduto = guidProduto;
            Nome = "";
            Categoria = "";
            Image = "/Assets/default.jpg";
            Preco = 0M;
            Stock = 0;
        }

        public Produto(string guidProduto, string nome, string cat, string image, decimal preco, int stock)
        {
            _guidProduto = guidProduto;
            Nome = nome;
            Categoria = cat;
            Image = image;
            Preco = preco;
            Stock = stock;
        }

        public string getInfo()
        {
            return $"Nome: {Nome}\nCategoria: {Categoria}\nPreço: {Preco}\nStock: {Stock}";
        }
    }
}
