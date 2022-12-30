using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using IPAO.Administracion.ViewModel;

namespace IPAO.Administracion.View
{
    /// <summary>
    /// Lógica de interacción para DataCaptureView.xaml
    /// </summary>
    public partial class DataCaptureView : UserControl
    {
        private DataCaptureViewModel dataCaptureViewModel;
        private ClienteViewModel clienteViewModel;
        private RespuestaBDViewModel respuestaBD;
        public DataCaptureView()
        {
            InitializeComponent();
            dataCaptureViewModel = new DataCaptureViewModel();
            clienteViewModel = new ClienteViewModel();
            respuestaBD = new RespuestaBDViewModel();
            this.cmbNombreCliente.ItemsSource = dataCaptureViewModel.GetAllClientsCombobox();
            this.cmbTipoUsuario.ItemsSource = LlenarComboTipoUsuario();
            this.cmbTipoLicencia.ItemsSource = LlenarComboTipoLicencia();
            this.cmbTipoCandado.ItemsSource = LlenarComboTipoCandado();
            this.cmbCapacidad.ItemsSource = LlenarComboCantidad();
        }

        private void txtBancos_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnGrabarDatos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lblClienteId.Content.Equals(""))
                {
                    MessageBox.Show("No se encuentra un cliente seleccionado, favor de elegir uno cliente...");
                }
                else
                {
                    DataCaptureViewModel capturaDatos = new DataCaptureViewModel();
                    //Folios Digtales
                    capturaDatos.ClienteId = int.Parse(lblClienteId.Content.ToString());
                    capturaDatos.NombreCliente = cmbNombreCliente.SelectedItem.ToString();
                    //Contabilidad
                    capturaDatos.UsuarioFolioDigital = txtUsuarioFD.Text;
                    capturaDatos.PasswordFolioDigital = txtPasswordFD.Text;
                    capturaDatos.PasswordCiec = txtPasswordCIEC.Text;
                    capturaDatos.PasswordFirmaElectronica = txtPasswordFE.Text;
                    capturaDatos.FechaVigenciaFirmaElectronica = (DateTime)dtpFechaVigenciaFE.SelectedDate.Value;
                    capturaDatos.PasswordSelloDigital = txtPasswordSD.Text;
                    capturaDatos.FechaVigenciaSelloDigital = (DateTime)dtpFechaVigenciaSD.SelectedDate.Value;
                    //Microsip
                    capturaDatos.TipoUsuario = (cmbTipoUsuario.SelectedItem == null) ? "" : cmbTipoUsuario.SelectedItem.ToString();
                    capturaDatos.TipoLicencia = (cmbTipoLicencia.SelectedItem == null) ? "" : cmbTipoLicencia.SelectedItem.ToString();
                    capturaDatos.Version = txtVersion.Text;
                    capturaDatos.TipoCandado = (cmbTipoCandado.SelectedItem == null) ? "" : cmbTipoCandado.SelectedItem.ToString();
                    capturaDatos.Candado = txtCandado.Text;
                    capturaDatos.CapacidadPaquete = (cmbCapacidad.SelectedItem == null) ? "" : cmbCapacidad.SelectedItem.ToString();
                    capturaDatos.Capacidad = (int)lblCantidad.Content;
                    capturaDatos.bBancos = (chkBancos.IsChecked == true) ? true : false;
                    capturaDatos.BancosLicencias = int.Parse(txtBancos.Text);
                    capturaDatos.bCompras = (chkCompras.IsChecked == true) ? true : false;
                    capturaDatos.ComprasLicencias = int.Parse(txtCompras.Text);
                    capturaDatos.bContabilidad = (chkContabilidad.IsChecked == true) ? true : false;
                    capturaDatos.ContabilidadLicencias = int.Parse(txtContabilidad.Text);
                    capturaDatos.bCuentasCobrar = (chkCuentasCobrar.IsChecked == true) ? true : false;
                    capturaDatos.CuentasCobrarLicencias = int.Parse(txtCuentasCobrar.Text);
                    capturaDatos.bCuentasPagar = (chkCuentasPagar.IsChecked == true) ? true : false;
                    capturaDatos.CuentasPagarLicencias = int.Parse(txtCuentasPagar.Text);
                    capturaDatos.bInventarios = (chkInventarios.IsChecked == true) ? true : false;
                    capturaDatos.InventariosLicencias = int.Parse(txtInventarios.Text);
                    capturaDatos.bNominas = (chkNominas.IsChecked == true) ? true : false;
                    capturaDatos.NominasLicencias = int.Parse(txtNominas.Text);
                    capturaDatos.bPuntoVenta = (chkPuntoVenta.IsChecked == true) ? true : false;
                    capturaDatos.PuntoVentaLicencias = int.Parse(txtPuntoVenta.Text);
                    capturaDatos.bVentas = (chkVentas.IsChecked == true) ? true : false;
                    capturaDatos.VentasLicencias = int.Parse(txtVentas.Text);
                    capturaDatos.bAdministra = (chkAdministra.IsChecked == true) ? true : false;
                    capturaDatos.AdministraLicencias = int.Parse(txtAdministra.Text);
                    capturaDatos.bReplix = (chkReplix.IsChecked == true) ? true : false;
                    capturaDatos.ReplixLicencias = int.Parse(txtReplix.Text);

                    var respuesta = respuestaBD.AddOrEditDataCapture(capturaDatos);

                    if (respuesta.IntError == 0)
                    {
                        MessageBox.Show("Se ha guardado con exito la informacion...");
                    }
                    else
                    {
                        MessageBox.Show(respuesta.StrMsg.ToString());
                    }
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private List<string> LlenarComboTipoLicencia()
        {
            List<string> lstTipoLicencia = new List<string>();
            lstTipoLicencia.Add("Suscripcion");
            lstTipoLicencia.Add("Tradicional");

            return lstTipoLicencia;
        }

        private List<string> LlenarComboTipoUsuario()
        {
            List<string> lstTipoUsuario = new List<string>();
            lstTipoUsuario.Add("Colgado");
            lstTipoUsuario.Add("Propietario");

            return lstTipoUsuario;
        }

        private List<string> LlenarComboTipoCandado()
        {
            List<string> lstTipoCandado = new List<string>();
            lstTipoCandado.Add("Cloud");
            lstTipoCandado.Add("PDA");

            return lstTipoCandado;
        }

        private List<string> LlenarComboCantidad()
        {
            List<string> lstCantidad = new List<string>();
            lstCantidad.Add("Basico");
            lstCantidad.Add("Ligero");
            lstCantidad.Add("Profesional");
            lstCantidad.Add("Premium");
            lstCantidad.Add("Corporativo");
            lstCantidad.Add("Incremento");

            return lstCantidad;
        }

        private void cmbNombreCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cliente = dataCaptureViewModel.GetClientByName(cmbNombreCliente.SelectedItem.ToString());

            lblClienteId.Content = cliente.ClienteId;

            if (!cliente.ServFoliosDigitales && !cliente.ServContabilidad)
            {
                tiFC.Visibility = Visibility.Hidden;
            }
            else
            {
                tiFC.Visibility = Visibility.Visible;
                if (cliente.ServFoliosDigitales && !cliente.ServContabilidad)
                {
                    gbContabilidad.IsEnabled = false;
                    gbFoliosDigitales.IsEnabled = true;
                }
                else if (!cliente.ServFoliosDigitales && cliente.ServContabilidad)
                {
                    gbFoliosDigitales.IsEnabled = false;
                    gbContabilidad.IsEnabled = true;
                }
            }

            if (!cliente.ServMicrosip)
            {
                tiMicrosip.Visibility = Visibility.Hidden;
            }
            else
            {
                tiMicrosip.Visibility = Visibility.Visible;
            }

            //Folios Digitales
            txtUsuarioFD.Text = $"{cliente.UsuarioFolioDigital}";
            txtPasswordFD.Text = $"{cliente.PasswordFolioDigital}";
            //Contabilidad
            txtPasswordCIEC.Text = $"{cliente.PasswordCiec}";
            txtPasswordFE.Text = $"{cliente.PasswordCiec}";
            dtpFechaVigenciaFE.SelectedDate = cliente.FechaVigenciaFirmaElectronica;
            txtPasswordSD.Text = $"{cliente.PasswordSelloDigital}";
            dtpFechaVigenciaSD.SelectedDate = cliente.FechaVigenciaSelloDigital;
            //Microsip
            cmbTipoUsuario.SelectedValue = cliente.TipoUsuario;
            cmbTipoLicencia.SelectedValue = cliente.TipoLicencia;
            txtVersion.Text = $"{cliente.Version}";
            cmbTipoCandado.SelectedValue = cliente.TipoCandado;
            txtCandado.Text = $"{cliente.Candado}";
            cmbCapacidad.SelectedValue = cliente.CapacidadPaquete;
            lblCantidad.Content = cliente.Capacidad;
            chkBancos.IsChecked = cliente.bBancos;
            txtBancos.Text = $"{cliente.BancosLicencias}";
            chkCompras.IsChecked = cliente.bCompras;
            txtCompras.Text = $"{cliente.ComprasLicencias}";
            chkContabilidad.IsChecked = cliente.bContabilidad;
            txtContabilidad.Text = $"{cliente.ContabilidadLicencias}";
            chkCuentasCobrar.IsChecked = cliente.bCuentasCobrar;
            txtCuentasCobrar.Text = $"{cliente.CuentasCobrarLicencias}";
            chkCuentasPagar.IsChecked = cliente.bCuentasPagar;
            txtCuentasPagar.Text = $"{cliente.CuentasPagarLicencias}";
            chkInventarios.IsChecked = cliente.bInventarios;
            txtInventarios.Text = $"{cliente.InventariosLicencias}";
            chkNominas.IsChecked = cliente.bNominas;
            txtNominas.Text = $"{cliente.NominasLicencias}";
            chkPuntoVenta.IsChecked = cliente.bPuntoVenta;
            txtPuntoVenta.Text = $"{cliente.PuntoVentaLicencias}";
            chkVentas.IsChecked = cliente.bVentas;
            txtVentas.Text = $"{cliente.VentasLicencias}";
            chkAdministra.IsChecked = cliente.bAdministra;
            txtAdministra.Text = $"{cliente.AdministraLicencias}";
            chkReplix.IsChecked = cliente.bReplix;
            txtReplix.Text = $"{cliente.ReplixLicencias}";
        }
    }
}
