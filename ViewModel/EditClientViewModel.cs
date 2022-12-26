using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPAO.Administracion.Model;
using IPAO.Administracion.Repositories;

namespace IPAO.Administracion.ViewModel
{
    public class EditClientViewModel : ViewModelBase
    {
        private IGenericRepository genericRepository;

        public EditClientViewModel()
        {
            genericRepository = new GenericRepository();
        }

        public ClienteModel GetClientById(int id)
        {
            genericRepository = new GenericRepository();
            var cliente = genericRepository.GetByClientId(id);

            return cliente;
        }

        public List<string> GetAllTipoPersonas()
        {
            genericRepository = new GenericRepository();
            var lstTP = genericRepository.GetAllTipoPersona();

            return lstTP;
        }


        public List<string> GetAllRegimenFiscal()
        {
            genericRepository = new GenericRepository();
            var lstRF = genericRepository.GetAllRegimenFiscal();

            return lstRF;
        }

        public bool AddClient(ClienteModel cliente)
        {
            genericRepository = new GenericRepository();
            var addcliente = genericRepository.AddClient(cliente);

            return addcliente;
        }

        public bool EditClient(ClienteModel cliente)
        {
            genericRepository = new GenericRepository();
            var editcliente = genericRepository.EditClient(cliente);

            return editcliente;
        }
    }
}
