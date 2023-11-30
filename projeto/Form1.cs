using CefSharp.DevTools.LayerTree;
using InvestimentosMais;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projeto
{
    public partial class Form1 : Form
    {
        private int id; 
        Thread abc;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = txbName.Text;
            String enrollment = txbEnrollment.Text;
            MessageBox.Show(
                "quem leu ta me devendo 10 de nota de PR2",
                "sifudeu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
                               
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void UpdateListView()
        {
            listView2.Items.Clear();
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            List<Usuario> usuarios = usuarioDAO.SelectUsuario();
            try
            {
                foreach (Usuario usuario in usuarios)
                {
                    ListViewItem lv = new ListViewItem(usuario.Id.ToString());
                    lv.SubItems.Add(usuario.Nome);
                    lv.SubItems.Add(usuario.Senha);
                    listView2.Items.Add(lv);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void novoForm()
        {
            Application.Run(new Form2());
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            String name = textname.Text;
            String senha = txbEnrollment.Text;
            if (name == "" && senha == "")
            {
                this.Close();
                abc = new Thread(novoForm);
                abc.SetApartmentState(ApartmentState.STA);
                abc.Start();
            }
            else
            {

                String message = "Nome: " + name +
                                "\nSenha: " + senha;
                MessageBox.Show(message, "",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                    );

            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txbEnrollment_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Criar objeto da Classe Usuario
                Usuario usuario = new Usuario(
                    textname.Text,
                    txbEnrollment.Text);
                //chamado o metodo da exclusão
                UsuarioDAO nomeDoObj = new UsuarioDAO();
                nomeDoObj.InsertUsuario(usuario);
                MessageBox.Show("Cadastro com sucesso",
                "AVISO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                textname.Clear();
                txbEnrollment.Clear();
                UpdateListView();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
         UpdateListView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string USER_LR = textname.Text, SENHA = txbEnrollment.Text;

            try
            {
                Usuario usuario = new Usuario(
                    id,
                    textname.Text,
                    txbEnrollment.Text);
                //chamando o metodo de exclusão
                UsuarioDAO nomeDoObj = new UsuarioDAO();
                nomeDoObj.UpdateUsuario(usuario);
                MessageBox.Show(
                 "Login alterado com sucesso !",
                 "AVISO",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
                 );
                textname.Clear();
                txbEnrollment.Clear();
                UpdateListView();
            }
            catch(Exception error) 
            { 
                MessageBox.Show(error.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            //Código para excluir
            try
            {
                Usuario usuario = new Usuario(
                        textname.Text,
                        txbEnrollment.Text);
                //chamando o metodo de exclusão
                UsuarioDAO nomeDoObj = new UsuarioDAO();
                nomeDoObj.DeleteUsuario(id);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }    
            textname.Clear();
            txbEnrollment.Clear();

            UpdateListView();
        }
        private void lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index;
            index = listView2.FocusedItem.Index;
            id = int.Parse(listView2.Items[index].SubItems[0].Text);
            textname.Text = listView2.Items[index].SubItems[1].Text;
            txbEnrollment.Text = listView2.Items[index].SubItems[2].Text;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}           
