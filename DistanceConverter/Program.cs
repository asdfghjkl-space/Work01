using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter
{
    class Program
    {
        //-tom　フィートからメートルへの対応表
        //-tof　メートルからフィートへの対応表
        static void Main(string[] args)
        {
            if(args.Length >= 1 && args[0]== "-tom")
            {
                //フィートからメートルへの対応表を出力
                PrintFeetToMeterList(5, 50);

                //for (int feet = 1; feet <= 10; feet++)
                //{
                //    Console.WriteLine("{0} ft = {1:0.0000} m", feet, FeetToMeter(feet));
                //}
            }
            else
            {
                //メートルからフィートへの対応表を出力
                PrintMeterToFeetList(10, 100);

                //for (int meter = 1; meter <= 10; meter++)
                //{
                //    Console.WriteLine("{0} m = {1:0.00000} ft", meter, MeterToFeet(meter));
                //}
            }
        }

        //フィートからメートルを求める
        //引数:start 最初の値
        //    :stop  最後の値
        static void PrintFeetToMeterList(int start, int stop)
        {
            for (int feet = start; feet <= stop; feet++)
            {
                Console.WriteLine("{0} ft = {1:0.0000} m", feet,feet * 0.3048);
            }
        }

        //メートルからフィートを求める
        static void PrintMeterToFeetList(int start, int stop)
        {
            for (int meter = start; meter <= stop; meter++)
            {
                Console.WriteLine("{0} m = {1:0.0000} ft", meter, meter * 3.28084);
            }
        }
    }
}
