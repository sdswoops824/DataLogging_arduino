using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter PGM or PAM  ");
            //string tom = Console.ReadLine();
            //int itom = int.Parse(tom);

            //Console.WriteLine("Enter the length of muscle  ");
            //string lom = Console.ReadLine();

            //Console.WriteLine("Enter SMC1, SMC2, KOG  ");
            //string tov = Console.ReadLine();

            Console.WriteLine("Enter InputPressure in MPa  ");
            double ip = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter User Data  ");
            string sl = Console.ReadLine();

            Console.WriteLine("Please wait....");

            double[] dd = new double[6];

            SerialPort myport1 = new SerialPort();
            myport1.BaudRate = 9600;
            myport1.PortName = "COM12";
            myport1.DataBits = 8;

            myport1.Open();

            /*SerialPort myport0 = new SerialPort();
            myport0.BaudRate = 9600;
            myport0.PortName = "COM8";
            myport0.DataBits = 8;
            myport0.Open();*/

            //string filepath = @"D:\TEMP\DONOTEDIT\" + tom + "_" + lom + "_" + tov + "_" + ip + "_" + sl + ".csv";
            string filepath1 = @"D:\ONEDRIVE\OneDrive - Hiroshima University\LABWORK\Lab_Instructions\ToyodaSan_HUH\DataLogging\" + DateTime.Now.ToString("MM") + "_" +
                DateTime.Now.ToString("dd") + "_" + DateTime.Now.ToString("hh") + "_" + DateTime.Now.ToString("mm") + "_" + ip + "_" + sl + ".csv";

            System.IO.File.WriteAllText(filepath1, "Hour" + "," + "Minute" + "," + "Second_ms" + "," + "Sensing" + Environment.NewLine);

            while (myport1.IsOpen || myport1.IsOpen == true)
            {
                string hour = DateTime.Now.ToString("HH");
                string minute = DateTime.Now.ToString("mm");
                string second_ms = DateTime.Now.ToString("ss.fff");
                string csv1 = myport1.ReadLine();

                //int bytes = myport0.BytesToRead;
                //byte[] respbuffer = new byte[bytes];
                //myport0.Read(respbuffer, 0, bytes);

                //Console.WriteLine(csv);
                System.IO.File.AppendAllText(filepath1, hour + "," + minute + "," + second_ms + "," + csv1);
            }
        }
    }
}
