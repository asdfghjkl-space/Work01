
using System.Windows.Forms;

class CodeFile1
{
    static Form form;

    static void Main()
    {
        form = new Form();
        form.Width = 800;
        form.Height = 600;

        Application.Run(form);

    }
}