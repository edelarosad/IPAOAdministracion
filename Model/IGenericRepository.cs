using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPAO.Administracion.ViewModel;

namespace IPAO.Administracion.Model
{
    public interface IGenericRepository
    {
        bool AddClient(ClienteModel usuarioModel);
        bool EditClient(ClienteModel usuarioModel);
        bool RemoveClient(int Id);
        ClienteModel GetByClientId(int id);
        DataCaptureViewModel GetClientByName(string name);
        DataCaptureAccountingViewModel GetClientByNameAccounting(string name);
        List<ClienteViewModel> GetAllClients();
        List<string> GetAllTipoPersona();
        List<string> GetAllRegimenFiscal();
        List<string> GetAllClientsCombobox();
        RespuestaBDViewModel AddOrEditDataCapture(DataCaptureViewModel dataCapture);
        RespuestaBDViewModel AddOrEditDataCaptureAccounting(DataCaptureAccountingViewModel dataCapture);
    }
}
