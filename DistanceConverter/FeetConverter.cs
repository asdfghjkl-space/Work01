﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter
{
    //フィートとメートルの単位変換クラス
    static class FeetConverter
    {
        //メートルからフィートを求める（静的メソッドとして定義）
        public static double FromMeter(double meter)
        {
            return meter * 0.3048;
        }

        //フィートからメートルを求める（静的メソッドとして定義）
        public static double ToMeter(double feet)
        {
            return feet * 3.28084;
        }
    }
}
