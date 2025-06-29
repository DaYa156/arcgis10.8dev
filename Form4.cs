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
    public partial class Form4 : System.Windows.Forms.Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        // 存当前打开的 GDB 工作空间
        private IWorkspace _workspace;
        private string _gdbPath;
        private void btnOpenDb_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "File GDB (*.gdb)|*.gdb|Personal GDB (*.mdb)|*.mdb";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            _gdbPath = openFileDialog1.FileName;

            // 根据扩展名选工厂
            IWorkspaceFactory wf = Path.GetExtension(_gdbPath)
                .Equals(".gdb", StringComparison.OrdinalIgnoreCase)
              ? (IWorkspaceFactory)new FileGDBWorkspaceFactoryClass()
              : new AccessWorkspaceFactoryClass();

            // 一律传 _gdbPath（.gdb 是一个“文件夹”，.mdb 是一个文件）
            _workspace = wf.OpenFromFile(_gdbPath, 0);

            // 枚举要素/栅格到 treeDB
            LoadFeatureClassList();

            // 回传给 Form1
            (this.Owner as Form1)?.SetWorkspace(_gdbPath, _workspace);
        }
       
        private void LoadFeatureClassList()
        {
            treeDB.Nodes.Clear();
            IFeatureWorkspace featWs = _workspace as IFeatureWorkspace;

            // 1. 枚举要素数据集及其内部要素类
            var nodeFdsRoot = treeDB.Nodes.Add("要素数据集");
            IEnumDatasetName enumFds = _workspace.get_DatasetNames(esriDatasetType.esriDTFeatureDataset);
            enumFds.Reset();
            IDatasetName fdsName;
            while ((fdsName = enumFds.Next()) != null)
            {
                var nodeFds = nodeFdsRoot.Nodes.Add(fdsName.Name);
                // 打开要素数据集
                IFeatureDataset fds = featWs.OpenFeatureDataset(fdsName.Name);
                IEnumDataset subEnum = fds.Subsets;
                subEnum.Reset();
                IDataset subDs;
                while ((subDs = subEnum.Next()) != null)
                {
                    nodeFds.Nodes.Add(subDs.Name);
                }
            }

            // 2. 枚举顶层要素类
            var nodeFcRoot = treeDB.Nodes.Add("独立要素类");
            IEnumDatasetName enumFc = _workspace.get_DatasetNames(esriDatasetType.esriDTFeatureClass);
            enumFc.Reset();
            IDatasetName fcName;
            while ((fcName = enumFc.Next()) != null)
            {
                nodeFcRoot.Nodes.Add(fcName.Name);
            }

            // 3. 枚举栅格数据
            //var nodeRstRoot = treeDB.Nodes.Add("栅格数据");
            //IEnumDatasetName enumRst = _workspace.get_DatasetNames(esriDatasetType.esriDTRasterDataset);
            //enumRst.Reset();
            //IDatasetName rstName;
            //while ((rstName = enumRst.Next()) != null)
            //{
            //   nodeRstRoot.Nodes.Add(rstName.Name);
            //}

            treeDB.ExpandAll();
        }

        private void treeDB_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string name = e.Node.Text;
            if (!lbSelected.Items.Contains(name))
                lbSelected.Items.Add(name);
        }
        private void btnAddToScene_Click(object sender, EventArgs e)
        {
            // 拿到 Form1 实例
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                foreach (string fcName in lbSelected.Items)
                {
                    // 调用 Form1 的公开方法，把要素名传过去
                    main.AddLayerToScene(fcName);
                }
            }
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbSelected.SelectedItem != null)
            {
                lbSelected.Items.Remove(lbSelected.SelectedItem);
            }
        }
    }
}
