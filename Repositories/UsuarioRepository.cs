using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using IPAO.Administracion.Model;

namespace IPAO.Administracion.Repositories
{
    public class UsuarioRepository : RepositoryBase, IUsuarioRepository
    {
        public void Add(UsuarioModel usuarioModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using(var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from Usuario where NombreUsuario = @username and Password = @password";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Edit(UsuarioModel usuarioModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UsuarioModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UsuarioModel GetByUserName(string username)
        {
            UsuarioModel usuario = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from Usuario where NombreUsuario = @username";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                using(var reader= command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        usuario = new UsuarioModel()
                        {
                            UsuarioId = Int32.Parse(reader[0].ToString()),
                            NombreUsuario = reader[1].ToString(),
                            Password = string.Empty,
                            Nombre = reader[3].ToString(),
                            Apellido = reader[4].ToString(),
                            Email = reader[5].ToString()
                        };
                    }
                }
            }
            return usuario;
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
