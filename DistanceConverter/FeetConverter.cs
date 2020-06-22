using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter
{
    //フィートとメートルの単位変換クラス
    public static class FeetConverter
    {
        //定数
        private const double ratio = 0.3048;

        //メートルからフィートを求める（静的メソッドとして定義）
        public static double FromMeter(double meter)
        {
            return meter * ratio;
        }

        //フィートからメートルを求める（静的メソッドとして定義）
        public static double ToMeter(double feet)
        {
            return feet * 3.28084; //即値←数字を直接打つのはダメ×
        }
    }
}
