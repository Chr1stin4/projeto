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
    public partial class Form8 : Form
    {
        private int id;
        public Form8()
        {
            InitializeComponent();
            UpdateListView();
            textBox2.TextChanged += textBox2_TextChanged;
        }
        private void UpdateListView()
        {
            listView2.Items.Clear();
            UsuarioDAO2 usuarioDAO2 = new UsuarioDAO2();
            List<Usuario2> usuarios2 = usuarioDAO2.SelectUsuario2();
            try
            {
                foreach (Usuario2 usuario2 in usuarios2)
                {

                    //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                    ListViewItem lv = new ListViewItem(usuario2.Id.ToString());
                    lv.SubItems.Add(usuario2.Email);
                    lv.SubItems.Add(usuario2.Cpf);
                    listView2.Items.Add(lv);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                // Remove qualquer formatação existente
                string cpfSemFormato = textBox2.Text.Replace(".", "").Replace("-", "");

                // Verifica se o CPF tem 11 dígitos
                if (cpfSemFormato.Length == 11)
                {
                    // Formata o CPF com pontos e traço
                    string cpfFormatado = Convert.ToUInt64(cpfSemFormato).ToString(@"000\.000\.000\-00");

                    // Atualiza o texto do TextBox
                    textBox2.Text = cpfFormatado;

                    // Move o cursor para o final do texto
                    textBox2.SelectionStart = textBox2.Text.Length;
                }
            }
        }
        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string USER_LR = textBox1.Text, SOBRENOME = textBox2.Text;
            try
            {
                Usuario2 usuario2 = new Usuario2(
                        textBox1.Text,
                        textBox2.Text);
                //chamando o metodo de exclusão
                UsuarioDAO2 nomeDoObj = new UsuarioDAO2();
                nomeDoObj.DeleteUsuario2(id);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            textBox1.Clear();
            textBox2.Clear();

            UpdateListView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Criar objeto da Classe Usuario
                Usuario2 usuario2 = new Usuario2(
                    textBox1.Text,
                    textBox2.Text
                    );
                //chamando o metodo de exclusão
                UsuarioDAO2 nomeDoObj = new UsuarioDAO2();
                nomeDoObj.InsertUsuario2(usuario2);

                MessageBox.Show("Cadastro com sucesso",
                "AVISO",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

                textBox1.Clear();
                textBox2.Clear();
                UpdateListView();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string USER_LR = textBox1.Text, SOBRENOME = textBox2.Text;

            try
            {
                Usuario2 usuario2 = new Usuario2(
                        id,
                        textBox1.Text,
                        textBox2.Text);
                //chamando o metodo de exclusão
                UsuarioDAO2 nomeDoObj = new UsuarioDAO2();
                nomeDoObj.UpdateUsuario2(usuario2);
                MessageBox.Show(
                 "Login alterado com sucesso !",
                 "AVISO",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                 );
                textBox1.Clear();
                textBox2.Clear();
                UpdateListView();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }



        private void button4_Click(object sender, EventArgs e)
        {
            String cpf = textBox1.Text;
            String email = textBox2.Text;
            //Criar objeto da classe UsuarioDAO
            UsuarioDAO2 user2 = new UsuarioDAO2();
            //chamar o metodo que verifica o login
            //o usuário e senha existem na tabela
            if (user2.Loginusuario2(cpf, email))
            {
                Form9 tela = new Form9();
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

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index;
            index = listView2.FocusedItem.Index;
            id = int.Parse(listView2.Items[index].SubItems[0].Text);
            textBox2.Text = listView2.Items[index].SubItems[1].Text;
            textBox1.Text = listView2.Items[index].SubItems[2].Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form9 tela1 = new Form9();
            tela1.ShowDialog();
            this.Close();
        }
    }
}
