namespace Query_2
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.AttList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.UniqueList = new System.Windows.Forms.ListBox();
            this.get_Unique = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SQLText = new System.Windows.Forms.TextBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图层名称：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(106, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(263, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(106, 49);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "只显示可选图层";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "选择方式：";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "创建新选择集",
            "添加到当前选择集",
            "从当前选择集中删除",
            "从当前选择集中选择"});
            this.comboBox2.Location = new System.Drawing.Point(106, 76);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(263, 20);
            this.comboBox2.TabIndex = 4;
            // 
            // AttList
            // 
            this.AttList.FormattingEnabled = true;
            this.AttList.ItemHeight = 12;
            this.AttList.Location = new System.Drawing.Point(8, 131);
            this.AttList.Name = "AttList";
            this.AttList.Size = new System.Drawing.Size(120, 136);
            this.AttList.TabIndex = 5;
            this.AttList.SelectedIndexChanged += new System.EventHandler(this.AttList_SelectedIndexChanged);
            this.AttList.DoubleClick += new System.EventHandler(this.AttList_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(142, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "=";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(181, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "<>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(220, 131);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(44, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Like";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(220, 160);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(44, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "And";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(181, 160);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(33, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = ">=";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(142, 160);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(33, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = ">";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(220, 189);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(44, 23);
            this.button7.TabIndex = 14;
            this.button7.Text = "Or";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(181, 189);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(33, 23);
            this.button8.TabIndex = 13;
            this.button8.Text = "<=";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(142, 218);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(16, 23);
            this.button9.TabIndex = 12;
            this.button9.Text = "_";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(220, 218);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(44, 23);
            this.button10.TabIndex = 17;
            this.button10.Text = "Not";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(181, 218);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(33, 23);
            this.button11.TabIndex = 16;
            this.button11.Text = "()";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(142, 189);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(33, 23);
            this.button12.TabIndex = 15;
            this.button12.Text = "<";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(159, 218);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(16, 23);
            this.button13.TabIndex = 18;
            this.button13.Text = "%";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(142, 247);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(33, 23);
            this.button14.TabIndex = 19;
            this.button14.Text = "Is";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // UniqueList
            // 
            this.UniqueList.FormattingEnabled = true;
            this.UniqueList.ItemHeight = 12;
            this.UniqueList.Location = new System.Drawing.Point(283, 131);
            this.UniqueList.Name = "UniqueList";
            this.UniqueList.Size = new System.Drawing.Size(120, 136);
            this.UniqueList.TabIndex = 20;
            this.UniqueList.SelectedIndexChanged += new System.EventHandler(this.UniqueList_SelectedIndexChanged);
            this.UniqueList.DoubleClick += new System.EventHandler(this.UniqueList_DoubleClick);
            // 
            // get_Unique
            // 
            this.get_Unique.Location = new System.Drawing.Point(283, 273);
            this.get_Unique.Name = "get_Unique";
            this.get_Unique.Size = new System.Drawing.Size(75, 23);
            this.get_Unique.TabIndex = 21;
            this.get_Unique.Text = "获取唯一值";
            this.get_Unique.UseVisualStyleBackColor = true;
            this.get_Unique.Click += new System.EventHandler(this.get_Unique_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = ":";
            // 
            // SQLText
            // 
            this.SQLText.Location = new System.Drawing.Point(8, 319);
            this.SQLText.Multiline = true;
            this.SQLText.Name = "SQLText";
            this.SQLText.Size = new System.Drawing.Size(395, 58);
            this.SQLText.TabIndex = 23;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(8, 384);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 24;
            this.btn_Clear.Text = "清除";
            this.btn_Clear.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Clear);
            this.panel1.Controls.Add(this.SQLText);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.get_Unique);
            this.panel1.Controls.Add(this.UniqueList);
            this.panel1.Controls.Add(this.button14);
            this.panel1.Controls.Add(this.button13);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.button11);
            this.panel1.Controls.Add(this.button12);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.AttList);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 417);
            this.panel1.TabIndex = 25;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(154, 445);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 25;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Apply
            // 
            this.btn_Apply.Location = new System.Drawing.Point(254, 445);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(75, 23);
            this.btn_Apply.TabIndex = 26;
            this.btn_Apply.Text = "应用";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(351, 445);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 27;
            this.btn_Close.Text = "关闭";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 480);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Apply);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "根据属性信息查询";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ListBox AttList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.ListBox UniqueList;
        private System.Windows.Forms.Button get_Unique;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SQLText;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.Button btn_Close;
    }
}