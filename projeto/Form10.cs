using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projeto
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String cpf = textBox2.Text;
            String email = textBox1.Text;
            //Criar objeto da classe UsuarioDAO
            UsuarioDAO2 user2 = new UsuarioDAO2();
            //chamar o metodo que verifica o login
            //o usuário e senha existem na tabela
            if (user2.Loginusuario2(cpf, email))
            {
                Form6 tela = new Form6();
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

        private void button5_Click(object sender, EventArgs e)
        {
            Form9 tela1 = new Form9();
            tela1.ShowDialog();
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                // Remove qualquer formatação existente
                string cpfSemFormato = textBox1.Text.Replace(".", "").Replace("-", "");

                // Verifica se o CPF tem 11 dígitos
                if (cpfSemFormato.Length == 11)
                {
                    // Formata o CPF com pontos e traço
                    string cpfFormatado = Convert.ToUInt64(cpfSemFormato).ToString(@"000\.000\.000\-00");

                    // Atualiza o texto do TextBox
                    textBox1.Text = cpfFormatado;

                    // Move o cursor para o final do texto
                    textBox1.SelectionStart = textBox1.Text.Length;
                }
            }
        }
    }
}
