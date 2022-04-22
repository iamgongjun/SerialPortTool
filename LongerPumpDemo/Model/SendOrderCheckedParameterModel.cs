using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;

namespace SerialPortTool.Model
{
    public class SendOrderCheckedParameterModel : ObservableObject
    {
        private string _serialPort;
        public string SerialPort 
        {
            get 
            {
                return _serialPort;
            }
            set 
            {
                _serialPort = value;
                RaisePropertyChanged(() => SerialPort);
            }
        }
        private string _baudRate;
        public string BaudRate
        {
            get
            {
                return _baudRate;
            }
            set
            {
                _baudRate = value;
                RaisePropertyChanged(()=>BaudRate);
            }
        }
        private string _dataBit;
        public string DataBit
        {
            get
            {
                return _dataBit;
            }
            set
            {
                _dataBit = value;
                RaisePropertyChanged(() => DataBit);
            }
        }
        private string _checkBit;
        public string CheckBit
        {
            get
            {
                return _checkBit;
            }
            set
            {
                _checkBit = value;
                RaisePropertyChanged(() => CheckBit);
            }
        }
        private string _stopBit;
        public string StopBit
        {
            get
            {
                return _stopBit;
            }
            set
            {
                _stopBit = value;
                RaisePropertyChanged(() => StopBit);
            }
        }
        private string _order;
        public string Order
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
                RaisePropertyChanged(() => Order);
            }
        }
        private string _receiveData;
        public string ReceiveData
        {
            get
            {
                return _receiveData;
            }
            set
            {
                _receiveData = value;
                RaisePropertyChanged(()=>ReceiveData);
            }
        }

        private bool _isCheckHex = true;
        public bool IsCheckHex
        {
            get
            {
                return _isCheckHex;
            }
            set
            {
                _isCheckHex = value;
                RaisePropertyChanged(() => IsCheckHex);
            }
        }
        private bool _isCheckAutoSaveOrder;
        public bool IsCheckAutoSaveOrder
        {
            get
            {
                return _isCheckAutoSaveOrder;
            }
            set
            {
                _isCheckAutoSaveOrder = value;
                RaisePropertyChanged(() => IsCheckAutoSaveOrder);
            }
        }

        private ICommand _clearOrderCommand;
        public ICommand ClearOrderCommand
        {
            get 
            {
                return _clearOrderCommand = _clearOrderCommand == null ? 
                    new RelayCommand(ClearExecute, ClearCanExecute):_clearOrderCommand;   
            }
        }

        private bool ClearCanExecute()
        {
            return !string.IsNullOrEmpty(Order);
        }

        private void ClearExecute()
        {
            Order = string.Empty;
        }
        private ICommand _clearReceiveDataCommand;
        public ICommand ClearReceiveDataCommand
        {
            get
            {
                return _clearReceiveDataCommand = _clearReceiveDataCommand == null ?
                    new RelayCommand(ClearReceiveDataExecute, ClearReceiveDataCanExecute) : _clearOrderCommand;
            }
        }

        private bool ClearReceiveDataCanExecute()
        {
            return !string.IsNullOrEmpty(ReceiveData);
        }

        private void ClearReceiveDataExecute()
        {
            ReceiveData = string.Empty;
        }
    }
}
