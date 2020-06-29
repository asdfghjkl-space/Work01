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
            //特定の場所に表示(引数１つ目のところにぶち込む)
            _Cars.Insert(0,obj);

            //次の入力に備えて各項目をクリア
            inputItemAllClear();
        }

        //入力項目を全クリア
        private void inputItemAllClear()
        {
            tbName.Text = "";
            tbMaker.Text = "";
            tbCategory.Text = "";
            pbImage.Image = null;
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

        private void btClearImage_Click(object sender, EventArgs e)
        {
            //ボタンを押したら、画像をクリア
            pbImage.Image = null;
        }

        private void dgvCarData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCarData_Click(object sender, EventArgs e)
        {
            //選択したコードを取り出す
            //データグリッドビューで選択した行のインデックス
            //BindingListのデータを取得する
            Car selectedCar = _Cars[dgvCarData.CurrentRow.Index];

            //選択したデータの表示
            tbName.Text = selectedCar.Name;
            tbMaker.Text = selectedCar.Maker;
            tbCategory.Text = selectedCar.Category;
        }

        private void btModify_Click(object sender, EventArgs e)
        {
            Car selectedCar = _Cars[dgvCarData.CurrentRow.Index];

            //選択したデータの変更
            selectedCar.Name = tbName.Text;
            selectedCar.Maker = tbMaker.Text;
            selectedCar.Category = tbCategory.Text;
            selectedCar.carPic = pbImage.Image;

            dgvCarData.Refresh();
        }
    }
}
