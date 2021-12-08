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

        //��������
        private void Init()
        {
            //�J�E���g��0�ɂ���
            lblImageCountData.Text = "0";

            //appsetting.json����ݒ�̓ǂݏo��
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

            //��ʉ����̉摜�\�����ɉ摜������ݒ�
            lblImageCountData.Text = listBoxImageFile.Items.Count.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO: ���_����������

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