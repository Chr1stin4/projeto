using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto
{
    public class Usuario2
    {
        private int _id;
        private string _CPF;
        private string _email;

        public Usuario2( string CPF,
            string email)
        {
            Cpf = CPF;
            Email = email;
        }
        public Usuario2(int id,
            string CPF,
            string email)
        {
           Cpf = CPF;
           Email = email;
            Id = id;
        }
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }

        public string Cpf
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Campo nome esta vazio");
                _CPF = value;
            }
            get { return _CPF; }
        }

        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
    }
}
