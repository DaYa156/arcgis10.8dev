
namespace 秦淮河流域概览
{
    partial class Form4
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
            this.btnOpenDb = new System.Windows.Forms.Button();
            this.treeDB = new System.Windows.Forms.TreeView();
            this.lbSelected = new System.Windows.Forms.ListBox();
            this.btnAddToScene = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnOpenDb
            // 
            this.btnOpenDb.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenDb.Location = new System.Drawing.Point(62, 370);
            this.btnOpenDb.Name = "btnOpenDb";
            this.btnOpenDb.Size = new System.Drawing.Size(175, 58);
            this.btnOpenDb.TabIndex = 0;
            this.btnOpenDb.Text = "打开数据库";
            this.btnOpenDb.UseVisualStyleBackColor = true;
            this.btnOpenDb.Click += new System.EventHandler(this.btnOpenDb_Click);
            // 
            // treeDB
            // 
            this.treeDB.Location = new System.Drawing.Point(12, 12);
            this.treeDB.Name = "treeDB";
            this.treeDB.Size = new System.Drawing.Size(281, 338);
            this.treeDB.TabIndex = 1;
            this.treeDB.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeDB_NodeMouseDoubleClick);
            // 
            // lbSelected
            // 
            this.lbSelected.FormattingEnabled = true;
            this.lbSelected.ItemHeight = 15;
            this.lbSelected.Location = new System.Drawing.Point(299, 12);
            this.lbSelected.Name = "lbSelected";
            this.lbSelected.Size = new System.Drawing.Size(329, 334);
            this.lbSelected.TabIndex = 2;
            // 
            // btnAddToScene
            // 
            this.btnAddToScene.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddToScene.Location = new System.Drawing.Point(299, 370);
            this.btnAddToScene.Name = "btnAddToScene";
            this.btnAddToScene.Size = new System.Drawing.Size(163, 55);
            this.btnAddToScene.TabIndex = 3;
            this.btnAddToScene.Text = "添加至地图";
            this.btnAddToScene.UseVisualStyleBackColor = true;
            this.btnAddToScene.Click += new System.EventHandler(this.btnAddToScene_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRemove.Location = new System.Drawing.Point(477, 370);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(151, 55);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "移除选择";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 454);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddToScene);
            this.Controls.Add(this.lbSelected);
            this.Controls.Add(this.treeDB);
            this.Controls.Add(this.btnOpenDb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form4";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "从数据库中加载要素类";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenDb;
        private System.Windows.Forms.TreeView treeDB;
        private System.Windows.Forms.ListBox lbSelected;
        private System.Windows.Forms.Button btnAddToScene;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}