
//ボールクラス
using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

class Ball
{
    //静的プロパティ
    public static int Count;   //オブジェクトの個数をカウント

    public double XPos { get; set; }   //X座標
    public double YPos { get; set; }   //X座標
    public Image  Img  { get; set; }   //画像データ
    public Image  Img2 { get; set; }

    
    private double moveX;   //加速度(X)
    private double moveY;   //加速度(Y)

    //乱数
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

        Count++;

        Console.WriteLine("●X座標 {0} , Y座標{1}", (int)moveX, (int)moveY);
    }

    const int Ball_Size = 100;//ボールのサイズ
    public void Move()
    {
        XPos += moveX;
        YPos += moveY;

        //壁
        if((YPos > 800 - 100) || YPos < 0)
        {
            moveY = -moveY;
        }

        if ((XPos > 1200 - 70) || XPos < 0)
        {
            moveX = -moveX;
        }

        Console.WriteLine("X座標: {0} , Y座標: {1}", (int)XPos, (int)YPos);

        #region//壁
        //if (XPos > 1200 - Ball_Size)
        //{
        //    moveX *= -1;
        //}

        //if (XPos < 0)
        //{
        //    moveX *= -1;
        //}

        //if (YPos > 800 - Ball_Size)
        //{
        //    moveY *= -1;
        //}

        //if (YPos < 0)
        //{
        //    moveY *= -1;
        //}
        #endregion
    }

}