using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;



namespace 秦淮河流域概览
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private IWorkspace _workspace;
        private string _gdbPath;



        private void Form1_Load(object sender, EventArgs e)
        {


            // 打开文档命令
            //var openCmd = new ControlsOpenDocCommand();
            //axToolbarControl1.AddItem(openCmd, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //openCmd.OnCreate(axSceneControl1.Object);

            // 添加数据工具
            //var addDataCmd = new ControlsAddDataCommand();
            //axToolbarControl1.AddItem(addDataCmd, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //addDataCmd.OnCreate(axSceneControl1.Object);

            // 缩放工具
            //var zoomIn = new ControlsMapZoomInTool();
            //axToolbarControl1.AddItem(zoomIn, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //zoomIn.OnCreate(axSceneControl1.Object);

            // 漫游工具
            //var panTool = new ControlsMapPanTool();
            //axToolbarControl1.AddItem(panTool, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //panTool.OnCreate(axSceneControl1.Object);

            // 2. 打开场景文档（.sxd）
            var openSceneCmd = new ControlsSceneOpenDocCommand();
            axToolbarControl1.AddItem(openSceneCmd, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            openSceneCmd.OnCreate(axSceneControl1.Object);

            // 3. 添加数据（支持添加地理数据到 Scene）
            //var addSceneData = new ControlsSceneAddDataCommand();
            //axToolbarControl1.AddItem(addSceneData, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            //addSceneData.OnCreate(axSceneControl1.Object);

            // 4. 缩放工具
            var zoomInScene = new ControlsSceneZoomInTool();
            axToolbarControl1.AddItem(zoomInScene, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            zoomInScene.OnCreate(axSceneControl1.Object);

            // 5. 漫游工具
            var panScene = new ControlsScenePanTool();
            axToolbarControl1.AddItem(panScene, -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            panScene.OnCreate(axSceneControl1.Object);

            // ② “导航”工具
            var navTool = new ControlsSceneNavigateTool();
            axToolbarControl1.AddItem(
                navTool,
                -1, -1,
                false,
                0,
                esriCommandStyles.esriCommandStyleIconOnly
            );
            navTool.OnCreate(axSceneControl1.Object);

            // ③ “飞行”工具
            var flyTool = new ControlsSceneFlyTool();
            axToolbarControl1.AddItem(
                flyTool,
                -1, -1,
                false,
                0,
                esriCommandStyles.esriCommandStyleIconOnly
            );
            flyTool.OnCreate(axSceneControl1.Object);

            // ④ “全图”命令
            var fullExtentCmd = new ControlsSceneFullExtentCommand();
            axToolbarControl1.AddItem(
                fullExtentCmd,
                -1, -1,
                false,
                0,
                esriCommandStyles.esriCommandStyleIconOnly
            );
            fullExtentCmd.OnCreate(axSceneControl1.Object);


        }
        private void 读取shp文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // 1. 选文件
            var dlg = new OpenFileDialog
            {
                Title = "打开 Shapefile",
                Filter = "Shapefile (*.shp)|*.shp",
                Multiselect = false
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            string shpPath = dlg.FileName;
            string folder = Path.GetDirectoryName(shpPath);
            string name = Path.GetFileNameWithoutExtension(shpPath);

            // 2. new COM coclass
            IWorkspaceFactory wsFactory = new ShapefileWorkspaceFactoryClass();

            // —— 这一步之前，必须已经做好了 Runtime.Bind + AoInitialize.Initialize —— 
            IFeatureWorkspace featWs =
                wsFactory.OpenFromFile(folder, 0) as IFeatureWorkspace;

            // 3. 打开要素类并生成图层
            IFeatureClass featClass = featWs.OpenFeatureClass(name);
            var featLayer = new FeatureLayerClass
            {
                FeatureClass = featClass,
                Name = featClass.AliasName
            };
            ILayer layer = featLayer as ILayer;

            // 4. 加到 SceneControl
            axSceneControl1.Scene.AddLayer(layer);
            axSceneControl1.Refresh();
        }
        private void 读取tin文件ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ILayer pLayer;
            FolderBrowserDialog Brower_1 = new FolderBrowserDialog();
            if (Brower_1.ShowDialog() == DialogResult.OK)
            {
                string filePath = Brower_1.SelectedPath;
                string tinFilePath = System.IO.Path.GetFileName(filePath);
                pLayer = openTinLayer(filePath);
                pLayer.Name = tinFilePath;

                axSceneControl1.Scene.AddLayer(pLayer);
            }
        }

        public static ILayer openTinLayer(string fullPath)
        {
            ITinWorkspace pTinWorkspace;
            IWorkspace pWS;
            IWorkspaceFactory pWSF = new TinWorkspaceFactory();

            ITinLayer pTinLayer = new TinLayerClass();

            string pathToWorkspace = System.IO.Path.GetDirectoryName(fullPath);
            string tinName = System.IO.Path.GetFileName(fullPath);
            ITin pTin;

            pWS = pWSF.OpenFromFile(pathToWorkspace, 0);
            pTinWorkspace = (ITinWorkspace)pWS;

            if (pTinWorkspace.get_IsTin(tinName))
            {
                pTin = pTinWorkspace.OpenTin(tinName);

                pTinLayer.Dataset = pTin;

                pTinLayer.ClearRenderers();

                return pTinLayer as ILayer;
            }
            else
            {
                MessageBox.Show("该目录不包含TIN文件");
                return null;
            }
        }
        private void 读取栅格文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file_1 = new OpenFileDialog();
            IRasterLayer pRasterLayer = new RasterLayerClass();
            file_1.Filter = "打开影像文件|*.jpg;*.tif;*.img;*.tiff";
            file_1.Multiselect = false;
            if (file_1.ShowDialog() == DialogResult.OK)
            {
                string pPath = file_1.FileName;
                string pFolder = System.IO.Path.GetDirectoryName(pPath);
                string pFilename = System.IO.Path.GetFileName(pPath);

                pRasterLayer.CreateFromFilePath(pPath);

                axSceneControl1.Scene.AddLayer(pRasterLayer);
            }
        }
        private void 点生成tinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm_2 = new Form2();
            frm_2.Show();
        }

        private void axSceneControl1_OnMouseDown(object sender, ISceneControlEvents_OnMouseDownEvent e)
        {

        }

        private void 生成等高线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm_3 = new Form3();
            frm_3.Show();
        }

        private void 从数据库中加载数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _workspace = null;
            var dlg = new Form4();
            dlg.Owner = this;            // 指定拥有者
            dlg.ShowDialog();            // 阻塞模式，也可用 Show()
        }
        public void SetWorkspace(string gdbPath, IWorkspace workspace)
        {
            _gdbPath = gdbPath;
            _workspace = workspace;
        }
        public void AddLayerToScene(string datasetName)
        {
            if (_workspace == null)
            {
                MessageBox.Show("请先打开并选择一个数据库！");
                return;
            }

            // —— 尝试加载要素类 —— 
            var featWs = _workspace as IFeatureWorkspace;
            if (featWs != null)
            {
                try
                {
                    var fc = featWs.OpenFeatureClass(datasetName);
                    var featLayer = new FeatureLayerClass
                    {
                        FeatureClass = fc,
                        Name = fc.AliasName
                    };
                    axSceneControl1.Scene.AddLayer((ILayer)featLayer);
                    axSceneControl1.Refresh();
                    return;
                }
                catch
                {
                    // 不是要素类，继续
                }
            }

            

            MessageBox.Show($"无法识别类型，加载“{datasetName}”失败。");
        }

    }
}
