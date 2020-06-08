using System;
using System.Drawing;
using System.Windows.Forms;

class CodeFile
{
    static Form form;
    static Label labelRed;
    static Label labelBlue;
    static Label labelYellow;
    static Button button;
    
    public static void Main()
    {
        form = new Form();

        form.Text = "hahahaha";
        form.Width = 800;
        form.Height = 600;
        form.BackColor = Color.White;

        labelRed = new Label();

        labelRed.Text = "";
        labelRed.Parent = form;
        labelRed.Width = 100;
        labelRed.Height = 100;
        labelRed.Top = 300;
        labelRed.Left = 300;
        //labelRed.BackColor = Color.White;
        labelRed.BackColor = Color.Transparent;
        labelRed.BorderStyle = BorderStyle.FixedSingle;


        labelBlue = new Label();

        labelBlue.Text = "";
        labelBlue.Parent = form;
        labelBlue.Width = 100;
        labelBlue.Height = 100;
        labelBlue.Top = 300;
        labelBlue.Left = 100;
        //labelBlue.BackColor = Color.Black;
        labelBlue.BackColor = Color.Transparent;
        labelBlue.BorderStyle = BorderStyle.FixedSingle;
        


        labelYellow = new Label();

        labelYellow.Text = "";
        labelYellow.Parent = form;
        labelYellow.Width = 100;
        labelYellow.Height = 100;
        labelYellow.Top = 300;
        labelYellow.Left = 200;
        labelYellow.BackColor = Color.Transparent;
        labelYellow.BorderStyle = BorderStyle.FixedSingle;


        button = new Button();

        button.Text = "色チェンジ";
        button.Top = 30;
        button.Left = 50;
        button.Width = 100;
        button.Height = 50;
        button.Click += Button_Click;
        button.Parent = form;

        Application.Run(form);
    }

    //static int a = 0;

    enum COLOR_ID
    {
        COLOR_ID_RED,
        COLOR_ID_YELLOW,
        COLOR_ID_BLUE,
    }
    static COLOR_ID color_id = COLOR_ID.COLOR_ID_BLUE;
    
    
    private static void Button_Click(object sender, EventArgs e)
    {
        labelYellow.BackColor = Color.Transparent;
        labelBlue.BackColor = Color.Transparent;
        labelRed.BackColor = Color.Transparent;

        //if(labelRed.BackColor == Color.Red)
        //{
        //    labelRed.BackColor = Color.Red;
        //    labelBlue.BackColor = Color.Black;
        //    labelYellow.BackColor = Color.Black;
        //}
        //else if(labelYellow.BackColor == Color.Black)
        //{
        //    labelRed.BackColor = Color.Black;
        //    labelYellow.BackColor = Color.Yellow;
        //    labelBlue.BackColor = Color.Black;
        //}
        //else
        //{
        //    labelRed.BackColor = Color.Red;
        //}



        switch (color_id)
        {
            case COLOR_ID.COLOR_ID_BLUE:
                {
                    labelBlue.BackColor = Color.Blue;
                    //labelYellow.BackColor = Color.Black;
                    //labelRed.BackColor = Color.Black;
                    //a++;
                    color_id = COLOR_ID.COLOR_ID_YELLOW;
                    break;
                }
            case COLOR_ID.COLOR_ID_YELLOW:
                {
                    //labelBlue.BackColor = Color.Black;
                    labelYellow.BackColor = Color.Yellow;
                    //labelRed.BackColor = Color.Black;
                    //a++;
                    color_id = COLOR_ID.COLOR_ID_RED;
                    break;
                }
            case COLOR_ID.COLOR_ID_RED:
                {
                    //labelBlue.BackColor = Color.Black;
                    //labelYellow.BackColor = Color.Black;
                    labelRed.BackColor = Color.Red;
                    color_id = COLOR_ID.COLOR_ID_BLUE;
                    break;
                }

        }
    }
}