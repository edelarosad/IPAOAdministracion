using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPAO.Administracion.Model;
using IPAO.Administracion.ViewModel;
using System.Data;
using System.Data.SqlClient;

namespace IPAO.Administracion.Repositories
{
    public class GenericRepository : RepositoryBase, IGenericRepository
    {
        public bool AddClient(ClienteModel usuarioModel)
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand("sp_InsertClient", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_NombreCliente", usuarioModel.NombreCliente);
                    command.Parameters.AddWithValue("@p_Calle", usuarioModel.Calle);
                    command.Parameters.AddWithValue("@p_Colonia", usuarioModel.Colonia);
                    command.Parameters.AddWithValue("@p_CodigoPostal", usuarioModel.CodigoPostal);
                    command.Parameters.AddWithValue("@p_Municipio", usuarioModel.Municipio);
                    command.Parameters.AddWithValue("@p_Estado", usuarioModel.Estado);
                    command.Parameters.AddWithValue("@p_Pais", usuarioModel.Pais);
                    command.Parameters.AddWithValue("@p_Telefono", usuarioModel.Telefono);
                    command.Parameters.AddWithValue("@p_Email", usuarioModel.Email);
                    command.Parameters.AddWithValue("@p_Rfc", usuarioModel.Rfc);
                    command.Parameters.AddWithValue("@p_TipoPersona", usuarioModel.TipoPersona);
                    command.Parameters.AddWithValue("@p_RegimenFiscal", usuarioModel.RegimenFiscal);
                    command.Parameters.AddWithValue("@p_ServFoliosDigitales", usuarioModel.ServFoliosDigitales);
                    command.Parameters.AddWithValue("@p_ServContabilidad", usuarioModel.ServContabilidad);
                    command.Parameters.AddWithValue("@p_ServMicrosip", usuarioModel.ServMicrosip);
                    command.Parameters.AddWithValue("@p_NombreContacto", usuarioModel.NombreContacto);
                    command.Parameters.AddWithValue("@p_EmailContacto", usuarioModel.EmailContacto);
                    command.Parameters.AddWithValue("@p_TelefonoContacto", usuarioModel.TelefonoContacto);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public bool EditClient(ClienteModel usuarioModel)
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand("sp_EditClient", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_ClienteId", usuarioModel.ClienteId);
                    command.Parameters.AddWithValue("@p_NombreCliente", usuarioModel.NombreCliente);
                    command.Parameters.AddWithValue("@p_Calle", usuarioModel.Calle);
                    command.Parameters.AddWithValue("@p_Colonia", usuarioModel.Colonia);
                    command.Parameters.AddWithValue("@p_CodigoPostal", usuarioModel.CodigoPostal);
                    command.Parameters.AddWithValue("@p_Municipio", usuarioModel.Municipio);
                    command.Parameters.AddWithValue("@p_Estado", usuarioModel.Estado);
                    command.Parameters.AddWithValue("@p_Pais", usuarioModel.Pais);
                    command.Parameters.AddWithValue("@p_Telefono", usuarioModel.Telefono);
                    command.Parameters.AddWithValue("@p_Email", usuarioModel.Email);
                    command.Parameters.AddWithValue("@p_Rfc", usuarioModel.Rfc);
                    command.Parameters.AddWithValue("@p_TipoPersona", usuarioModel.TipoPersona);
                    command.Parameters.AddWithValue("@p_RegimenFiscal", usuarioModel.RegimenFiscal);
                    command.Parameters.AddWithValue("@p_ServFoliosDigitales", usuarioModel.ServFoliosDigitales);
                    command.Parameters.AddWithValue("@p_ServContabilidad", usuarioModel.ServContabilidad);
                    command.Parameters.AddWithValue("@p_ServMicrosip", usuarioModel.ServMicrosip);
                    command.Parameters.AddWithValue("@p_NombreContacto", usuarioModel.NombreContacto);
                    command.Parameters.AddWithValue("@p_EmailContacto", usuarioModel.EmailContacto);
                    command.Parameters.AddWithValue("@p_TelefonoContacto", usuarioModel.TelefonoContacto);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClienteViewModel> GetAllClients()
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand("sp_GetAllClients", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    da.Dispose();
                    List<ClienteViewModel> clientes = new List<ClienteViewModel>();
                    for(int i = 0; i < dt.Rows.Count; i++)
                    {
                        clientes.Add(new ClienteViewModel()
                        {
                            ClienteId = int.Parse(dt.Rows[i]["ClienteId"].ToString()),
                            Nombrecliente = dt.Rows[i]["NombreCliente"].ToString(),
                            Direccion = dt.Rows[i]["Direccion"].ToString(),
                            Telefono = dt.Rows[i]["Telefono"].ToString(),
                            Email = dt.Rows[i]["Email"].ToString(),
                            Rfc = dt.Rows[i]["Rfc"].ToString(),
                            Tipopersona = dt.Rows[i]["TipoPersona"].ToString(),
                            Regimenfiscal = dt.Rows[i]["RegimenFiscal"].ToString(),
                            Foliosdigitales = dt.Rows[i]["FoliosDigitales"].ToString(),
                            Contabilidad = dt.Rows[i]["Contabilidad"].ToString(),
                            Microsip = dt.Rows[i]["Microsip"].ToString(),
                            Informacioncontacto = dt.Rows[i]["InformacionContacto"].ToString()
                        });
                    }
                    connection.Close();

                    return clientes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetAllRegimenFiscal()
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand("sp_GetAllRegimenFiscal", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    da.Dispose();
                    List<string> lsRegimenFiscal = new List<string>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lsRegimenFiscal.Add(dt.Rows[i]["Descripcion"].ToString());
                    }
                    connection.Close();

                    return lsRegimenFiscal;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetAllTipoPersona()
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand("sp_GetAllTipoPersona", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    da.Dispose();
                    List<string> tipoPersonas = new List<string>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        tipoPersonas.Add(dt.Rows[i]["Descripcion"].ToString());
                    }
                    connection.Close();

                    return tipoPersonas;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetAllClientsCombobox()
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand("sp_GetAllClients", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    da.Dispose();
                    List<string> clientes = new List<string>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        clientes.Add(dt.Rows[i]["NombreCliente"].ToString());
                    }
                    connection.Close();

                    return clientes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteModel GetByClientId(int id)
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand("sp_GetClientById", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_ClienteId", id);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    da.Dispose();
                    ClienteModel cliente = new ClienteModel();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cliente.ClienteId = int.Parse(dt.Rows[0]["ClienteId"].ToString());
                        cliente.NombreCliente = dt.Rows[0]["NombreCliente"].ToString();
                        cliente.Calle = dt.Rows[0]["Calle"].ToString();
                        cliente.Colonia = dt.Rows[0]["Colonia"].ToString();
                        cliente.CodigoPostal = dt.Rows[0]["CodigoPostal"].ToString();
                        cliente.Municipio = dt.Rows[0]["Municipio"].ToString();
                        cliente.Estado = dt.Rows[0]["Estado"].ToString();
                        cliente.Pais = dt.Rows[0]["Pais"].ToString();
                        cliente.Telefono = dt.Rows[0]["Telefono"].ToString();
                        cliente.Email = dt.Rows[0]["Email"].ToString();
                        cliente.Rfc = dt.Rows[0]["Rfc"].ToString();
                        cliente.TipoPersona = dt.Rows[0]["TipoPersona"].ToString();
                        cliente.RegimenFiscal = dt.Rows[0]["RegimenFiscal"].ToString();
                        cliente.ServFoliosDigitales = bool.Parse(dt.Rows[0]["ServFoliosDigitales"].ToString());
                        cliente.ServContabilidad =bool.Parse(dt.Rows[0]["ServContabilidad"].ToString());
                        cliente.ServMicrosip = bool.Parse(dt.Rows[0]["ServMicrosip"].ToString());
                        cliente.NombreContacto = dt.Rows[0]["NombreContacto"].ToString();
                        cliente.EmailContacto = dt.Rows[0]["EmailContacto"].ToString();
                        cliente.TelefonoContacto = dt.Rows[0]["TelefonoContacto"].ToString();
                    }
                    connection.Close();

                    return cliente;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveClient(int Id)
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand("sp_DeleteClient", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_ClienteId", Id);
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteModel GetClientByName(string name)
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand("sp_GetClientByName", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_NombreCliente", name);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    da.Dispose();
                    ClienteModel cliente = new ClienteModel();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cliente.ClienteId = int.Parse(dt.Rows[0]["ClienteId"].ToString());
                        cliente.NombreCliente = dt.Rows[0]["NombreCliente"].ToString();
                        cliente.Calle = dt.Rows[0]["Calle"].ToString();
                        cliente.Colonia = dt.Rows[0]["Colonia"].ToString();
                        cliente.CodigoPostal = dt.Rows[0]["CodigoPostal"].ToString();
                        cliente.Municipio = dt.Rows[0]["Municipio"].ToString();
                        cliente.Estado = dt.Rows[0]["Estado"].ToString();
                        cliente.Pais = dt.Rows[0]["Pais"].ToString();
                        cliente.Telefono = dt.Rows[0]["Telefono"].ToString();
                        cliente.Email = dt.Rows[0]["Email"].ToString();
                        cliente.Rfc = dt.Rows[0]["Rfc"].ToString();
                        cliente.TipoPersona = dt.Rows[0]["TipoPersona"].ToString();
                        cliente.RegimenFiscal = dt.Rows[0]["RegimenFiscal"].ToString();
                        cliente.ServFoliosDigitales = bool.Parse(dt.Rows[0]["ServFoliosDigitales"].ToString());
                        cliente.ServContabilidad = bool.Parse(dt.Rows[0]["ServContabilidad"].ToString());
                        cliente.ServMicrosip = bool.Parse(dt.Rows[0]["ServMicrosip"].ToString());
                        cliente.NombreContacto = dt.Rows[0]["NombreContacto"].ToString();
                        cliente.EmailContacto = dt.Rows[0]["EmailContacto"].ToString();
                        cliente.TelefonoContacto = dt.Rows[0]["TelefonoContacto"].ToString();
                    }
                    connection.Close();

                    return cliente;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
