namespace Query_2
{
    partial class SelectByLocation
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
            this.TargetLayer = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VisiableOnly = new System.Windows.Forms.CheckBox();
            this.SourceLayerSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MethodSelect = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TargetLayer
            // 
            this.TargetLayer.FormattingEnabled = true;
            this.TargetLayer.Location = new System.Drawing.Point(9, 45);
            this.TargetLayer.Name = "TargetLayer";
            this.TargetLayer.Size = new System.Drawing.Size(349, 180);
            this.TargetLayer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "目标图层：";
            // 
            // VisiableOnly
            // 
            this.VisiableOnly.AutoSize = true;
            this.VisiableOnly.Location = new System.Drawing.Point(9, 231);
            this.VisiableOnly.Name = "VisiableOnly";
            this.VisiableOnly.Size = new System.Drawing.Size(108, 16);
            this.VisiableOnly.TabIndex = 2;
            this.VisiableOnly.Text = "只列出可选图层";
            this.VisiableOnly.UseVisualStyleBackColor = true;
            this.VisiableOnly.CheckedChanged += new System.EventHandler(this.VisiableOnly_CheckedChanged);
            // 
            // SourceLayerSelect
            // 
            this.SourceLayerSelect.FormattingEnabled = true;
            this.SourceLayerSelect.Location = new System.Drawing.Point(8, 281);
            this.SourceLayerSelect.Name = "SourceLayerSelect";
            this.SourceLayerSelect.Size = new System.Drawing.Size(349, 20);
            this.SourceLayerSelect.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "源图层：";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 307);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 16);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "使用被选择的要素";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "（当前有0个要素被选择）";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 335);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "空间选择方法：";
            // 
            // MethodSelect
            // 
            this.MethodSelect.FormattingEnabled = true;
            this.MethodSelect.Items.AddRange(new object[] {
            "空间相交",
            "空间连接-共享空间边界",
            "空间覆盖",
            "空间跨越",
            "空间被包含",
            "空间包含"});
            this.MethodSelect.Location = new System.Drawing.Point(8, 350);
            this.MethodSelect.Name = "MethodSelect";
            this.MethodSelect.Size = new System.Drawing.Size(349, 20);
            this.MethodSelect.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(192, 395);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "应用";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(282, 395);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "关闭";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(282, 231);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "清除选择";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // SelectByLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 455);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MethodSelect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SourceLayerSelect);
            this.Controls.Add(this.VisiableOnly);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TargetLayer);
            this.Name = "SelectByLocation";
            this.Text = "根据空间位置选择";
            this.Load += new System.EventHandler(this.SelectByLocation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox TargetLayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox VisiableOnly;
        private System.Windows.Forms.ComboBox SourceLayerSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox MethodSelect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}