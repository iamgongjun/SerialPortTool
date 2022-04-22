using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using LongerPumpDemo.Model;
using System.Windows.Input;

namespace LongerPumpDemo.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
        }

        private SendOrderParameterSourceModel _sendOrderSourceParameter;
        public SendOrderParameterSourceModel SendOrderSourceParameter
        {
            get 
            {
                return _sendOrderSourceParameter = _sendOrderSourceParameter == null ? 
                    new SendOrderParameterSourceModel(): _sendOrderSourceParameter;
            } 
        }

        private SendOrderCheckedParameterModel _sendOrderCheckedParameterModel;
        public SendOrderCheckedParameterModel SendOrderCheckedParameterModel
        {
            get
            {
                return _sendOrderCheckedParameterModel = _sendOrderCheckedParameterModel == null ?
                    new SendOrderCheckedParameterModel() : _sendOrderCheckedParameterModel;
            }
            set 
            {
                _sendOrderCheckedParameterModel = value;
                RaisePropertyChanged(()=>SendOrderCheckedParameterModel);
            }
        }

        private ICommand _sendOrderCommand;
        public ICommand SendOrderCommand
        {
            get
            {
                return new RelayCommand<string>(SendOrderExecute, SendOrderCanExecute);
            }
        }

        private bool SendOrderCanExecute(string order)
        {
            return (!(order == null)) && (order.Length > 0);
        }

        private void SendOrderExecute(string order)
        {
            new SerialPortSendOrder(SendOrderCheckedParameterModel).SendOrder(order);
        }
    }
}