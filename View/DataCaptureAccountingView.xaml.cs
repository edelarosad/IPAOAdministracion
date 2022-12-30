using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using IPAO.Administracion.ViewModel;

namespace IPAO.Administracion.View
{
    /// <summary>
    /// Lógica de interacción para DataCaptureAccountingView.xaml
    /// </summary>
    public partial class DataCaptureAccountingView : UserControl
    {
        private DataCaptureAccountingViewModel dataCaptureAccountingViewModel;
        private RespuestaBDViewModel respuestaBD;

        public DataCaptureAccountingView()
        {
            InitializeComponent();
            dataCaptureAccountingViewModel = new DataCaptureAccountingViewModel();
            respuestaBD = new RespuestaBDViewModel();
            this.cmbNombreCliente.ItemsSource = dataCaptureAccountingViewModel.GetAllClientsCombobox();
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
                    DataCaptureAccountingViewModel capturaDatos = new DataCaptureAccountingViewModel();

                    capturaDatos.ClienteId = int.Parse(lblClienteId.Content.ToString());
                    capturaDatos.NombreCliente = cmbNombreCliente.SelectedItem.ToString();
                    capturaDatos.PasswordCiec = txtPasswordCIEC.Text;
                    capturaDatos.PasswordFirmaElectronica = txtPasswordFE.Text;
                    capturaDatos.FechaVigenciaFirmaElectronica = (DateTime)dtpFechaVigenciaFE.SelectedDate;
                    capturaDatos.PasswordSelloDigital = txtPasswordSD.Text;
                    capturaDatos.FechaVigenciaSelloDigital = (DateTime)dtpFechaVigenciaSD.SelectedDate;
                    capturaDatos.RegistroPatronal = txtRegistroPatronal.Text;
                    capturaDatos.UsuarioIDSE = txtUsuarioIDSE.Text;
                    capturaDatos.PasswordIDSE = txtPasswordIDSE.Text;
                    capturaDatos.UsuarioSIPARE = txtUsuarioSIPARE.Text;
                    capturaDatos.PasswordSIPARE = txtPasswordSIPARE.Text;
                    capturaDatos.EmailISN = txtEmailISN.Text;
                    capturaDatos.UsuarioISN = txtUsuarioISN.Text;
                    capturaDatos.PasswordISN = txtPasswordISN.Text;
                    capturaDatos.EmailINFONAVIT = txtEmailINFONAVIT.Text;
                    capturaDatos.UsuarioINFONAVIT = txtUsuarioINFONAVIT.Text;
                    capturaDatos.PasswordINFONAVIT = txtPasswodINFONAVIT.Text;

                    var respuesta = respuestaBD.AddOrEditDataCaptureAccounting(capturaDatos);

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

        private void cmbNombreCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cliente = dataCaptureAccountingViewModel.GetClientByNameAccounting(cmbNombreCliente.SelectedItem.ToString());

            lblClienteId.Content = cliente.ClienteId;

            txtPasswordCIEC.Text = $"{cliente.PasswordCiec}";
            txtPasswordFE.Text = $"{cliente.PasswordFirmaElectronica}";
            dtpFechaVigenciaFE.SelectedDate = cliente.FechaVigenciaFirmaElectronica;
            txtPasswordSD.Text = $"{cliente.PasswordSelloDigital}";
            dtpFechaVigenciaSD.SelectedDate = cliente.FechaVigenciaSelloDigital;
            txtRegistroPatronal.Text = $"{cliente.RegistroPatronal}";
            txtUsuarioIDSE.Text = $"{cliente.UsuarioIDSE}";
            txtPasswordIDSE.Text = $"{cliente.PasswordIDSE}";
            txtUsuarioSIPARE.Text = $"{cliente.UsuarioSIPARE}";
            txtPasswordSIPARE.Text = $"{cliente.PasswordSIPARE}";
            txtEmailISN.Text = $"{cliente.EmailISN}";
            txtUsuarioISN.Text = $"{cliente.UsuarioISN}";
            txtPasswordISN.Text = $"{cliente.PasswordISN}";
            txtEmailINFONAVIT.Text = $"{cliente.EmailINFONAVIT}";
            txtUsuarioINFONAVIT.Text = $"{cliente.UsuarioINFONAVIT}";
            txtPasswodINFONAVIT.Text = $"{cliente.PasswordINFONAVIT}";
        }
    }
}
