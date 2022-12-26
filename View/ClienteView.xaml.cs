using System;
using System.Collections.Generic;
using System.Data;
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
using IPAO.Administracion.ViewModel;

namespace IPAO.Administracion.View
{
    /// <summary>
    /// Lógica de interacción para ClienteView.xaml
    /// </summary>
    public partial class ClienteView : UserControl
    {
        
        public ClienteView()
        {
            InitializeComponent();
            ClienteViewModel client = new ClienteViewModel();
            var lstClientes = client.GetAllClients();
            this.clientes.ItemsSource = lstClientes;

        }

        

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                EditClientModal client = new EditClientModal();
                client.ShowClient(0);
                client.ShowDialog();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClienteViewModel row = (ClienteViewModel)((Button)e.Source).DataContext;
                int id = row.ClienteId;
                var editClient = new EditClientModal();
                editClient.ShowClient(id);
                editClient.ShowDialog();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                ClienteViewModel row = (ClienteViewModel)((Button)e.Source).DataContext;
                if (row.DeleteClientById(row.ClienteId))
                {
                    var lstClients = row.GetAllClients();
                    this.clientes.ItemsSource = lstClients;
                    MessageBox.Show("El cliente se elimino con exito");
                }
                else
                {
                    MessageBox.Show("Hubo un error al momento de eliminar el cliente");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void pnlAddButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void pnlAddButton_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }
    }
}
