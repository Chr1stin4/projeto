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
        public List<Usuario> Usuarios;

        public void InsertUser(Usuario usuario)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO Table_1 VALUES(@name,@senha)";

            sqlCommand.Parameters.AddWithValue("@name", usuario.Nome);
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
    }
}
