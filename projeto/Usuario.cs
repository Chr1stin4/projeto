using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto
{
    public class Usuario
    {
        private int _id;
        private string _Nome;
        private string _senha;

        public Usuario( string nome,
            string senha)
        {
            Nome = nome;
            Senha = CriptografarSenha(senha);
        }
        public Usuario(int id,
            string nome,
            string senha)
        {
            Nome = nome;
            Senha = CriptografarSenha(senha);
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
        public static string CriptografarSenha(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Converte a senha em bytes
                byte[] bytes = Encoding.UTF8.GetBytes(senha);

                // Calcula o hash SHA-256
                byte[] hash = sha256.ComputeHash(bytes);

                // Converte o hash de volta para uma string hexadecimal
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    stringBuilder.Append(hash[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}
