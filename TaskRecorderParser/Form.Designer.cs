namespace TaskRecorderParser
{
    partial class Form
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
            this.lv_output = new System.Windows.Forms.ListView();
            this.menuItemLabel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuItemType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.formName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_form = new System.Windows.Forms.RadioButton();
            this.rb_name = new System.Windows.Forms.RadioButton();
            this.rb_label = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_taskRecordingType = new System.Windows.Forms.TextBox();
            this.btn_exportCSV = new System.Windows.Forms.Button();
            this.btn_exportXLSX = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input File :";
            // 
            // tb_input
            // 
            this.tb_input.Location = new System.Drawing.Point(65, 11);
            this.tb_input.Margin = new System.Windows.Forms.Padding(2);
            this.tb_input.Name = "tb_input";
            this.tb_input.Size = new System.Drawing.Size(344, 20);
            this.tb_input.TabIndex = 1;
            // 
            // btn_browse
            // 
            this.btn_browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_browse.Location = new System.Drawing.Point(413, 11);
            this.btn_browse.Margin = new System.Windows.Forms.Padding(2);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(56, 28);
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
            this.btn_parse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_parse.Location = new System.Drawing.Point(413, 43);
            this.btn_parse.Margin = new System.Windows.Forms.Padding(2);
            this.btn_parse.Name = "btn_parse";
            this.btn_parse.Size = new System.Drawing.Size(56, 25);
            this.btn_parse.TabIndex = 3;
            this.btn_parse.Text = "Parse";
            this.btn_parse.UseVisualStyleBackColor = true;
            this.btn_parse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // lv_output
            // 
            this.lv_output.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.menuItemLabel,
            this.menuItemName,
            this.menuItemType,
            this.formName});
            this.lv_output.FullRowSelect = true;
            this.lv_output.GridLines = true;
            this.lv_output.Location = new System.Drawing.Point(14, 98);
            this.lv_output.Margin = new System.Windows.Forms.Padding(2);
            this.lv_output.Name = "lv_output";
            this.lv_output.Size = new System.Drawing.Size(455, 190);
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
            // formName
            // 
            this.formName.Text = "Form Name";
            this.formName.Width = 85;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_form);
            this.groupBox1.Controls.Add(this.rb_name);
            this.groupBox1.Controls.Add(this.rb_label);
            this.groupBox1.Location = new System.Drawing.Point(16, 58);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(245, 36);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sort By Menu Item";
            // 
            // rb_form
            // 
            this.rb_form.AutoSize = true;
            this.rb_form.Location = new System.Drawing.Point(167, 18);
            this.rb_form.Margin = new System.Windows.Forms.Padding(2);
            this.rb_form.Name = "rb_form";
            this.rb_form.Size = new System.Drawing.Size(48, 17);
            this.rb_form.TabIndex = 2;
            this.rb_form.Text = "Form";
            this.rb_form.UseVisualStyleBackColor = true;
            this.rb_form.CheckedChanged += new System.EventHandler(this.rbForm_CheckedChanged);
            // 
            // rb_name
            // 
            this.rb_name.AutoSize = true;
            this.rb_name.Location = new System.Drawing.Point(86, 17);
            this.rb_name.Margin = new System.Windows.Forms.Padding(2);
            this.rb_name.Name = "rb_name";
            this.rb_name.Size = new System.Drawing.Size(53, 17);
            this.rb_name.TabIndex = 1;
            this.rb_name.Text = "Name";
            this.rb_name.UseVisualStyleBackColor = true;
            this.rb_name.CheckedChanged += new System.EventHandler(this.rbName_CheckedChanged);
            // 
            // rb_label
            // 
            this.rb_label.AutoSize = true;
            this.rb_label.Checked = true;
            this.rb_label.Location = new System.Drawing.Point(5, 18);
            this.rb_label.Margin = new System.Windows.Forms.Padding(2);
            this.rb_label.Name = "rb_label";
            this.rb_label.Size = new System.Drawing.Size(51, 17);
            this.rb_label.TabIndex = 0;
            this.rb_label.TabStop = true;
            this.rb_label.Text = "Label";
            this.rb_label.UseVisualStyleBackColor = true;
            this.rb_label.CheckedChanged += new System.EventHandler(this.rbLabel_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Task Recording Type:";
            // 
            // tb_taskRecordingType
            // 
            this.tb_taskRecordingType.Location = new System.Drawing.Point(133, 36);
            this.tb_taskRecordingType.Name = "tb_taskRecordingType";
            this.tb_taskRecordingType.Size = new System.Drawing.Size(128, 20);
            this.tb_taskRecordingType.TabIndex = 9;
            // 
            // btn_exportCSV
            // 
            this.btn_exportCSV.Enabled = false;
            this.btn_exportCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exportCSV.Location = new System.Drawing.Point(132, 293);
            this.btn_exportCSV.Name = "btn_exportCSV";
            this.btn_exportCSV.Size = new System.Drawing.Size(98, 28);
            this.btn_exportCSV.TabIndex = 10;
            this.btn_exportCSV.Text = "Export to CSV";
            this.btn_exportCSV.UseVisualStyleBackColor = true;
            this.btn_exportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // btn_exportXLSX
            // 
            this.btn_exportXLSX.Enabled = false;
            this.btn_exportXLSX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_exportXLSX.Location = new System.Drawing.Point(13, 293);
            this.btn_exportXLSX.Name = "btn_exportXLSX";
            this.btn_exportXLSX.Size = new System.Drawing.Size(113, 28);
            this.btn_exportXLSX.TabIndex = 11;
            this.btn_exportXLSX.Text = "Export to XSLX";
            this.btn_exportXLSX.UseVisualStyleBackColor = true;
            this.btn_exportXLSX.Click += new System.EventHandler(this.btnExportXLSX_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 326);
            this.Controls.Add(this.btn_exportXLSX);
            this.Controls.Add(this.btn_exportCSV);
            this.Controls.Add(this.tb_taskRecordingType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lv_output);
            this.Controls.Add(this.btn_parse);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.tb_input);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form";
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
        private System.Windows.Forms.ListView lv_output;
        private System.Windows.Forms.ColumnHeader menuItemLabel;
        private System.Windows.Forms.ColumnHeader menuItemName;
        private System.Windows.Forms.ColumnHeader menuItemType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_form;
        private System.Windows.Forms.RadioButton rb_name;
        private System.Windows.Forms.RadioButton rb_label;
        private System.Windows.Forms.ColumnHeader formName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_taskRecordingType;
        private System.Windows.Forms.Button btn_exportCSV;
        private System.Windows.Forms.Button btn_exportXLSX;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

