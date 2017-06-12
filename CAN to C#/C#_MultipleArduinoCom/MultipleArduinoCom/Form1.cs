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
namespace MultipleArduinoCom
{
    public partial class Form1 : Form
    {
        ArduinoSerialPort Arduino1 = new ArduinoSerialPort("COM8", 9600);
        ArduinoSerialPort Arduino2 = new ArduinoSerialPort("COM7", 9600);
        public Form1()
        {
            InitializeComponent();

            if(Arduino1.Connect())
            {
                lblArduino1.Text = "Arduino1: Connected!";
            }
            if (Arduino2.Connect())
            {
                lblArduino2.Text = "Arduino2: Connected!";
            }

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Arduino1.close();
            Arduino2.close();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Arduino1.hasData())
            {
                lbReadedDataArduino1.Items.Add(Arduino1.readData());
            }
            if (Arduino2.hasData())
            {
                lbReadedDataArduino2.Items.Add(Arduino2.readData());
            }
            if(lbReadedDataArduino1.Items.Count > 20)
            {
                lbReadedDataArduino1.Items.Clear();
            }
            if(lbReadedDataArduino2.Items.Count > 20)
            {
                lbReadedDataArduino2.Items.Clear();
            }
        }
    }
}
