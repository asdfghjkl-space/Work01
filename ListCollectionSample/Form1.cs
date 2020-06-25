using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListCollectionSample
{
    public partial class Form1 : Form
    {
        //車データを入れるバインディングリスト
        BindingList<Car> _Cars = new BindingList<Car>();

        public Form1()
        {
            InitializeComponent();
            dgvCarData.DataSource = _Cars;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Car obj = new Car
            {
                Name = tbName.Text,
                Maker = tbMaker.Text,
                Category = tbCategory.Text,
                carPic =  pbImage.Image
            };

            //BindingListへ登録
            _Cars.Add(obj);

            tbName.ResetText();
            tbMaker.ResetText();
            tbCategory.ResetText();
        }

        private void btOpenImage_Click(object sender, EventArgs e)
        {
           if(ofdOpenImage.ShowDialog() == DialogResult.OK)
            {
                //選択した画像をピクチャーボックスに表示
                pbImage.Image = Image.FromFile(ofdOpenImage.FileName);

                //ピクチャーボックスのサイズに画像を調整
                pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
