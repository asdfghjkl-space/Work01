
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
        var scores = new int[5];

        for(int i = 0; i< scores.Length; i++)
        {
            scores[i] = 20 * (i + 1);
            Console.WriteLine(scores[i]);
        }

        //for (int i = 0; i < scores.Length; i++)
        //{
        //    Console.WriteLine(scores[i]);
        //}
    }
}