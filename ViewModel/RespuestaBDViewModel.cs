using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPAO.Administracion.Model;
using IPAO.Administracion.Repositories;

namespace IPAO.Administracion.ViewModel
{
    public class RespuestaBDViewModel : ViewModelBase
    {
        private int _IntError;
        private string _StrMsg;

        public int IntError
        {
            get
            {
                return _IntError;
            }
            set
            {
                _IntError = value;
                OnPropertyChanged(nameof(IntError));
            }
        }

        public string StrMsg
        {
            get
            {
                return _StrMsg;
            }
            set
            {
                _StrMsg = value;
                OnPropertyChanged(nameof(StrMsg));
            }
        }
        
        private IGenericRepository genericRepository;
        public RespuestaBDViewModel()
        {
            genericRepository = new GenericRepository();
        }

        public RespuestaBDViewModel AddOrEditDataCapture(DataCaptureViewModel dataCapture)
        {
            var respuestaBD = genericRepository.AddOrEditDataCapture(dataCapture);

            return respuestaBD;
        }

        public RespuestaBDViewModel AddOrEditDataCaptureAccounting(DataCaptureAccountingViewModel dataCapture)
        {
            var respuestaBD = genericRepository.AddOrEditDataCaptureAccounting(dataCapture);

            return respuestaBD;
        }
    }
}
