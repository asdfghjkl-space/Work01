

using System.Windows.Forms;

class Stage : Form
{
    public static void Main()
    {
        Application.Run(new Stage());
    }

    public Stage()
    {
        //フォームの設定
        Width = 800;
        Height = 600;
        Text = "ボールシミュレーション";

    }
}