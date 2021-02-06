using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAQ_Simulator
{
    public partial class Form1 : Form
    {
        public int amountAnalogDevices = new int();
        public int amountDigitalDevices = new int();
        public double samplingTime = new double();
        public double daqMinVolt = new double();
        public double daqMaxVolt = new double();
        public int daqResolution = new int();
        public bool loggDateTime = new bool();


        public Form1()
        {
            InitializeComponent();
            amountAnalogDevices = 5;
            amountDigitalDevices = 2;
            samplingTime = 2.8;
            daqMinVolt = 0.0;
            daqMaxVolt = 10.0;
            daqResolution = 14;
            loggDateTime = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void saveToCSV()
        {
            
        }
    }
}
