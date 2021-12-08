namespace VisualInspectionApp
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabelDir = new System.Windows.Forms.LinkLabel();
            this.imageListGood = new System.Windows.Forms.ImageList(this.components);
            this.imageListBad = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxGood = new System.Windows.Forms.GroupBox();
            this.listViewGood = new System.Windows.Forms.ListView();
            this.groupBoxBad = new System.Windows.Forms.GroupBox();
            this.listViewBad = new System.Windows.Forms.ListView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxSummary = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelLotNo = new System.Windows.Forms.Label();
            this.labelGoodCount = new System.Windows.Forms.Label();
            this.labelBadCount = new System.Windows.Forms.Label();
            this.labelTotalCount = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxGood.SuspendLayout();
            this.groupBoxBad.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxSummary.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("BIZ UDPゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(980, 717);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "検査結果出力先:";
            // 
            // linkLabelDir
            // 
            this.linkLabelDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelDir.AutoSize = true;
            this.linkLabelDir.Location = new System.Drawing.Point(1126, 710);
            this.linkLabelDir.Name = "linkLabelDir";
            this.linkLabelDir.Size = new System.Drawing.Size(34, 25);
            this.linkLabelDir.TabIndex = 4;
            this.linkLabelDir.TabStop = true;
            this.linkLabelDir.Text = "c:\\";
            // 
            // imageListGood
            // 
            this.imageListGood.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListGood.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListGood.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageListBad
            // 
            this.imageListBad.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListBad.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListBad.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxGood, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxBad, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 172);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1148, 535);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // groupBoxGood
            // 
            this.groupBoxGood.Controls.Add(this.listViewGood);
            this.groupBoxGood.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxGood.Font = new System.Drawing.Font("BIZ UDPゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxGood.Location = new System.Drawing.Point(6, 6);
            this.groupBoxGood.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxGood.Name = "groupBoxGood";
            this.groupBoxGood.Size = new System.Drawing.Size(562, 523);
            this.groupBoxGood.TabIndex = 0;
            this.groupBoxGood.TabStop = false;
            this.groupBoxGood.Text = "良品画像";
            // 
            // listViewGood
            // 
            this.listViewGood.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewGood.Location = new System.Drawing.Point(3, 23);
            this.listViewGood.Name = "listViewGood";
            this.listViewGood.Size = new System.Drawing.Size(556, 497);
            this.listViewGood.TabIndex = 0;
            this.listViewGood.UseCompatibleStateImageBehavior = false;
            // 
            // groupBoxBad
            // 
            this.groupBoxBad.Controls.Add(this.listViewBad);
            this.groupBoxBad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxBad.Font = new System.Drawing.Font("BIZ UDPゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxBad.Location = new System.Drawing.Point(580, 6);
            this.groupBoxBad.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxBad.Name = "groupBoxBad";
            this.groupBoxBad.Size = new System.Drawing.Size(562, 523);
            this.groupBoxBad.TabIndex = 1;
            this.groupBoxBad.TabStop = false;
            this.groupBoxBad.Text = "不良品画像";
            // 
            // listViewBad
            // 
            this.listViewBad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewBad.Location = new System.Drawing.Point(3, 23);
            this.listViewBad.Name = "listViewBad";
            this.listViewBad.Size = new System.Drawing.Size(556, 497);
            this.listViewBad.TabIndex = 0;
            this.listViewBad.UseCompatibleStateImageBehavior = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBoxSummary, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(18, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1148, 150);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // groupBoxSummary
            // 
            this.groupBoxSummary.Controls.Add(this.tableLayoutPanel3);
            this.groupBoxSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSummary.Font = new System.Drawing.Font("BIZ UDPゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxSummary.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSummary.Name = "groupBoxSummary";
            this.groupBoxSummary.Size = new System.Drawing.Size(1142, 144);
            this.groupBoxSummary.TabIndex = 0;
            this.groupBoxSummary.TabStop = false;
            this.groupBoxSummary.Text = "サマリー";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.Controls.Add(this.labelTotalCount, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.labelBadCount, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.labelGoodCount, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelLotNo, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1136, 118);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("BIZ UDPゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "ロットNo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("BIZ UDPゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "良品画像";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("BIZ UDPゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "不良品画像";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("BIZ UDPゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(3, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 31);
            this.label4.TabIndex = 1;
            this.label4.Text = "TOTAL";
            // 
            // labelLotNo
            // 
            this.labelLotNo.AutoSize = true;
            this.labelLotNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLotNo.Font = new System.Drawing.Font("BIZ UDPゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLotNo.Location = new System.Drawing.Point(230, 0);
            this.labelLotNo.Name = "labelLotNo";
            this.labelLotNo.Size = new System.Drawing.Size(903, 29);
            this.labelLotNo.TabIndex = 2;
            this.labelLotNo.Text = "LotNo";
            // 
            // labelGoodCount
            // 
            this.labelGoodCount.AutoSize = true;
            this.labelGoodCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGoodCount.Font = new System.Drawing.Font("BIZ UDPゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGoodCount.Location = new System.Drawing.Point(230, 29);
            this.labelGoodCount.Name = "labelGoodCount";
            this.labelGoodCount.Size = new System.Drawing.Size(903, 29);
            this.labelGoodCount.TabIndex = 3;
            this.labelGoodCount.Text = "0";
            // 
            // labelBadCount
            // 
            this.labelBadCount.AutoSize = true;
            this.labelBadCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBadCount.Font = new System.Drawing.Font("BIZ UDPゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelBadCount.Location = new System.Drawing.Point(230, 58);
            this.labelBadCount.Name = "labelBadCount";
            this.labelBadCount.Size = new System.Drawing.Size(903, 29);
            this.labelBadCount.TabIndex = 4;
            this.labelBadCount.Text = "0";
            // 
            // labelTotalCount
            // 
            this.labelTotalCount.AutoSize = true;
            this.labelTotalCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTotalCount.Font = new System.Drawing.Font("BIZ UDPゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTotalCount.Location = new System.Drawing.Point(230, 87);
            this.labelTotalCount.Name = "labelTotalCount";
            this.labelTotalCount.Size = new System.Drawing.Size(903, 31);
            this.labelTotalCount.TabIndex = 5;
            this.labelTotalCount.Text = "0";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.linkLabelDir);
            this.Controls.Add(this.label5);
            this.Name = "Form2";
            this.Text = "外観検査";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBoxGood.ResumeLayout(false);
            this.groupBoxBad.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBoxSummary.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label5;
        private LinkLabel linkLabelDir;
        private ImageList imageListGood;
        private ImageList imageListBad;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBoxGood;
        private ListView listViewGood;
        private GroupBox groupBoxBad;
        private ListView listViewBad;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBoxSummary;
        private TableLayoutPanel tableLayoutPanel3;
        private Label labelTotalCount;
        private Label labelBadCount;
        private Label labelGoodCount;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label2;
        private Label labelLotNo;
    }
}