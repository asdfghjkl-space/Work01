

using System.Windows.Forms;

class Stage : Form
{
    //ボールオブジェクト表示用
    private PictureBox pictureBoxBall = new PictureBox();
    private Ball ball;
    private Timer timer = new Timer();

    public static void Main()
    {
        Application.Run(new Stage());
    }

    public Stage()
    {
        //フォームの設定
        Width = 1200;
        Height = 800;
        Text = "ボールシミュレーション";

        ball = new Ball();   //ボールオブジェクトの生成
        PictureBox pictureBox = new PictureBox();

        pictureBoxBall.Width = 100;
        pictureBoxBall.Height = 100;
        pictureBoxBall.Top = (int)ball.XPos;
        pictureBoxBall.Left = (int)ball.YPos;
        pictureBoxBall.Image = ball.Img;
        pictureBoxBall.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBoxBall.Parent = this;

        timer.Interval = 10;        //ms
        timer.Tick += Timer_Tick;   //時間経過で呼ぶメソッドを登録
        timer.Start();              //タイマースタート


    }

    //指定した時間が経過すると呼ばれるメソッド
    private void Timer_Tick(object sender, System.EventArgs e)
    {
        ball.Move();

        pictureBoxBall.Top = (int)ball.XPos;
        pictureBoxBall.Left = (int)ball.YPos;
    }
}