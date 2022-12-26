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
using System.Windows.Shapes;
using IPAO.Administracion.Model;
using IPAO.Administracion.ViewModel;

namespace IPAO.Administracion.View
{
    /// <summary>
    /// Lógica de interacción para EditClientModal.xaml
    /// </summary>
    /// 
    public partial class EditClientModal : Window
    {

        private int ClienteId { get; set; }

        public EditClientModal()
        {
            InitializeComponent();
        }


        public void ShowClient(int id)
        {
            ClienteId = id;
            
            if(id > 0)
            {
                EditClientViewModel editClient = new EditClientViewModel();
                var cliente = editClient.GetClientById(id);
                txtName.Text = $"{cliente.NombreCliente}";
                txtCalle.Text = $"{cliente.Calle}";
                txtColonia.Text = $"{cliente.Colonia}";
                txtCP.Text = $"{cliente.CodigoPostal}";
                txtMunicipio.Text = $"{cliente.Municipio}";
                txtEstado.Text = $"{cliente.Estado}";
                txtPais.Text = $"{cliente.Pais}";
                txtTelefono.Text = $"{cliente.Telefono}";
                txtEmail.Text = $"{cliente.Email}";
                txtRfc.Text = $"{cliente.Rfc}";
                cmbTipoPersona.SelectedValue = cliente.TipoPersona;
                cmbRegimenFiscal.SelectedValue = cliente.RegimenFiscal;
                chkFoliosDigitales.IsChecked = cliente.ServFoliosDigitales;
                chkContabilidad.IsChecked = cliente.ServContabilidad;
                chkMicrosip.IsChecked = cliente.ServMicrosip;
                txtNombreContacto.Text = $"{cliente.NombreContacto}";
                txtEmailContacto.Text = $"{cliente.EmailContacto}";
                txtTelefonoContacto.Text = $"{cliente.TelefonoContacto}";
            }
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClienteModel cliente = new ClienteModel();
                cliente.NombreCliente = txtName.Text;
                cliente.Calle = txtCalle.Text;
                cliente.Colonia = txtColonia.Text;
                cliente.CodigoPostal = txtCP.Text;
                cliente.Municipio = txtMunicipio.Text;
                cliente.Estado = txtEstado.Text;
                cliente.Pais = txtPais.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Email = txtEmail.Text;
                cliente.Rfc = txtRfc.Text;
                cliente.TipoPersona = cmbTipoPersona.SelectedItem.ToString();
                cliente.RegimenFiscal = cmbTipoPersona.SelectedItem.ToString();
                cliente.ServFoliosDigitales = (chkFoliosDigitales.IsChecked == true) ? true : false;
                cliente.ServContabilidad = (chkContabilidad.IsChecked == true) ? true : false;
                cliente.ServMicrosip = (chkMicrosip.IsChecked == true) ? true : false;
                cliente.NombreContacto = txtNombreContacto.Text;
                cliente.EmailContacto = txtEmailContacto.Text;
                cliente.TelefonoContacto = txtTelefonoContacto.Text;

                EditClientViewModel editClient = new EditClientViewModel();
                ClienteViewModel clientViewModel = new ClienteViewModel();
                ClienteView c = new ClienteView();
                if (ClienteId > 0)
                {
                    cliente.ClienteId = ClienteId;
                    if (editClient.EditClient(cliente))
                    {
                        MessageBox.Show("Se actualizo la informacion correctamente...");
                        
                        
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al actualizar la informacion...");
                    }
                }
                else
                {
                    if (editClient.AddClient(cliente))
                    {
                        MessageBox.Show("Se guardo la informacion con exito...");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al guardar la informacion...");
                    }
                }

                var lstClientes = clientViewModel.GetAllClients();
                c.clientes.ItemsSource = lstClientes;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private List<string> GetAllTipoPersonas()
        {
            EditClientViewModel ec = new EditClientViewModel();
            var lstTP = ec.GetAllTipoPersonas();

            return lstTP;
        }

        private List<string> GetAllRegimenFiscal()
        {
            EditClientViewModel ec = new EditClientViewModel();
            var lstRF = ec.GetAllRegimenFiscal();


            return lstRF;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            cmbTipoPersona.ItemsSource = GetAllTipoPersonas();
            cmbRegimenFiscal.ItemsSource = GetAllRegimenFiscal();
        }
    }
}
