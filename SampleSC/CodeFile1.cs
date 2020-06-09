
using System;
using System.Windows.Forms;

class CodeFile1 : Form
{
    public static void Main()
    {
        Application.Run(new CodeFile1());
    }

    //デフォルトコンストラクタ
    public CodeFile1()
    {
        //var scores = new int[5];

        ////値の入力
        //for (var i = 0; i < scores.Length; i++)
        //{
        //    //整数値の取り込み
        //    var num = Console.ReadLine();

        //    var number = int.Parse(num);

        //    scores[i] = number;
        //}
        ////合計値
        //var total = 0;

        ////値の出力
        //for (int i = 0; i < scores.Length; i++)
        //{
        //    total += scores[i];
        //}

        //Console.WriteLine("入力された値の合計は、"+total+"です。");



        //アスタリスク出力
        var scores = new int[5];

        //入力
        for (int i = 0; i < scores.Length; i++)
        {
            Console.Write("scores[" + i + "]=");
            scores[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine();//改行

        //出力
        for (int j = 0; j < scores.Length; j++)
        {
            for (int i = 0; i < scores[j]; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();//改行
        }

        //for(int i = 0; i< scores.Length; i++)
        //{
        //    scores[i] = 20 * (i + 1);
        //    Console.WriteLine(scores[i]);
        //}

        //for (int i = 0; i < scores.Length; i++)
        //{
        //    Console.WriteLine(scores[i]);
        //}
    }
}