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

            Connection conn = new Connection();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM Table_1";

            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (dr.Read())
                {
                    int id = (int)dr["id"];
                    string name = (string)dr["Nome"];
                    string Senha = (string)dr["Senha"];

                    ListViewItem lv = new ListViewItem(id.ToString());
                    lv.SubItems.Add(name);
                    lv.SubItems.Add(Senha);
                    listView2.Items.Add(lv);
                }
                dr.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                conn.CloseConnection();
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
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO Table_1 VALUES(@name,@senha)";

            sqlCommand.Parameters.AddWithValue("@name", textname.Text);
            sqlCommand.Parameters.AddWithValue("@senha", txbEnrollment.Text);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Cadastro com sucesso",
                "AVISO",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            textname.Clear();
            txbEnrollment.Clear();
            UpdateListView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         UpdateListView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string USER_LR = textname.Text, SENHA = txbEnrollment.Text;


            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE table_1 SET
            nome = @nome,
            senha = @senha
            WHERE id = @id";

            sqlCommand.Parameters.AddWithValue("@nome", textname.Text);
            sqlCommand.Parameters.AddWithValue("@senha", txbEnrollment.Text);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.ExecuteNonQuery();

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

        private void delete_Click(object sender, EventArgs e)
        {
            //Código para excluir
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"DELETE FROM Table_1 WHERE id = @id";
            sqlCommand.Parameters.AddWithValue("@id", id);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao excluir usuário no banco.\n" + err.Message);
            }
            finally
            {
                connection.CloseConnection();
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
    }
}           
