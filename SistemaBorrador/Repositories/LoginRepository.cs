using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBorrador.Repositories
{
    public class LoginRepository
    {
        public bool UsuarioExist(string usuario, string password)
        {
            bool resultado = false;
            string connectionString = "server=localhost;database=sistema_borrador_db;Integrate Security=true;";
            string query1 = "select conut(*) from usuario where = '";
            string query2 = "' and password = '";
            string query3 = "'";
            string query = query1+usuario+query2+password+query3;
            using SqlConnection sql = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(query, sql);
            sql.Open();
            int queryResult = (int)cmd.ExecuteScalar();
            if (queryResult > 0)
            {
                resultado = true;
            }

            return resultado;
        }
    }
}
