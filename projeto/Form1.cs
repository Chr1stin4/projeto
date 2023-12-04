using CefSharp.DevTools.Database;
using CefSharp.DevTools.LayerTree;
using InvestimentosMais;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
        private readonly string DataBase = "M.S";
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

        private void novoForm()
        {
            Application.Run(new FormLogin());
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            String name = textname.Text;
            String senha = txbEnrollment.Text;
            try
            {
                UsuarioDAO user = new UsuarioDAO();

                string hashedSenha = Usuario.CriptografarSenha(senha);
                if (user.Loginusuario(name, hashedSenha))
                {
                    this.Close();
                    abc = new Thread(novoForm);
                    abc.SetApartmentState(ApartmentState.STA);
                    abc.Start();
                }
                else
                {
                    MessageBox.Show("Nome de usuário ou senha incorretos!",
                        "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                        );

                }
            
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
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

        private void button5_Click(object sender, EventArgs e)
        {
            Form0 tela1 = new Form0();
            tela1.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Cria uma instância do SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Define as propriedades do SaveFileDialog
            saveFileDialog.Filter = "Arquivos PDF (*.pdf)|*.pdf|Todos os arquivos (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            // Exibe o diálogo e verifica se o usuário pressionou OK
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                /// Obtém o caminho escolhido pelo usuário
                string filePath = saveFileDialog.FileName;

                // Conexão com o banco de dados SQL Server
                string stringConnection = @"Data Source="
                + Environment.MachineName +
                         @"\SQLEXPRESS;Initial Catalog=" +
                         DataBase + ";Integrated Security=true";
                SqlConnection connection = new SqlConnection(stringConnection);
                connection.Open();

                // Consulta SQL para recuperar as informações
                string query = "SELECT nome, senha FROM Table_1";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                // Cria um novo documento PDF
                Document document = new Document();

                try
                { // Cria um PdfWriter usando o caminho escolhido pelo usuário
                    PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

                    // Abre o documento antes de adicionar elementos
                    document.Open();

                    // Cria uma nova tabela e adiciona as informações recuperadas
                    PdfPTable table = new PdfPTable(2);
                    table.AddCell("nome");
                    table.AddCell("senha");

                    while (reader.Read())
                    {
                        table.AddCell(reader["nome"].ToString());
                        table.AddCell(reader["senha"].ToString());
                    }

                    // Adiciona a tabela ao documento
                    document.Add(table);

                    MessageBox.Show("Relatório gerado com sucesso", "Êxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    // Fecha o documento e a conexão com o banco de dados
                    document.Close();
                    connection.Close();
                }
            }
        }
    }
}           
