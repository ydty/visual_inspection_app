using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace VisualInspectionApp
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            Init();
        }

        //初期処理
        private void Init()
        {
            //カウントを0にする
            lblImageCountData.Text = "0";

            //appsetting.jsonから設定の読み出し
            var cfb = new ConfigurationBuilder();
            cfb.SetBasePath(Directory.GetCurrentDirectory());
            cfb.AddJsonFile("appsettings.json", true, true);
            var configuration = cfb.Build();

            var section = configuration.GetSection("Settings");
            string _outputDirectory = section["OutputDirectoryPath"];
        }

        private void listBoxImageFile_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void listBoxImageFile_DragDrop(object sender, DragEventArgs e)
        {
            foreach (string item in (string[]) e.Data.GetData(DataFormats.FileDrop))
            {
                listBoxImageFile.Items.Add(item);
            }

            //画面下部の画像表示数に画像枚数を設定
            lblImageCountData.Text = listBoxImageFile.Items.Count.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO: 推論処理を書く

                var from2 = new Form2();
                from2.Show();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}