using LongerPumpDemo.API;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace LongerPumpDemo.Model
{
    public class SerialPortSendOrder
    {
        SendOrderCheckedParameterModel SendOrderCheckedParameters;
        public SerialPortSendOrder(SendOrderCheckedParameterModel SendOrderCheckedParameterModel)
        {
            if (SendOrderCheckedParameterModel == null) throw new ArgumentNullException("参数为NULL");
            this.SendOrderCheckedParameters = SendOrderCheckedParameterModel;
        }
        /// <summary>
        /// 命令发送
        /// </summary>
        /// <returns></returns>
        public bool SendOrder() 
        {
            SerialPort.PortName = SendOrderCheckedParameters.SerialPort;
            SerialPort.BaudRate = Convert.ToInt32(SendOrderCheckedParameters.BaudRate);
            SerialPort.DataBits = Convert.ToInt32(SendOrderCheckedParameters.DataBit);
            switch (SendOrderCheckedParameters.StopBit)
            {
                case "1":
                    SerialPort.StopBits = StopBits.One;
                    break;
                case "1.5":
                    SerialPort.StopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    SerialPort.StopBits = StopBits.Two;
                    break;
                default:
                    throw new ArgumentException("选择停止位参数不正确");
            }
            switch (SendOrderCheckedParameters.CheckBit)
            {
                case "NO":
                    SerialPort.Parity = Parity.None;
                    break;
                case "ODD":
                    SerialPort.Parity = Parity.Odd;
                    break;
                case "EVEN":
                    SerialPort.Parity = Parity.Even;
                    break;
                default:
                    throw new ArgumentException("校验位不正确");
            }
            SerialPort.ReadTimeout = 500;
            SerialPort.WriteTimeout = 500;
            if (!SerialPort.IsOpen) 
            {
                SerialPort.DataReceived += SerialPortDataReceived;
                try
                {
                    SerialPort.Open();
                }
                catch (UnauthorizedAccessException exception) 
                {
                    SerialPort.Close();
                    MessageBox.Show("当前串口被占用");
                    return false;
                }
            }
            SerialPort.Write(SendOrderCheckedParameters.Order.HexStringToBytes(),
              0, SendOrderCheckedParameters.Order.HexStringToBytes().Length);
            return true;
        }
        /// <summary>
        /// 命令发送
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public bool SendOrder(string order)
        {
            SerialPort.PortName = SendOrderCheckedParameters.SerialPort;
            SerialPort.BaudRate = Convert.ToInt32(SendOrderCheckedParameters.BaudRate);
            SerialPort.DataBits = Convert.ToInt32(SendOrderCheckedParameters.DataBit);
            SerialPort.ReadTimeout = 500;
            SerialPort.WriteTimeout = 500;
            SerialPort.Encoding= Encoding.ASCII;
            switch (SendOrderCheckedParameters.StopBit)
            {
                case "1":
                    SerialPort.StopBits = StopBits.One;
                    break;
                case "1.5":
                    SerialPort.StopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    SerialPort.StopBits = StopBits.Two;
                    break;
                default:
                    throw new ArgumentException("选择停止位参数不正确");
            }
            switch (SendOrderCheckedParameters.CheckBit)
            {
                case "NO":
                    SerialPort.Parity = Parity.None;
                    break;
                case "ODD":
                    SerialPort.Parity = Parity.Odd;
                    break;
                case "EVEN":
                    SerialPort.Parity = Parity.Even;
                    break;
                default:
                    throw new ArgumentException("校验位不正确");
            }

            if (!SerialPort.IsOpen)
            {
                SerialPort.DataReceived += SerialPortDataReceived;
                try
                {
                    SerialPort.Open();
                }
                catch (UnauthorizedAccessException exception)
                {
                    SerialPort.Close();
                    MessageBox.Show("当前串口被占用");
                    return false;
                }
            }
            SerialPort.Write(order.HexStringToBytes(),
            0, order.HexStringToBytes().Length);
            return true;
        }
        private SerialPort _serialPort = new SerialPort();
        public SerialPort SerialPort
        {
            get
            {
                return _serialPort;
            }
        }
        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);
            SerialPort serialPort = (SerialPort)sender;
            byte[] buf = new byte[serialPort.BytesToRead];
            char[] c = new char[serialPort.BytesToRead];
            //string s =serialPort.ReadExisting();
            restart:
            serialPort.Read(buf, 0, serialPort.BytesToRead);
            SendOrderCheckedParameters.ReceiveData += buf.StringToHexString() + "\n";
                 SerialPort.Close();
        }
    }
}
