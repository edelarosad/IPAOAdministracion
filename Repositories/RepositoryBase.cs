using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IPAO.Administracion.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = "Server=TM-JAVIERMORALE\\SQLEXPRESS;Database=IPAO_Administracion;User Id=sa;password=prueba123;Trusted_Connection=False;MultipleActiveResultSets=true;";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
