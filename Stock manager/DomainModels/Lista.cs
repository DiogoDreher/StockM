using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_manager.DomainModels
{
    class Lista
    {
        public const int MAXNOME = 40;

        private string _guidLista;
        private string _nome;
        private string _dono;
        private string _image;
        private DateTime _dtCriacao;

        public string GuidLista {
            get {
                return _guidLista;
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

        public string Dono {
            get {
                return _dono;
            }
            set {
                _dono = value;
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

        public DateTime DataCriacao {
            get {
                return _dtCriacao;
            }
            set {
                _dtCriacao = Convert.ToDateTime(value);
            }
        }

        public Lista()
        {
            _guidLista = "";
            Nome = "";
            Dono = "";
            Image = "";
        }

        public Lista(string guidLista)
        {
            _guidLista = guidLista;
            Nome = "";
            Dono = "";
            Image = "";
        }

        public Lista(string guidLista, string nome, string dono, string image)
        {
            _guidLista = guidLista;
            Nome = nome;
            Dono = dono;
            Image = image;
        }

        public string getInfo()
        {
            return $"Nome: {Nome}\nDono: {Dono}\nData de Criacao: {DataCriacao}";
        }

    }
}
