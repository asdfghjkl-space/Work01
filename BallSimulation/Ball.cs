
//ボールクラス
using System.Drawing;

class Ball
{
    public double XPos { get; set; }   //X座標
    public double YPos { get; set; }   //X座標
    public Image  Img  { get; set; }   //画像データ

    
    private double moveX;   //加速度(X)
    private double moveY;   //加速度(Y)

    //コンストラクタ
    public Ball()
    {
        XPos = 0;
        YPos = 0;
        Img = Image.FromFile(@"images\soccer_ball.png");

        moveX = 5;
        moveY = 5;
    }

    //引数付きコンストラクタ(座標指定)
    public Ball(double xp,double yp)
    {
        XPos = xp;
        YPos = yp;
        Img = Image.FromFile(@"images\soccer_ball.png");

        moveX = 5;
        moveY = 5;
    }

    public void Move()
    {
        XPos += moveX;
        YPos += moveY;
    }


}