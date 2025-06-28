using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;

namespace 秦淮河流域概览
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.Load += Form1_Load;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 绑定运行时与许可
            //RuntimeManager.Bind(ProductCode.EngineOrDesktop);
            //ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);

            // 配对
            //axToolbarControl1.SetBuddyControl(axMapControl1);
            //axTOCControl1.SetBuddyControl(axMapControl1);

            // 打开文档命令
            var openCmd = new ControlsOpenDocCommand();
            axToolbarControl1.AddItem(openCmd, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            openCmd.OnCreate(axMapControl1.Object);

            // 缩放、漫游工具
            var zoomIn = new ControlsMapZoomInTool();
            axToolbarControl1.AddItem(zoomIn, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            zoomIn.OnCreate(axMapControl1.Object);

            var panTool = new ControlsMapPanTool();
            axToolbarControl1.AddItem(panTool, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            panTool.OnCreate(axMapControl1.Object);
        }
    }
}
