using ESRI.ArcGIS;
using ESRI.ArcGIS.Controls;     // ControlsOpenDocCommand、ControlsMapZoomInTool、esriCommandStyles 都在这里
using ESRI.ArcGIS.esriSystem;   // 如果你要用 IAoInitialize、ProductCode 枚举
namespace 秦淮河流域概览
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取shp文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取tin文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取栅格文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.点生成tinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成等高线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.从数据库中加载数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axSceneControl1 = new ESRI.ArcGIS.Controls.AxSceneControl();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSceneControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 28);
            this.axToolbarControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(1052, 28);
            this.axToolbarControl1.TabIndex = 2;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(712, 176);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.点生成tinToolStripMenuItem,
            this.生成等高线ToolStripMenuItem,
            this.从数据库中加载数据ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1052, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.读取shp文件ToolStripMenuItem,
            this.读取tin文件ToolStripMenuItem,
            this.读取栅格文件ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 读取shp文件ToolStripMenuItem
            // 
            this.读取shp文件ToolStripMenuItem.Name = "读取shp文件ToolStripMenuItem";
            this.读取shp文件ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.读取shp文件ToolStripMenuItem.Text = "读取shp文件";
            this.读取shp文件ToolStripMenuItem.Click += new System.EventHandler(this.读取shp文件ToolStripMenuItem_Click);
            // 
            // 读取tin文件ToolStripMenuItem
            // 
            this.读取tin文件ToolStripMenuItem.Name = "读取tin文件ToolStripMenuItem";
            this.读取tin文件ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.读取tin文件ToolStripMenuItem.Text = "读取tin文件";
            this.读取tin文件ToolStripMenuItem.Click += new System.EventHandler(this.读取tin文件ToolStripMenuItem_Click_1);
            // 
            // 读取栅格文件ToolStripMenuItem
            // 
            this.读取栅格文件ToolStripMenuItem.Name = "读取栅格文件ToolStripMenuItem";
            this.读取栅格文件ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.读取栅格文件ToolStripMenuItem.Text = "读取栅格文件";
            this.读取栅格文件ToolStripMenuItem.Click += new System.EventHandler(this.读取栅格文件ToolStripMenuItem_Click);
            // 
            // 点生成tinToolStripMenuItem
            // 
            this.点生成tinToolStripMenuItem.Name = "点生成tinToolStripMenuItem";
            this.点生成tinToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.点生成tinToolStripMenuItem.Text = "点生成TIN";
            this.点生成tinToolStripMenuItem.Click += new System.EventHandler(this.点生成tinToolStripMenuItem_Click);
            // 
            // 生成等高线ToolStripMenuItem
            // 
            this.生成等高线ToolStripMenuItem.Name = "生成等高线ToolStripMenuItem";
            this.生成等高线ToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.生成等高线ToolStripMenuItem.Text = "生成等高线";
            this.生成等高线ToolStripMenuItem.Click += new System.EventHandler(this.生成等高线ToolStripMenuItem_Click);
            // 
            // 从数据库中加载数据ToolStripMenuItem
            // 
            this.从数据库中加载数据ToolStripMenuItem.Name = "从数据库中加载数据ToolStripMenuItem";
            this.从数据库中加载数据ToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.从数据库中加载数据ToolStripMenuItem.Text = "从数据库中加载要素类";
            this.从数据库中加载数据ToolStripMenuItem.Click += new System.EventHandler(this.从数据库中加载数据ToolStripMenuItem_Click);
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 56);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(209, 582);
            this.axTOCControl1.TabIndex = 5;
            // 
            // axSceneControl1
            // 
            this.axSceneControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axSceneControl1.Location = new System.Drawing.Point(209, 56);
            this.axSceneControl1.Name = "axSceneControl1";
            this.axSceneControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSceneControl1.OcxState")));
            this.axSceneControl1.Size = new System.Drawing.Size(843, 582);
            this.axSceneControl1.TabIndex = 6;
            this.axSceneControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ISceneControlEvents_Ax_OnMouseDownEventHandler(this.axSceneControl1_OnMouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 638);
            this.Controls.Add(this.axSceneControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSceneControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取shp文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取tin文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取栅格文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 点生成tinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成等高线ToolStripMenuItem;
        private AxTOCControl axTOCControl1;
        private AxSceneControl axSceneControl1;
        private System.Windows.Forms.ToolStripMenuItem 从数据库中加载数据ToolStripMenuItem;
    }
}

