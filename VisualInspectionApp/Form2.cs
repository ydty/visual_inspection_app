using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualInspectionApp
{
    public partial class Form2 : Form
    {
        private readonly string _lotNo;
        private readonly string _outputDir;
        private readonly string _goodDir;
        private readonly string _badDir;

        public Form2(string lotNo, string outputDir,string goodDir, string badDir)
        {
            InitializeComponent();

            _lotNo = lotNo;
            _outputDir = outputDir;
            _goodDir = goodDir;
            _badDir = badDir;

            //イメージ表示のための初期処理
            ImageListInit();

            //画像の表示
            DispImage();
  
        }

        private async void DispImage()
        {
            //良品画像表示
            var goodImageCount = await this.GoodImageView();

            //不良品画像表示
            var badImageCount = await this.BadImageView();

            //画像数の表示
            labelGoodCount.Text = goodImageCount.ToString();
            labelBadCount.Text = badImageCount.ToString();
            labelTotalCount.Text = (goodImageCount + badImageCount).ToString();

        }

        private void ImageListInit()
        {
            labelLotNo.Text = _lotNo;
            linkLabelDir.Text = _outputDir;

            listViewGood.Columns.Add("GoodImage");
            listViewBad.Columns.Add("BadImage");

            var imageSize = new Size(256, 256);

            imageListGood = new ImageList{ImageSize = imageSize};
            imageListBad = new ImageList { ImageSize = imageSize };

            listViewGood.LargeImageList = imageListGood;
            listViewBad.LargeImageList = imageListBad;
        }

        private async Task<int> GoodImageView()
        {
            string path = Path.GetFullPath(_goodDir);

            // リストビューをクリア
            listViewGood.Items.Clear();
            imageListGood.Images.Clear();

            Image[] b = { };
            ListViewItem[] a = { };

            Task<int> task = Task.Run(() =>
            {

                var dirInfo = new DirectoryInfo(path);
                var i = 0;

                var d = dirInfo.EnumerateFiles("*.jpg");
                b = d.Select(x => Bitmap.FromFile(x.FullName))
                    .ToArray();
                a = d.Select(x => new ListViewItem(x.Name, i++))
                    .ToArray();

                return i;
            });

            var result = await task;

            if (result > 0)
            {
                imageListGood.Images.AddRange(b);
                listViewGood.Items.AddRange(a);
            }

            return listViewGood.Items.Count;

        }

        /// <summary>
        /// 不良画像の表示
        /// </summary>
        /// <returns></returns>
        private async Task<int> BadImageView()
        {
            string path = Path.GetFullPath(_badDir);

            // リストビューをクリア
            listViewBad.Items.Clear();
            imageListBad.Images.Clear();

            Image[] b = { };
            ListViewItem[] a = { };

            Task<int> task = Task.Run(() =>
            {

                var dirInfo = new DirectoryInfo(path);
                var i = 0;

                var d = dirInfo.EnumerateFiles("*.jpg");
                b = d.Select(x => Bitmap.FromFile(x.FullName))
                    .ToArray();
                a = d.Select(x => new ListViewItem(x.Name, i++))
                    .ToArray();

                return i;
            });

            var result = await task;

            if (result > 0)
            {
                imageListBad.Images.AddRange(b);
                listViewBad.Items.AddRange(a);
            }

            return listViewBad.Items.Count;
        }

        private void linkLabelDir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            System.Diagnostics.Process.Start("EXPLORER.EXE", linkLabelDir.Text);

        }
    }
}
