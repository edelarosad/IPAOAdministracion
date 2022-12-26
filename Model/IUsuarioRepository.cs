using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IPAO.Administracion.Model
{
    public interface IUsuarioRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(UsuarioModel usuarioModel);
        void Edit(UsuarioModel usuarioModel);
        void Remove(int Id);
        UsuarioModel GetById(int id);
        UsuarioModel GetByUserName(string username);
        IEnumerable<UsuarioModel> GetAll();

    }
}
