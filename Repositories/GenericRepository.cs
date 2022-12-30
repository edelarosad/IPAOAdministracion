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

        public DataCaptureViewModel GetClientByName(string name)
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
                    DataCaptureViewModel cliente = new DataCaptureViewModel();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cliente.ClienteId = int.Parse(dt.Rows[0]["ClienteId"].ToString());
                        cliente.NombreCliente = dt.Rows[0]["NombreCliente"].ToString();
                        cliente.ServFoliosDigitales = bool.Parse(dt.Rows[0]["ServFoliosDigitales"].ToString());
                        cliente.ServContabilidad = bool.Parse(dt.Rows[0]["ServContabilidad"].ToString());
                        cliente.ServMicrosip = bool.Parse(dt.Rows[0]["ServMicrosip"].ToString());
                        cliente.UsuarioFolioDigital = dt.Rows[0]["UsuarioFolioDigital"].ToString();
                        cliente.PasswordFolioDigital = dt.Rows[0]["PasswordFolioDigital"].ToString();
                        cliente.PasswordCiec = dt.Rows[0]["PasswordCiec"].ToString();
                        cliente.PasswordFirmaElectronica = dt.Rows[0]["PasswordFirmaElectronica"].ToString();
                        cliente.FechaVigenciaFirmaElectronica = Convert.ToDateTime(dt.Rows[0]["FechaVigenciaFirmaElectronica"].ToString());
                        cliente.PasswordSelloDigital = dt.Rows[0]["PasswordSelloDigital"].ToString();
                        cliente.FechaVigenciaSelloDigital = Convert.ToDateTime(dt.Rows[0]["FechaVigenciaSelloDigital"].ToString());
                        cliente.TipoUsuario = dt.Rows[0]["TipoUsuario"].ToString();
                        cliente.TipoLicencia = dt.Rows[0]["TipoLicencia"].ToString();
                        cliente.Version = dt.Rows[0]["Version"].ToString();
                        cliente.TipoCandado = dt.Rows[0]["TipoCandado"].ToString();
                        cliente.Candado = dt.Rows[0]["Candado"].ToString();
                        cliente.CapacidadPaquete = dt.Rows[0]["CapacidadPaquete"].ToString();
                        cliente.Capacidad = int.Parse(dt.Rows[0]["Capacidad"].ToString());
                        cliente.bBancos = bool.Parse(dt.Rows[0]["bBancos"].ToString());
                        cliente.BancosLicencias = int.Parse(dt.Rows[0]["BancosLicencias"].ToString());
                        cliente.bCompras = bool.Parse(dt.Rows[0]["bCompras"].ToString());
                        cliente.ComprasLicencias = int.Parse(dt.Rows[0]["ComprasLicencias"].ToString());
                        cliente.bContabilidad = bool.Parse(dt.Rows[0]["bContabilidad"].ToString());
                        cliente.ContabilidadLicencias = int.Parse(dt.Rows[0]["ContabilidadLicencias"].ToString());
                        cliente.bCuentasCobrar = bool.Parse(dt.Rows[0]["bCuentasCobrar"].ToString());
                        cliente.CuentasCobrarLicencias = int.Parse(dt.Rows[0]["CuentasCobrarLicencias"].ToString());
                        cliente.bCuentasPagar = bool.Parse(dt.Rows[0]["bCuentasPagar"].ToString());
                        cliente.CuentasPagarLicencias = int.Parse(dt.Rows[0]["CuentasPagarLicencia"].ToString());
                        cliente.bInventarios = bool.Parse(dt.Rows[0]["bInventarios"].ToString());
                        cliente.InventariosLicencias = int.Parse(dt.Rows[0]["InventariosLicencias"].ToString());
                        cliente.bNominas = bool.Parse(dt.Rows[0]["bNominas"].ToString());
                        cliente.NominasLicencias = int.Parse(dt.Rows[0]["NominasLicencias"].ToString());
                        cliente.bPuntoVenta = bool.Parse(dt.Rows[0]["bPuntoVenta"].ToString());
                        cliente.PuntoVentaLicencias = int.Parse(dt.Rows[0]["PuntoVentaLicencias"].ToString());
                        cliente.bVentas = bool.Parse(dt.Rows[0]["bVentas"].ToString());
                        cliente.VentasLicencias = int.Parse(dt.Rows[0]["VentasLicencias"].ToString());
                        cliente.bAdministra = bool.Parse(dt.Rows[0]["bAdministra"].ToString());
                        cliente.AdministraLicencias = int.Parse(dt.Rows[0]["AdministraLicencias"].ToString());
                        cliente.bReplix = bool.Parse(dt.Rows[0]["bReplix"].ToString());
                        cliente.ReplixLicencias = int.Parse(dt.Rows[0]["ReplixLicencias"].ToString());
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

        public DataCaptureAccountingViewModel GetClientByNameAccounting(string name)
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand("sp_GetClientByNameAccounting", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_NombreCliente", name);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    da.Dispose();
                    DataCaptureAccountingViewModel cliente = new DataCaptureAccountingViewModel();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        cliente.ClienteId = int.Parse(dt.Rows[0]["ClienteId"].ToString());
                        cliente.NombreCliente = dt.Rows[0]["NombreCliente"].ToString();;
                        cliente.PasswordCiec = dt.Rows[0]["PasswordCiec"].ToString();
                        cliente.PasswordFirmaElectronica = dt.Rows[0]["PasswordFirmaElectronica"].ToString();
                        cliente.FechaVigenciaFirmaElectronica = Convert.ToDateTime(dt.Rows[0]["FechaVigenciaFirmaElectronica"].ToString());
                        cliente.PasswordSelloDigital = dt.Rows[0]["PasswordSelloDigital"].ToString();
                        cliente.FechaVigenciaSelloDigital = Convert.ToDateTime(dt.Rows[0]["FechaVigenciaSelloDigital"].ToString());
                        cliente.RegistroPatronal = dt.Rows[0]["RegistroPatronal"].ToString();
                        cliente.UsuarioIDSE = dt.Rows[0]["UsuarioIdse"].ToString();
                        cliente.PasswordIDSE = dt.Rows[0]["PasswordIdse"].ToString();
                        cliente.UsuarioSIPARE = dt.Rows[0]["UsuarioSipare"].ToString();
                        cliente.PasswordSIPARE = dt.Rows[0]["PasswordSipare"].ToString();
                        cliente.EmailISN = dt.Rows[0]["EmailIsn"].ToString();
                        cliente.UsuarioISN = dt.Rows[0]["UsuarioIsn"].ToString();
                        cliente.PasswordISN = dt.Rows[0]["PasswordIsn"].ToString();
                        cliente.EmailINFONAVIT = dt.Rows[0]["EmailInfonavit"].ToString();
                        cliente.UsuarioINFONAVIT = dt.Rows[0]["UsuarioInfonavit"].ToString();
                        cliente.PasswordINFONAVIT = dt.Rows[0]["PasswordInfonavit"].ToString();
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

        public RespuestaBDViewModel AddOrEditDataCapture(DataCaptureViewModel dataCapture)
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand("sp_AddOrEditDataCapture", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_ClienteId", dataCapture.ClienteId);
                    command.Parameters.AddWithValue("@p_NombreCliente", dataCapture.NombreCliente);
                    command.Parameters.AddWithValue("@p_UsuarioFolioDigital", dataCapture.UsuarioFolioDigital);
                    command.Parameters.AddWithValue("@p_PasswordFolioDigital", dataCapture.PasswordFolioDigital);
                    command.Parameters.AddWithValue("@p_PasswordCiec", dataCapture.PasswordCiec);
                    command.Parameters.AddWithValue("@p_PasswordFirmaElectronica", dataCapture.PasswordFirmaElectronica);
                    command.Parameters.AddWithValue("@p_FechaVigenciaFirmaElectronica", dataCapture.FechaVigenciaFirmaElectronica);
                    command.Parameters.AddWithValue("@p_PasswordSelloDigital", dataCapture.PasswordSelloDigital);
                    command.Parameters.AddWithValue("@p_FechaVigenciaSelloDigital", dataCapture.FechaVigenciaSelloDigital);
                    command.Parameters.AddWithValue("@p_TipoUsuario", dataCapture.TipoUsuario);
                    command.Parameters.AddWithValue("@p_TipoLicencia", dataCapture.TipoLicencia);
                    command.Parameters.AddWithValue("@p_Version", dataCapture.Version);
                    command.Parameters.AddWithValue("@p_TipoCandado", dataCapture.TipoCandado);
                    command.Parameters.AddWithValue("@p_Candado", dataCapture.Candado);
                    command.Parameters.AddWithValue("@p_CapacidadPaquete", dataCapture.CapacidadPaquete);
                    command.Parameters.AddWithValue("@p_Capacidad", dataCapture.Capacidad);
                    command.Parameters.AddWithValue("@p_bBancos", dataCapture.bBancos);
                    command.Parameters.AddWithValue("@p_BancosLicencias", dataCapture.BancosLicencias);
                    command.Parameters.AddWithValue("@p_bCompras", dataCapture.bCompras);
                    command.Parameters.AddWithValue("@p_ComprasLicencias", dataCapture.ComprasLicencias);
                    command.Parameters.AddWithValue("@p_bContabilidad", dataCapture.bContabilidad);
                    command.Parameters.AddWithValue("@p_ContabilidadLicencias", dataCapture.ContabilidadLicencias);
                    command.Parameters.AddWithValue("@p_bCuentasCobrar", dataCapture.bCuentasCobrar);
                    command.Parameters.AddWithValue("@p_CuentasCobrarLicencias", dataCapture.CuentasCobrarLicencias);
                    command.Parameters.AddWithValue("@p_bCuentasPagar", dataCapture.bCuentasPagar);
                    command.Parameters.AddWithValue("@p_CuentasPagarLicencias", dataCapture.CuentasPagarLicencias);
                    command.Parameters.AddWithValue("@p_bInventarios", dataCapture.bInventarios);
                    command.Parameters.AddWithValue("@p_InvetariosLicencias", dataCapture.InventariosLicencias);
                    command.Parameters.AddWithValue("@p_bNominas", dataCapture.bNominas);
                    command.Parameters.AddWithValue("@p_NominasLicencias", dataCapture.NominasLicencias);
                    command.Parameters.AddWithValue("@p_bPuntoVenta", dataCapture.bPuntoVenta);
                    command.Parameters.AddWithValue("@p_PuntoVentaLicencias", dataCapture.PuntoVentaLicencias);
                    command.Parameters.AddWithValue("@p_bVentas", dataCapture.bVentas);
                    command.Parameters.AddWithValue("@p_VentasLicencias", dataCapture.VentasLicencias);
                    command.Parameters.AddWithValue("@p_bAdministra", dataCapture.bAdministra);
                    command.Parameters.AddWithValue("@p_AdministraLicencias", dataCapture.AdministraLicencias);
                    command.Parameters.AddWithValue("@p_bReplix", dataCapture.bReplix);
                    command.Parameters.AddWithValue("@p_ReplixLicencias", dataCapture.ReplixLicencias);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    da.Dispose();
                    RespuestaBDViewModel rdb = new RespuestaBDViewModel();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        rdb.IntError = int.Parse(dt.Rows[i]["IntError"].ToString());
                        rdb.StrMsg = dt.Rows[i]["StrMsg"].ToString();
                    }
                    connection.Close();

                    return rdb;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RespuestaBDViewModel AddOrEditDataCaptureAccounting(DataCaptureAccountingViewModel dataCapture)
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand("sp_AddOrEditDataCaptureAccounting", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_ClienteId", dataCapture.ClienteId);
                    command.Parameters.AddWithValue("@p_NombreCliente", dataCapture.NombreCliente);
                    command.Parameters.AddWithValue("@p_PasswordCiec", dataCapture.PasswordCiec);
                    command.Parameters.AddWithValue("@p_PasswordFirmaElectronica", dataCapture.PasswordCiec);
                    command.Parameters.AddWithValue("@p_FechaVigenciaFirmaElectronica", dataCapture.FechaVigenciaFirmaElectronica);
                    command.Parameters.AddWithValue("@p_PasswordSelloDigital", dataCapture.PasswordSelloDigital);
                    command.Parameters.AddWithValue("@p_FechaVigenciaSelloDigital", dataCapture.FechaVigenciaSelloDigital);
                    command.Parameters.AddWithValue("@p_RegistroPatronal", dataCapture.RegistroPatronal);
                    command.Parameters.AddWithValue("@p_UsuarioIdse", dataCapture.UsuarioIDSE);
                    command.Parameters.AddWithValue("@p_PasswordIdse", dataCapture.PasswordIDSE);
                    command.Parameters.AddWithValue("@p_UsuarioSipare", dataCapture.UsuarioSIPARE);
                    command.Parameters.AddWithValue("@p_PasswordSipare", dataCapture.PasswordSIPARE);
                    command.Parameters.AddWithValue("@p_EmailIsn", dataCapture.EmailISN);
                    command.Parameters.AddWithValue("@p_UsuarioIsn", dataCapture.UsuarioISN);
                    command.Parameters.AddWithValue("@p_PasswordIsn", dataCapture.PasswordISN);
                    command.Parameters.AddWithValue("@p_EmailInfonavit", dataCapture.EmailINFONAVIT);
                    command.Parameters.AddWithValue("@p_UsuarioInfonavit", dataCapture.UsuarioINFONAVIT);
                    command.Parameters.AddWithValue("@p_PasswordInfonavit", dataCapture.PasswordINFONAVIT);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    da.Dispose();
                    RespuestaBDViewModel rdb = new RespuestaBDViewModel();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        rdb.IntError = int.Parse(dt.Rows[i]["IntError"].ToString());
                        rdb.StrMsg = dt.Rows[i]["StrMsg"].ToString();
                    }
                    connection.Close();

                    return rdb;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
