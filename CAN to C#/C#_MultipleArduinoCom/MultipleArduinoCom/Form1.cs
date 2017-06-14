using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using uPLibrary.Networking.M2Mqtt;

namespace MultipleArduinoCom
{
    public partial class Form1 : Form
    {
        ArduinoSerialPort Arduino1 = new ArduinoSerialPort("COM6", 9600);

        // MQTT Constants
        private const string MqttBroker = "146.185.157.205";
        private const string MqttUser = "debug";
        private const string MqttPass = "fhict";
        private MqttClient client;

        public Form1()
        {
            InitializeComponent();

            if(Arduino1.Connect())
            {
                lblArduino1.Text = "Arduino1: Connected!";
            }

            // Setup MQTT
            client = new MqttClient(MqttBroker);
            string clientId = Guid.NewGuid().ToString();
            try
            {
                client.Connect(clientId, MqttUser, MqttPass);
            }
            catch (Exception e)
            {
                MessageBox.Show("MQTT Connection broken, check your internet connection and restart.");
                this.Close();
            }
            client.Publish("DRINQ", Encoding.ASCII.GetBytes("CAN-Uart Node Started"));
            

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Arduino1.close();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Arduino1.hasData())
            {
                string msg = Arduino1.readData();
                lbReadedDataArduino1.Items.Add(msg);
                client.Publish("DRINQ", Encoding.ASCII.GetBytes(msg));
            }
            lbReadedDataArduino1.SelectedIndex = lbReadedDataArduino1.Items.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbReadedDataArduino1.Items.Clear();
        }
    }
}
