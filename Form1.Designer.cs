namespace TaskRecorderParser
{
    partial class Form1
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
            this.tb_input = new System.Windows.Forms.TextBox();
            this.btn_browse = new System.Windows.Forms.Button();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btn_parse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lv_output = new System.Windows.Forms.ListView();
            this.menuItemLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuItemType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_label = new System.Windows.Forms.RadioButton();
            this.rb_name = new System.Windows.Forms.RadioButton();
            this.rb_type = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input File :";
            // 
            // tb_input
            // 
            this.tb_input.Location = new System.Drawing.Point(87, 13);
            this.tb_input.Name = "tb_input";
            this.tb_input.Size = new System.Drawing.Size(458, 22);
            this.tb_input.TabIndex = 1;
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(87, 41);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(75, 23);
            this.btn_browse.TabIndex = 2;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "openFileDialog1";
            // 
            // btn_parse
            // 
            this.btn_parse.Location = new System.Drawing.Point(16, 70);
            this.btn_parse.Name = "btn_parse";
            this.btn_parse.Size = new System.Drawing.Size(75, 23);
            this.btn_parse.TabIndex = 3;
            this.btn_parse.Text = "Parse";
            this.btn_parse.UseVisualStyleBackColor = true;
            this.btn_parse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Menu Items";
            // 
            // lv_output
            // 
            this.lv_output.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.menuItemLabel,
            this.menuItemName,
            this.menuItemType});
            this.lv_output.FullRowSelect = true;
            this.lv_output.GridLines = true;
            this.lv_output.Location = new System.Drawing.Point(19, 120);
            this.lv_output.Name = "lv_output";
            this.lv_output.Size = new System.Drawing.Size(526, 233);
            this.lv_output.TabIndex = 6;
            this.lv_output.UseCompatibleStateImageBehavior = false;
            this.lv_output.View = System.Windows.Forms.View.Details;
            // 
            // menuItemLabel
            // 
            this.menuItemLabel.Text = "Menu Item Label";
            this.menuItemLabel.Width = 117;
            // 
            // menuItemName
            // 
            this.menuItemName.Text = "Menu Item Name";
            this.menuItemName.Width = 125;
            // 
            // menuItemType
            // 
            this.menuItemType.Text = "Menu Item Type";
            this.menuItemType.Width = 121;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_type);
            this.groupBox1.Controls.Add(this.rb_name);
            this.groupBox1.Controls.Add(this.rb_label);
            this.groupBox1.Location = new System.Drawing.Point(218, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 44);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sort By";
            // 
            // rb_label
            // 
            this.rb_label.AutoSize = true;
            this.rb_label.Checked = true;
            this.rb_label.Location = new System.Drawing.Point(7, 22);
            this.rb_label.Name = "rb_label";
            this.rb_label.Size = new System.Drawing.Size(60, 20);
            this.rb_label.TabIndex = 0;
            this.rb_label.TabStop = true;
            this.rb_label.Text = "Label";
            this.rb_label.UseVisualStyleBackColor = true;
            this.rb_label.CheckedChanged += new System.EventHandler(this.rbLabel_CheckedChanged);
            // 
            // rb_name
            // 
            this.rb_name.AutoSize = true;
            this.rb_name.Location = new System.Drawing.Point(115, 21);
            this.rb_name.Name = "rb_name";
            this.rb_name.Size = new System.Drawing.Size(63, 20);
            this.rb_name.TabIndex = 1;
            this.rb_name.Text = "Name";
            this.rb_name.UseVisualStyleBackColor = true;
            this.rb_name.CheckedChanged += new System.EventHandler(this.rbName_CheckedChanged);
            // 
            // rb_type
            // 
            this.rb_type.AutoSize = true;
            this.rb_type.Location = new System.Drawing.Point(223, 22);
            this.rb_type.Name = "rb_type";
            this.rb_type.Size = new System.Drawing.Size(58, 20);
            this.rb_type.TabIndex = 2;
            this.rb_type.Text = "Type";
            this.rb_type.UseVisualStyleBackColor = true;
            this.rb_type.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 365);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lv_output);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_parse);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.tb_input);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Task Recorder Parser";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_input;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Button btn_parse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lv_output;
        private System.Windows.Forms.ColumnHeader menuItemLabel;
        private System.Windows.Forms.ColumnHeader menuItemName;
        private System.Windows.Forms.ColumnHeader menuItemType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_type;
        private System.Windows.Forms.RadioButton rb_name;
        private System.Windows.Forms.RadioButton rb_label;
    }
}

