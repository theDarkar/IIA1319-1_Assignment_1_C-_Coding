using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

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
        public bool loggTime = new bool();
        public string filePath;
        public string csvSep;
        public StringBuilder csv = new StringBuilder();
       
        public DateTime timeStamp;
        public DateTime nextAllowedSamplingTime;
        public DateTime nextAllowedLoggingTime;

        public Sensor[] analogSensors;
        public Sensor[] digitalSensors;
        public double[] aSensLog;
        public double[] dSensLog;

        

        public Form1()
        {
            InitializeComponent();
            amountAnalogDevices = 5;
            amountDigitalDevices = 2;
            samplingTime = 2.8;
            loggingTime = 28;
            daqMinVolt = 0.0;
            daqMaxVolt = 10.0;
            daqResolution = 14;
            loggDateTime = false;
            loggTime = false;
            filePath = "log.csv";// Places file in the debug folder
            csvSep = ";";

            aSensLog = new double[amountAnalogDevices];
            dSensLog = new double[amountDigitalDevices];

            timeStamp = DateTime.Now;
            nextAllowedSamplingTime = DateTime.Now;
            nextAllowedLoggingTime = DateTime.Now;

            analogSensors = createSensorArray(amountAnalogDevices, true, daqMinVolt, daqMaxVolt, daqResolution);
            digitalSensors = createSensorArray(amountDigitalDevices, false, 0, 1, daqResolution);

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
            nextAllowedSamplingTime = DateTime.Now;
            nextAllowedSamplingTime = nextAllowedSamplingTime.AddSeconds(samplingTime);
            txtSampling.Text = nextAllowedSamplingTime.ToString();
            nextAllowedLoggingTime = DateTime.Now;
            txtLogging.Text = nextAllowedLoggingTime.ToString();
            printToSensorValueTextField();

            csv.AppendLine("sep=" + csvSep);
            File.WriteAllText(filePath, csv.ToString());

            int counter;
            string sTxt = "Date and time";
            for (counter = 0; counter < aSensLog.Length; counter++)
            {
                sTxt = sTxt + csvSep + "Analog Sensor " + analogSensors[counter].GetSensId();
            }
            for (counter = 0; counter < dSensLog.Length; counter++)
            {
                sTxt = sTxt + csvSep + "Digital Sensor " + digitalSensors[counter].GetSensId();
            }
            csv.AppendLine(sTxt);
            File.WriteAllText(filePath, csv.ToString());
        }

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
                aSensLog[counter] = monvingAverage(10, analogSensors[counter]);
                sTxt = string.Concat(sTxt, "Analog Sensor " + analogSensors[counter].GetSensId() + " :  ");
                sTxt = string.Concat(sTxt, aSensLog[counter] + System.Environment.NewLine);
                txtSensorVal.Text = sTxt;
            }

            for (counter = 0; counter < digitalSensors.Length; counter++)
            {
                dSensLog[counter] = digitalSensors[counter].GetValue();
                sTxt = string.Concat(sTxt, "Digital Sensor " + digitalSensors[counter].GetSensId() + " :  ");
                sTxt = string.Concat(sTxt, dSensLog[counter] + System.Environment.NewLine);
                txtSensorVal.Text = sTxt;
            }

            txtSensorVal.Text = sTxt;
        }


        private void btnLogOnFile_Click(object sender, EventArgs e)
        {
            if (enoughTimePassed(nextAllowedLoggingTime))
            {
                nextAllowedLoggingTime = DateTime.Now;
                nextAllowedLoggingTime = nextAllowedLoggingTime.AddSeconds(loggingTime);
                txtLogging.Text = nextAllowedLoggingTime.ToString();
                printToCSV();
            }
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


        public void printToCSV()
        {
            int counter;
            string sTxt = "--.--.---- --:--:--";
            if (loggTime)
            {
                sTxt = DateTime.Now.ToString();
            }


            for (counter = 0; counter < aSensLog.Length; counter++)
            {
                sTxt = sTxt + csvSep + aSensLog[counter];
            }
            
            for (counter = 0; counter < dSensLog.Length; counter++)
            {
                sTxt = sTxt + csvSep + dSensLog[counter];
            }

            csv.AppendLine(sTxt);

            File.WriteAllText(filePath, csv.ToString());
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
        private int res;
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

            daqRes = getDaqRes(res, maxVal, minVal);
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

            daqRes = getDaqRes(res, maxVal, minVal);
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

        private double[] getDaqRes(int res, double maxV, double minV)
        {
            int counter;
            double[] daqRes = new double[res];
            for (counter = 0; counter < res; counter++)
            {
                daqRes[counter] = (maxV + minV) * (((double)counter) / ((double)res)) + minV;
            }
            return daqRes;
        }

        public double findClosest(double[] arr, double target)
        {
            int counter;
            int closestIndex = -1;
            double lowestSub = 1000000;
            for (counter = 0; counter < arr.Length; counter++)
            {
                double sub = Math.Abs(arr[counter] - target);
                if (lowestSub > sub)
                {
                    closestIndex = counter;
                    lowestSub = sub;
                }
            }
            double nearest = arr[closestIndex];
            return (double)nearest;
        }
    }
    /////////////////////////////////////////////////////////

   
}
