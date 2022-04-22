namespace LongerPumpDemo.Model
{
    public class SendOrderParameterSourceModel
    {
        private string[] _serialPorts;
        public string[] SerialPorts
        {
            get
            {
                return _serialPorts = (_serialPorts == null || _serialPorts.Length == 0) ?
                     System.IO.Ports.SerialPort.GetPortNames() : _serialPorts;
            }
        }
        private string[] _baudRates;
        public string[] BaudRates
        {
            get
            {
                return _baudRates = (_baudRates == null || _baudRates.Length == 0) ?
                     new string[] { "300", "600", "1200", "2400" } : _baudRates;
            }
        }
        private string[] _dataBits;
        public string[] DataBits
        {
            get
            {
                return _dataBits = (_dataBits == null || _dataBits.Length == 0) ?
                     new string[] { "5", "6", "7", "8" } : _dataBits;
            }
        }
        private string[] _checkBits;
        public string[] CheckBits
        {
            get
            {
                return _checkBits = (_checkBits == null || _checkBits.Length == 0) ?
                     new string[] { "NO", "EVEN", "ODD", "SPACE", "MASK" } : _checkBits;
            }
        }
        private string[] _stopBits;
        public string[] StopBits
        {
            get
            {
                return _stopBits = (_stopBits == null || _stopBits.Length == 0) ?
                     new string[] { "1", "1.5", "2" } : _stopBits;
            }
        }
    }
}
