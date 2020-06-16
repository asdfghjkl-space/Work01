
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

class Stage : Form
{
    //ボールオブジェクト表示用
    //private PictureBox pictureBoxBall = new PictureBox();
    //private Ball ball;

    private List<PictureBox> pictureBoxBalls = new List<PictureBox>();
    private List<Ball> balls = new List<Ball>();

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
        Text = "ボールシミュレーション: 0";

        timer.Interval = 10;        //ms
        timer.Tick += Timer_Tick;   //時間経過で呼ぶメソッドを登録
        //timer.Start();              //タイマースタート

        this.MouseClick += Stage_MouseClick;
    }

    //マウスクリック時のイベントハンドラ
    private void Stage_MouseClick(object sender, MouseEventArgs e)
    {
        //クリックした座標を使いボールオブジェクトを生成
        string path = "";
        if(e.Button == MouseButtons.Left)
        {
            //ボールオブジェクトの生成
            path = @"images\soccer_ball.png";
        }
        else if(e.Button == MouseButtons.Right)
        {
            //ボールオブジェクトの生成
            path = @"images\tennis_ball.png";
        }
        else
        {
            return;
        }

        Ball ball = new Ball(e.X - 50, e.Y - 50, path);   //ボールオブジェクトの生成
        balls.Add(ball);

        PictureBox pictureBoxBall = new PictureBox();

        //クリックした座標を使いボールオブジェクトを生成
        pictureBoxBall.Width = 50;
        pictureBoxBall.Height = 50;
        pictureBoxBall.Top = (int)ball.YPos;
        pictureBoxBall.Left = (int)ball.XPos;
        pictureBoxBall.Image = ball.Img;
        pictureBoxBall.Image = ball.Img2;
        pictureBoxBall.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBoxBall.Parent = this;

        pictureBoxBalls.Add(pictureBoxBall);

        timer.Start();              //タイマースタート

        this.Text = "ボールシミュレーション: " + Ball.Count;
    }

    //指定した時間が経過すると呼ばれるメソッド
    private void Timer_Tick(object sender, System.EventArgs e)
    {
        //ball.Move();
        for (int i = 0; i < balls.Count; i++)
        {
            balls[i].Move();

            pictureBoxBalls[i].Top = (int)balls[i].YPos;
            pictureBoxBalls[i].Left = (int)balls[i].XPos;
        }
    }
}