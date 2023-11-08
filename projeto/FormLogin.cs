using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            String usuario = textBox1.Text;
            String senha = textBox1.Text;
            //Criar objeto da classe UsuarioDAO
            UsuarioDAO user = new UsuarioDAO(); 
            //chamar o metodo que verifica o login
            //o usuário e senha existem na tabela
            if (user.Loginusuario(usuario,senha)) {
                Form1 tela = new Form1();
                tela.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Verifique os dados inserdios!",
                    " 70 70 se n der 70 d nvo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                        

            }
        }

    }
}
