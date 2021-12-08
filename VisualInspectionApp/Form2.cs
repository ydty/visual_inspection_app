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

        public Form2()
        {
            InitializeComponent();

            //イメージ表示のための初期処理
            ImageListInit();

            //良品画像表示
            GoodImageView();

            //不良品画像表示
            BadImageView();
            

        }

        private void ImageListInit()
        {
            listViewGood.Columns.Add("GoodImage");
            listViewBad.Columns.Add("BadImage");

            var imageSize = new Size(256, 256);

            imageListGood = new ImageList{ImageSize = imageSize};
            imageListBad = new ImageList { ImageSize = imageSize };

            listViewGood.LargeImageList = imageListGood;
            listViewBad.LargeImageList = imageListBad;
        }

        async void GoodImageView()
        {

            try
            {
                string path = Path.GetFullPath("..\\..\\..\\..\\Image\\annotated");

                // リストビューをクリア
                listViewGood.Items.Clear();
                imageListGood.Images.Clear();

                Image[] b = { };
                ListViewItem[] a = { };

                Task<int> task = Task.Run(() => {

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        async void BadImageView()
        {
            try
            {
                string path = Path.GetFullPath("..\\..\\..\\..\\Image\\non_clack"); 

                // リストビューをクリア
                listViewBad.Items.Clear();
                imageListBad.Images.Clear();

                Image[] b = { };
                ListViewItem[] a = { };

                Task<int> task = Task.Run(() => {

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
