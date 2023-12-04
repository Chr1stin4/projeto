using InvestimentosMais;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto
{
     internal class UsuarioDAO
    {
        public bool Loginusuario(String usuario,string senha) 
        {
            Connection conn = new Connection();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM Table_1 WHERE" +
                " Nome = @Nome AND Senha = @Senha";
            sqlCom.Parameters.AddWithValue("@Nome",usuario);
            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    return true;
                }

                dr.Close();
                return false;
            }
            catch (Exception err)
            {
                throw new Exception("Erro:Problemas ao excluir o usuário no banco.\n" + err.Message);
            }
             finally
            {
                conn.CloseConnection();
            }
        }
        public List<Usuario> SelectUsuario()
        {
            Connection conn = new Connection();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM Table_1";

            List<Usuario> users = new List<Usuario>();
            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (dr.Read())
                {
                    Usuario objeto = new Usuario(
                    (int)dr["id"],
                    (string)dr["Nome"],
                    (string)dr["Senha"]
                    );

                    users.Add(objeto);
                }
                dr.Close();
                return users;//retornar a lista
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return null;
        }
     public void InsertUsuario(Usuario usuario)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO Table_1 VALUES(@nome,@senha)";

            sqlCommand.Parameters.AddWithValue("@nome", usuario.Nome);
            sqlCommand.Parameters.AddWithValue("@senha", usuario.Senha);
            sqlCommand.ExecuteNonQuery();
        }
        public void DeleteUsuario(int id)
        {
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
        }
        public void UpdateUsuario(Usuario usuario)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE table_1 SET
            Nome = @nome,
            Senha = @senha
            WHERE id = @id";

            sqlCommand.Parameters.AddWithValue("@nome", usuario.Nome);
            sqlCommand.Parameters.AddWithValue("@senha", usuario.Senha);
            sqlCommand.Parameters.AddWithValue("@id", usuario.Id);
            sqlCommand.ExecuteNonQuery();

        }
    }
}
