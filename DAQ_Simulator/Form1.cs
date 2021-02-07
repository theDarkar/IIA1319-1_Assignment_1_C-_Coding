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
        public double loggingTime = new double();
        public double daqMinVolt = new double();
        public double daqMaxVolt = new double();
        public int daqResolution = new int();
        public bool loggDateTime = new bool();

       
        public DateTime timeStamp;
        public DateTime nextAllowedSamplingTime;

        private Sensor[] analogSensors;
        private Sensor[] digitalSensors;

        

        public Form1()
        {
            InitializeComponent();
            amountAnalogDevices = 5;
            amountDigitalDevices = 2;
            samplingTime = 2.8;
            loggingTime =
            daqMinVolt = 0.0;
            daqMaxVolt = 10.0;
            daqResolution = 14;
            loggDateTime = false;

            timeStamp = DateTime.Now;
            nextAllowedSamplingTime = DateTime.Now;

            analogSensors = createSensorArray(amountAnalogDevices, true, daqMinVolt, daqMaxVolt);
            digitalSensors = createSensorArray(amountDigitalDevices, false,0,1);

        }

        private Sensor[] createSensorArray(int amountOfSensors, bool isAnalog, double minV, double maxV, int resolution)
        {
            int counter;
            // Create an array of sensor objects
            Sensor[] sObj = new Sensor[amountOfSensors];
            if (isAnalog)
            {
                for (counter = 0; counter < amountOfSensors; counter++)
                {
                    sObj[counter] = new Sensor(counter, isAnalog, minV, maxV, resolution);
                } 
            }
            else
            {
                for (counter = 0; counter < amountOfSensors; counter++)
                {
                    sObj[counter] = new Sensor(counter, isAnalog);
                }
            }

            return sObj;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }



        //void saveToCSV()
        //{
        //    int counter, maxSid = 16;
        //    string sTxt;
        //    // Create an array of sensor objects
        //    Sensor[] sObj = new Sensor[maxSid];
        //    for (counter = 0; counter < maxSid; counter++)
        //    {
        //        sObj[counter] = new Sensor(counter);
        //    }
        //    // Get the object values as a string
        //    for (counter = 0; counter < maxSid; counter++)
        //    {
        //        sTxt = sObj[counter].GetValue().ToString("F3");
        //    }
        //}

        private void btnSampling_Click(object sender, EventArgs e)
        {
            if (enoughTimePassed(nextAllowedSamplingTime))
            {
                nextAllowedSamplingTime = DateTime.Now;
                nextAllowedSamplingTime = nextAllowedSamplingTime.AddSeconds(samplingTime);
                txtSampling.Text = nextAllowedSamplingTime.ToString();
                printToSensorValueTextField();
            }
        }

        private bool enoughTimePassed(DateTime nextAllowedTime)
        {
            DateTime timeStamp = DateTime.Now;
            int result = DateTime.Compare(nextAllowedTime, timeStamp);

            if (result < 0)
            {
                return true;
            }
            else
            {
                return false;
            }   
        }

        public void printToSensorValueTextField()
        {
            int counter;
            string sTxt = "";

            for (counter = 0; counter < analogSensors.Length; counter++)
            {
                sTxt = string.Concat(sTxt, "Analog Sensor " + counter + " :  ");
                sTxt = string.Concat(sTxt, monvingAverage(10, analogSensors[counter]) + System.Environment.NewLine);
                txtSensorVal.Text = sTxt;
            }

            for (counter = 0; counter < digitalSensors.Length; counter++)
            { 
                sTxt = string.Concat(sTxt, "Digital Sensor " + counter + " :  ");
                sTxt = string.Concat(sTxt, digitalSensors[counter].GetValue() + System.Environment.NewLine);
                txtSensorVal.Text = sTxt;
            }

            txtSensorVal.Text = sTxt;
        }

        private void btnLogOnFile_Click(object sender, EventArgs e)
        {
            //if (enoughTimePassed(nextAllowedLoggingTime))
            //{
            //    nextAllowedLoggingTime = DateTime.Now;
            //    nextAllowedLoggingTime = nextAllowedLoggingTime.AddSeconds(samplingTime);
            //    txtLogging.Text = nextAllowedLoggingTime.ToString();
            //    printToCSV();
            //}
        }

        private double monvingAverage(int size, Sensor sensor)
        {
            int counter;
            double sum = 0;
            for (counter = 0; counter < size; counter++)
            {
                sum += sensor.GetValue();
            }
            double result = sum / size;
            return result;
        }
    }

    /////////////////////////////////////////////////////////
    /// <summary>
    /// Class to hold a sensor
    /// </summary>
    public class Sensor
    {
        private double dVal;
        private int sId;
        private Random rSensVal;
        private bool isAnalogSen;
        private double minVal;
        private double maxVal;
        private double res;
        private double[] daqRes;

        public Sensor(int id, bool isAnalog)
        {
            isAnalogSen = isAnalog;
            sId = id;
            rSensVal = new Random(id);
            dVal = 0.0F;
            minVal = 0;
            maxVal = 1;
            res = 16;

            int counter;
            for (counter = 0; counter < res; counter++)
            {
                daqRes[counter] = counter/res;
            }
        }

        public Sensor(int id, bool isAnalog, double minV, double maxV, int resolution)
        {
            isAnalogSen = isAnalog;
            sId = id;
            rSensVal = new Random(id);
            dVal = 0.0F;
            minVal = minV;
            maxVal = maxV;
            res = resolution;

            int counter;
            for (counter = 0; counter < res; counter++)
            {
                daqRes[counter] = counter / res;
            }
        }
        public double GetValue()
        {
            if (isAnalogSen)
            {
                dVal += 10*(rSensVal.NextDouble() - 0.4);
                dVal = clamp(dVal, minVal, maxVal);

                dVal = findClosest(daqRes, dVal);
            }
            else
            {
                dVal += 2*(rSensVal.NextDouble() - 0.5);
                dVal = Math.Round(clamp(dVal, minVal, maxVal));
            }
            return dVal;
        }
        public int GetSensId()
        {
            return sId;
        }
        /// <summary>
        /// Clamps the x value between a min and max value
        /// </summary>
        /// <param name="x"> Input value </param> 
        /// <param name="min"> Max allowed value </param> 
        /// <param name="max"> Min allowed value </param> 
        /// <returns> Returns the clamped value </returns> 
        private double clamp(double x, double min, double max)
        {
            double y = 0;
            if (max < x)
            {
                y = max;
            }
            else if (min > x)
            {
                y = min;
            }
            else
            {
                y = x;
            }
            return y;
        }

        public double findClosest(double[] arr,double target)
        {
            var nearest = arr.OrderBy(x => Math.Abs((long)x - target)).First();
            return (double) nearest;
        }
    }
    /////////////////////////////////////////////////////////

   
}
