using System.Reflection;
using System.Windows.Forms;
using System.Drawing;

class FormApp
{
    static Form form;
    static Button buttonAppName;
    public static void Main()
    {
        Timer timer = new Timer();  //タイマー

        timer.Tick += Timer_Tick;
        timer.Interval = 5;
        timer.Start();

        form = new Form();  //フォームの生成

        form.Text = "フォームアプリケーション";
        form.Width = 800;  //幅
        form.Height = 600;  //高さ
        form.BackColor = Color.Red;

        //ラベル
        Label labelAppName = new Label();  //ラベル生成
        labelAppName.Text = "サンプルアプリ";
        labelAppName.Parent = form;  //ラベルの親を設定

        //ボタン
        buttonAppName = new Button();  //ボタンを生成
        buttonAppName.Text = "ボタン";
        buttonAppName.Top = 30; //上から30（ｙ座標）
        buttonAppName.Left = 50; //左から50（ｘ座標）
        buttonAppName.Width = 50;
        buttonAppName.Height = 50;
        buttonAppName.Click += ButtonAppName_Click;
        buttonAppName.Parent = form;  //ラベルの親を設定


        Application.Run(form);  //フォームを指定して実行
    }

    private static void Timer_Tick(object sender, System.EventArgs e)
    {
        #region//switch文で色の切り替え
        switch (a)
        {
            case 0:
                {
                    form.BackColor = Color.White;
                    a++;
                    break;
                }

            case 1:
                {
                    form.BackColor = Color.Black;
                    a--;
                    break;
                }
        }
        #endregion

    }

    static int a = 0;
    private static void ButtonAppName_Click(object sender, System.EventArgs e)
    {
        //form.BackColor = Color.White;

        //if文で色の切り替え
        //if(form.BackColor == Color.Red)
        //{
        //    form.BackColor = Color.Blue;
        //}
        //else
        //{
        //    form.BackColor = Color.Yellow;
        //}

        #region//switch文で色の切り替え
        switch (a)
        {
            case 0:
                {
                    form.BackColor = Color.White;
                    a++;
                    break;
                }

            case 1:
                {
                    form.BackColor = Color.Black;
                    a--;
                    break;
                }
        }
        #endregion

        #region//ボタンの色切り替え
        Button bt = (Button)sender;
        if(bt.BackColor == Color.Gray)
        {
            bt.BackColor = Color.Black;
        }
        else
        {
            bt.BackColor = Color.Gray;
        }
        #endregion

        //MessageBox.Show("ボタンが押されたよ");
    }
}