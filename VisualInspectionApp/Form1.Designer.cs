namespace VisualInspectionApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLotNo = new System.Windows.Forms.Label();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.lblImageFile = new System.Windows.Forms.Label();
            this.listBoxImageFile = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblCountImageTitle = new System.Windows.Forms.Label();
            this.lblImageCountData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLotNo
            // 
            this.lblLotNo.AutoSize = true;
            this.lblLotNo.Font = new System.Drawing.Font("BIZ UDPゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLotNo.Location = new System.Drawing.Point(12, 9);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(239, 18);
            this.lblLotNo.TabIndex = 0;
            this.lblLotNo.Text = "ロットNOを入力してください";
            // 
            // txtLotNo
            // 
            this.txtLotNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLotNo.Location = new System.Drawing.Point(12, 30);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(770, 31);
            this.txtLotNo.TabIndex = 1;
            // 
            // lblImageFile
            // 
            this.lblImageFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImageFile.AutoSize = true;
            this.lblImageFile.Font = new System.Drawing.Font("BIZ UDPゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblImageFile.Location = new System.Drawing.Point(12, 90);
            this.lblImageFile.Name = "lblImageFile";
            this.lblImageFile.Size = new System.Drawing.Size(409, 18);
            this.lblImageFile.TabIndex = 2;
            this.lblImageFile.Text = "検査画像ファイルをドラック＆ドロップしてください";
            // 
            // listBoxImageFile
            // 
            this.listBoxImageFile.AllowDrop = true;
            this.listBoxImageFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxImageFile.FormattingEnabled = true;
            this.listBoxImageFile.ItemHeight = 25;
            this.listBoxImageFile.Location = new System.Drawing.Point(12, 111);
            this.listBoxImageFile.Name = "listBoxImageFile";
            this.listBoxImageFile.Size = new System.Drawing.Size(770, 254);
            this.listBoxImageFile.TabIndex = 3;
            this.listBoxImageFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxImageFile_DragDrop);
            this.listBoxImageFile.DragOver += new System.Windows.Forms.DragEventHandler(this.listBoxImageFile_DragOver);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Font = new System.Drawing.Font("BIZ UDPゴシック", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStart.Location = new System.Drawing.Point(636, 381);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(146, 57);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "検査開始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblCountImageTitle
            // 
            this.lblCountImageTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountImageTitle.AutoSize = true;
            this.lblCountImageTitle.Font = new System.Drawing.Font("BIZ UDPゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCountImageTitle.Location = new System.Drawing.Point(12, 399);
            this.lblCountImageTitle.Name = "lblCountImageTitle";
            this.lblCountImageTitle.Size = new System.Drawing.Size(118, 24);
            this.lblCountImageTitle.TabIndex = 5;
            this.lblCountImageTitle.Text = "画像枚数：";
            // 
            // lblImageCountData
            // 
            this.lblImageCountData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImageCountData.AutoSize = true;
            this.lblImageCountData.Font = new System.Drawing.Font("BIZ UDPゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblImageCountData.Location = new System.Drawing.Point(136, 399);
            this.lblImageCountData.Name = "lblImageCountData";
            this.lblImageCountData.Size = new System.Drawing.Size(28, 24);
            this.lblImageCountData.TabIndex = 6;
            this.lblImageCountData.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblImageCountData);
            this.Controls.Add(this.lblCountImageTitle);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.listBoxImageFile);
            this.Controls.Add(this.lblImageFile);
            this.Controls.Add(this.txtLotNo);
            this.Controls.Add(this.lblLotNo);
            this.Name = "Form1";
            this.Text = "外観検査アプリ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblLotNo;
        private TextBox txtLotNo;
        private Label lblImageFile;
        private ListBox listBoxImageFile;
        private Button btnStart;
        private Label lblCountImageTitle;
        private Label lblImageCountData;
    }
}