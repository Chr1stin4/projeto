using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto
{
    public class Usuario1
    {
        private int _id;
        private string _Nome;
        private string _senha;

        public Usuario1( string nome,
            string senha)
        {
            Nome = nome;
            Senha = senha;
        }
        public Usuario1(int id,
            string nome,
            string senha)
        {
            Nome = nome;
            Senha = senha;
            Id = id;
        }
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }

        public string Nome
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Campo nome esta vazio");
                _Nome = value;
            }
            get { return _Nome; }
        }

        public string Senha
        {
            set { _senha = value; }
            get { return _senha; }
        }
    }
}
