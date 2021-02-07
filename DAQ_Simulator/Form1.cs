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
            daqMinVolt = 0.0;
            daqMaxVolt = 10.0;
            daqResolution = 14;
            loggDateTime = false;

            timeStamp = DateTime.Now;
            nextAllowedSamplingTime = DateTime.Now;

            analogSensors = createSensorArray(amountAnalogDevices, true, daqMinVolt, daqMaxVolt);
            digitalSensors = createSensorArray(amountDigitalDevices, false);


        }

        private Sensor[] createSensorArray(int amountOfSensors, bool isAnalog, double minV = 0, double maxV = 1)
        {
            int counter;
            // Create an array of sensor objects
            Sensor[] sObj = new Sensor[amountOfSensors];
            for (counter = 0; counter < amountOfSensors; counter++)
            {
                sObj[counter] = new Sensor(counter, isAnalog, minV, maxV);
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
            if (enoughTimePassed())
            {
                printToSensorValueTextField();
            }
            else
            {

            }
        }

        private bool enoughTimePassed()
        {
            timeStamp = DateTime.Now;
            int result = DateTime.Compare(nextAllowedSamplingTime, timeStamp);



            if (result < 0)
            {
                nextAllowedSamplingTime = DateTime.Now;
                nextAllowedSamplingTime = nextAllowedSamplingTime.AddSeconds(samplingTime);
                txtSampling.Text = nextAllowedSamplingTime.ToString();
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
                sTxt = string.Concat(sTxt, analogSensors[counter].GetValue() + System.Environment.NewLine);
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

        public Sensor(int id, bool isAnalog, double minV = 0, double maxV = 1)
        {
            isAnalogSen = isAnalog;
            sId = id;
            rSensVal = new Random(id);
            dVal = 0.0F;
            minVal = minV;
            maxVal = maxV;
        }
        public double GetValue()
        {
            if (isAnalogSen)
            {
                dVal += 10*(rSensVal.NextDouble() - 0.5);
                dVal = clamp(dVal, minVal, maxVal);
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
    }
    /////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Class to represent the sensors. A sinus function was use d to represent a 
    /// countinous function which changes over time.
    /// </summary>
    //public class Sensor
    //{
    //    public bool isAnalog = new bool();
    //    public double minVal = new double();
    //    public double maxVal = new double();

    //    // Parameters for the signal 
    //    private double a = new double();
    //    private double b = new double();
    //    private double c = new double();
    //    private double d = new double();

    //    private Random randomGenerator = new Random();
    //    private double rnd1 = new double();
    //    private double rnd2 = new double();
    //    private double rnd3 = new double();
    //    private double rnd4 = new double();

    //    /// <summary>
    //    ///  Constructor for AnalogSensor. Sets the sensor as digital
    //    /// </summary>
    //    public Sensor()
    //    {
    //        isAnalog = false;
    //        minVal = -8;
    //        maxVal = 10;
    //        rnd1 = randomGenerator.NextDouble();
    //        rnd2 = randomGenerator.NextDouble();
    //        rnd3 = randomGenerator.NextDouble();
    //        rnd4 = randomGenerator.NextDouble();
    //        setParameters(minVal, maxVal);
    //    }

    //    /// <summary>
    //    ///  Constructor for AnalogSensor. set
    //    /// </summary>
    //    /// <param name="isAnalogSensor"></param>
    //    public Sensor(bool isAnalogSensor)
    //    {
    //        isAnalog = isAnalogSensor;
    //        minVal = -8;
    //        maxVal = 10;
    //        rnd1 = randomGenerator.NextDouble();
    //        rnd2 = randomGenerator.NextDouble();
    //        rnd3 = randomGenerator.NextDouble();
    //        rnd4 = randomGenerator.NextDouble();
    //        setParameters(minVal, maxVal);
    //    }

    //    public bool setMinMaxVal(double minV, double maxV)
    //    {
    //        bool finished = false;
    //        minVal = minV;
    //        maxVal = maxV;
    //        finished = setParameters(minV, maxV);

    //        return finished;
    //    }


    //    double getMeasurment(double time)
    //    {
    //        double y = a*Math.Sin(b*time + c) + d;
    //        double z = 0;

    //        if (isAnalog)
    //        {
    //            z = clamp(y, minVal, maxVal);
    //        }
    //        else
    //        {
    //            y = (double)Math.Round(y);
    //            z = clamp(y, 0, 1);
    //        }

    //        return z;
    //    }

    //    // Set parameters for the function
    //    private bool setParameters(double minV, double maxV)
    //    {
    //        a = maxV*rnd1 - minV*rnd1;
    //        b = a*rnd2;
    //        c = (a/2)*rnd3;
    //        d = maxV*rnd4 - minV*rnd4;
    //        return true;
    //    }

    //    private double clamp(double x, double min, double max)
    //    {
    //        double y = 0;
    //        if (max < x)
    //        {
    //            y = max;
    //        }
    //        else if (min > x)
    //        {
    //            y = min;
    //        }
    //        else
    //        {
    //            y = x;
    //        }
    //        return y;
    //    }
    //}
//}
////////////////////////////////////////////////////////////////////////////////////


//public class DigitalSensor
//{

//    // Constructor for sensor
//    public DigitalSensor()
//    {

//    }


//    bool measured(double time)
//    {

//    }
//}

// Class to return machine time in seconds 
// source: https://dirask.com/posts/C-NET-get-current-machine-time-in-seconds-ZDNLnj
//public static class TimeUtils
//    {
//        public static double GetSeconds()
//        {
//            double timestamp = Stopwatch.GetTimestamp();
//            double seconds = timestamp / Stopwatch.Frequency;

//            return seconds;
//        }
//    }

}
