using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace MultipleArduinoCom
{
    class ArduinoSerialPort
    {
        private string comPort;
        private Int32 baudRate;
        private SerialPort ArduinoSerial = new SerialPort();
        public ArduinoSerialPort(string COMport, Int32 BaudRate)
        {
            comPort = COMport;
            baudRate = BaudRate;
        }

        public bool Connect()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                if (port.Contains(comPort))
                {
                    ArduinoSerial.PortName = comPort;
                    ArduinoSerial.BaudRate = 9600;
                    ArduinoSerial.Open();
                    return true;
                }
            }
            return false;
        }

        public bool hasData()
        {
            if (ArduinoSerial.IsOpen && ArduinoSerial.BytesToRead > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string readData()
        {
            if (!ArduinoSerial.IsOpen) return null;
            return ArduinoSerial.ReadLine();
        }

        public bool writeData(string data)
        {
            if (!ArduinoSerial.IsOpen) return false;
            ArduinoSerial.Write(data + '\n');
            return true;
        }

        public void close()
        {
            ArduinoSerial.Close();
        }
    }
}
