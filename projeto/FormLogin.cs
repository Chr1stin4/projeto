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
            String usuario = textBox2.Text;
            String senha = textBox1.Text;
            //Criar objeto da classe UsuarioDAO
            UsuarioDAO user = new UsuarioDAO(); 
            //chamar o metodo que verifica o login
            //o usuário e senha existem na tabela
            if (user.Loginusuario(usuario,senha)) {
                Form1 tela = new Form1();
                tela.ShowDialog();
                this.Close();
            }
            else 
            {
                MessageBox.Show("Verifique os dados inseridos!",
                    " 70 70 se n der 70 d nvo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                        

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
