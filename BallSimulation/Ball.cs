
//ボールクラス
using System.Drawing;

class Ball
{
    public double XPos { get; set; }   //X座標
    public double YPos { get; set; }   //X座標
    public Image  Img  { get; set; }   //画像データ

    //コンストラクタ
    public Ball()
    {
        XPos = 0;
        YPos = 0;
        Img = Image.FromFile(@"images\soccer_ball.png");
    }
}