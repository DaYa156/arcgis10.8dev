
namespace 秦淮河流域概览
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
            this.btnload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt三维点 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cob高程 = new System.Windows.Forms.ComboBox();
            this.btnpath = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnok = new System.Windows.Forms.Button();
            this.btnno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnload
            // 
            this.btnload.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnload.Location = new System.Drawing.Point(12, 12);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(294, 66);
            this.btnload.TabIndex = 0;
            this.btnload.Text = "加载Shp文件";
            this.btnload.UseVisualStyleBackColor = true;
            this.btnload.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(91, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "三维点图层";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt三维点
            // 
            this.txt三维点.BackColor = System.Drawing.SystemColors.Control;
            this.txt三维点.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt三维点.Location = new System.Drawing.Point(12, 132);
            this.txt三维点.Name = "txt三维点";
            this.txt三维点.Size = new System.Drawing.Size(294, 25);
            this.txt三维点.TabIndex = 2;
            this.txt三维点.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(79, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "选择高程字段";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cob高程
            // 
            this.cob高程.BackColor = System.Drawing.SystemColors.Control;
            this.cob高程.FormattingEnabled = true;
            this.cob高程.Location = new System.Drawing.Point(12, 234);
            this.cob高程.Name = "cob高程";
            this.cob高程.Size = new System.Drawing.Size(294, 23);
            this.cob高程.TabIndex = 4;
            this.cob高程.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnpath
            // 
            this.btnpath.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnpath.Location = new System.Drawing.Point(12, 279);
            this.btnpath.Name = "btnpath";
            this.btnpath.Size = new System.Drawing.Size(294, 71);
            this.btnpath.TabIndex = 5;
            this.btnpath.Text = "选择TIN的保存路径";
            this.btnpath.UseVisualStyleBackColor = true;
            this.btnpath.Click += new System.EventHandler(this.btnpath_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(341, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(302, 245);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // btnok
            // 
            this.btnok.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnok.Location = new System.Drawing.Point(373, 279);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(106, 42);
            this.btnok.TabIndex = 7;
            this.btnok.Text = "确定";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // btnno
            // 
            this.btnno.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnno.Location = new System.Drawing.Point(521, 279);
            this.btnno.Name = "btnno";
            this.btnno.Size = new System.Drawing.Size(101, 42);
            this.btnno.TabIndex = 8;
            this.btnno.Text = "取消";
            this.btnno.UseVisualStyleBackColor = true;
            this.btnno.Click += new System.EventHandler(this.btnno_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 381);
            this.Controls.Add(this.btnno);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnpath);
            this.Controls.Add(this.cob高程);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt三维点);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "点构成TIN";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt三维点;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cob高程;
        private System.Windows.Forms.Button btnpath;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Button btnno;
    }
}