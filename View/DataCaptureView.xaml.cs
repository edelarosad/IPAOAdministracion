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
        public DataCaptureView()
        {
            InitializeComponent();
            dataCaptureViewModel = new DataCaptureViewModel();
            clienteViewModel = new ClienteViewModel();
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
            var cliente = clienteViewModel.GetClientByName(cmbNombreCliente.SelectedItem.ToString());

            lblClienteId.Content = cliente.ClienteId;
        }
    }
}
