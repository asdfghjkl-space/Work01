
using System;
using System.Linq;
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
        #region//入力された値の合計を求める
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
        #endregion

        #region//アスタリスク出力
        //var scores = new int[5];

        ////入力
        //for (int i = 0; i < scores.Length; i++)
        //{
        //    Console.Write("scores[" + i + "]=");
        //    scores[i] = int.Parse(Console.ReadLine());
        //}

        //Console.WriteLine();//改行

        ////出力
        //for (int j = 0; j < scores.Length; j++)
        //{
        //    for (int i = 0; i < scores[j]; i++)
        //    {
        //        Console.Write("*");
        //    }
        //    Console.WriteLine();//改行
        //}
        #endregion

        #region//2の倍数
        //for(int i = 0; i< scores.Length; i++)
        //{
        //    scores[i] = 20 * (i + 1);
        //    Console.WriteLine(scores[i]);
        //}

        //for (int i = 0; i < scores.Length; i++)
        //{
        //    Console.WriteLine(scores[i]);
        //}
        #endregion

        #region//*を三角に表示
        //int num;

        //Console.Write("段数 : ");
        //num = int.Parse(Console.ReadLine());

        //Console.WriteLine();//改行

        //for (int j = 0; j < num; j++)
        //{
        //    //空白を入れる
        //    for (int i = 0; i < (num - j) - 1; i++)
        //    {
        //        Console.Write(" ");
        //    }

        //    //アスタリスク出力
        //    for (int i = 0; i < (j + 1); i++)
        //    {
        //        Console.Write(" *");
        //    }
        //    Console.WriteLine();//改行
        //}
        #endregion


        #region//Stringの勉強
        //stringの別名(エイリアス)がString
        //string moji = "";

        //moji = Console.ReadLine();

        ////Tolow大文字入力を小文字に変換
        ////ToUpp小文字入力を大文字に変換
        //Console.WriteLine("入力された文字 : " + moji.ToUpper());
        #endregion

        #region//演習5 入力された文字をカウント
        //string moji = "";

        //moji = Console.ReadLine();

        //Console.WriteLine("文字列 : " + moji.ToLower());
        //Console.WriteLine("文字数 : " + moji.Count());
        #endregion

        #region//文字の置換
        //string moji = "";
        //string moji2 = "";
        //string moji3 = "";

        //moji = Console.ReadLine();
        //moji2 = Console.ReadLine();
        //moji3 = Console.ReadLine();

        //Console.WriteLine("文字列 : " + moji.ToLower());
        //Console.WriteLine("置換前 : " + moji2.ToLower());
        //Console.WriteLine("置換後 : " + moji3.ToLower());
        //Console.WriteLine("文字列 : " + moji.Replace(moji2, moji3));
        #endregion
    }
}