using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
            if (tbName.Text == "")
            {
                MessageBox.Show("車名を入力してください");
                return;
            }
            //Carオブジェクトの作成
            Car obj = new Car
            {
                Name = tbName.Text,
                Maker = cbMaker.Text,
                Category = tbCategory.Text,
                carPic = pbImage.Image
            };
            //メーカーをコンボボックスの入力候補に登録
            setComboBoxMaker(cbMaker.Text);

            //BindingListへ登録
            //_Cars.Add(obj);
            _Cars.Insert(0, obj); //リストの先頭（インデックス０）へ追加

            //高さを自動調整
            dgvCarData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //次の入力に備えて各項目をクリア
            inputItemAllClear();
            initButtons();
            dgvCarData.ClearSelection();    //選択行をクリア
            //dgvCarData_Click(sender, e);  //イベントハンドラを呼び出す

        }

        //入力項目を全クリア
        private void inputItemAllClear()
        {
            tbName.Text = "";
            cbMaker.Text = "";
            tbCategory.Text = "";
            pbImage.Image = null;
        }

        //メーカーコンボボックスの入力候補登録
        private void setComboBoxMaker(string maker)
        {
            if (!cbMaker.Items.Contains(maker))
            {
                //コンボボックスの候補に追加
                cbMaker.Items.Add(maker);
            }
        }

        private void btOpenImage_Click(object sender, EventArgs e)
        {
            if (ofdOpenImage.ShowDialog() == DialogResult.OK)
            {
                //選択した画像をピクチャーボックスに表示
                pbImage.Image = Image.FromFile(ofdOpenImage.FileName);
                //ピクチャーボックスのサイズに画像を調整
                pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btClearImage_Click(object sender, EventArgs e)
        {
            pbImage.Image = null;
        }

        private void dgvCarData_Click(object sender, EventArgs e)
        {
            if (dgvCarData.CurrentRow == null)
                return;

            //選択したレコードを取り出す
            //データグリッドビューで選択した行のインデックスを元に
            //BindingListのデータを取得する
            Car selectedCar = _Cars[dgvCarData.CurrentRow.Index];
            tbName.Text = selectedCar.Name;
            cbMaker.Text = selectedCar.Maker;
            tbCategory.Text = selectedCar.Category;
            pbImage.Image = selectedCar.carPic;

        }

        private void btModify_Click(object sender, EventArgs e)
        {
            //変更対象のレコード（オブジェクト）
            Car selectedCar = _Cars[dgvCarData.CurrentRow.Index];
            selectedCar.Name = tbName.Text;
            selectedCar.Maker = cbMaker.Text;
            selectedCar.Category = tbCategory.Text;
            selectedCar.carPic = pbImage.Image;

            dgvCarData.Refresh();       //データグリッドビューの再描画
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initButtons();
        }

        private void initButtons()
        {
            if (_Cars.Count > 0)
            {
                btModify.Enabled = true;
                btDelete.Enabled = true;
            }
            else
            {
                btModify.Enabled = false;
                btDelete.Enabled = false;
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            _Cars.RemoveAt(dgvCarData.CurrentRow.Index);
            initButtons();
            inputItemAllClear();
            dgvCarData.ClearSelection();
        }

        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 新規入力ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputItemAllClear();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (sfdSaveData.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(sfdSaveData.FileName, FileMode.Create))
                {
                    try
                    {
                        //シリアル化して保存
                        formatter.Serialize(fs, _Cars);
                    }
                    catch (SerializationException se)
                    {
                        Console.WriteLine("Failed to serialize. Reason: " + se.Message);
                        throw;
                    }
                }
            }
        }

        private void btRead_Click(object sender, EventArgs e)
        {
            //オープンファイルダイアログを表示
            if (ofdOpenData.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(ofdOpenData.FileName, FileMode.Open))
                {
                    try
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        //逆シリアル化して読み込む
                        _Cars = (BindingList<Car>)formatter.Deserialize(fs);
                        //データグリッドビューに再設定
                        dgvCarData.DataSource = _Cars;
                        //選択されている箇所を各コントロールへ表示
                        dgvCarData_Click(sender, e);
                    }
                    catch (SerializationException se)
                    {
                        Console.WriteLine("Failed to deserialize. Reason: " + se.Message);
                        throw;
                    }
                }
            }
        }
    }
}
