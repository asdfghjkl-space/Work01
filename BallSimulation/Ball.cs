
//ボールクラス
using System;
using System.Drawing;

class Ball
{
    public double XPos { get; set; }   //X座標
    public double YPos { get; set; }   //X座標
    public Image  Img  { get; set; }   //画像データ
    public Image  Img2 { get; set; }

    
    private double moveX;   //加速度(X)
    private double moveY;   //加速度(Y)

    Random rnd = new System.Random();

    //コンストラクタ
    public Ball()
    {
        XPos = 0;
        YPos = 0;
        Img  = Image.FromFile(@"images\soccer_ball.png");
        Img2 = Image.FromFile(@"images\tennis_ball.png");

        moveX = 5;
        moveY = 5;
    }

    //引数付きコンストラクタ(座標指定)
    public Ball(double xp,double yp,string path)
    {
        XPos = xp;
        YPos = yp;
        Img  = Image.FromFile(path);
        Img2 = Image.FromFile(path);
        moveX = rnd.Next(0, 20) - 10;
        moveY = rnd.Next(0, 20) - 10;
    }

    public void Move()
    {
        XPos += moveX;
        YPos += moveY;
    }
}