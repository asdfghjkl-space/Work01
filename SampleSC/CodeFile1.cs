
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
        var scores = new int[] { 54, 77, 12, 53, 48 };

        for (int i = 0; i < scores.Length; i++)
        {
            Console.WriteLine(scores[i]);
        }
    }
}