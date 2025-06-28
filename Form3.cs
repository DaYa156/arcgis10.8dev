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
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geometry;

namespace 秦淮河流域概览
{
    public partial class Form3 : System.Windows.Forms.Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        string savePath;
        ITin pTin;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOPEN_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Browser_1 = new FolderBrowserDialog();
            if (Browser_1.ShowDialog() == DialogResult.OK)
            {
                string filePath = Browser_1.SelectedPath;
                string tinPath = System.IO.Path.GetDirectoryName(filePath);
                string tinFilePath = System.IO.Path.GetFileName(filePath);
                IWorkspaceFactory pWorkspaceFactory = new TinWorkspaceFactoryClass();
                IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(tinPath, 0);
                ITinWorkspace pTinWorkspace = (ITinWorkspace)pWorkspace;
                pTin = pTinWorkspace.OpenTin(tinFilePath);
                ITinLayer pTinLayer = new TinLayerClass();
                pTinLayer.Dataset = pTin;

                ITinAdvanced pTinAdvanced;
                int nCount;
                double dzmax = 0;
                double dzmin = 0;
                double dz;

                pTinAdvanced = (ITinAdvanced)pTin;
                nCount = pTinAdvanced.NodeCount;
                for (int i = 1; i < nCount + 1; i++)
                {
                    if (pTinAdvanced.GetNode(i).IsInsideDataArea)
                    {
                        dz = pTinAdvanced.GetNodeZ(i);
                        if (dzmax < dz)
                        {
                            dzmax = dz;
                        }
                        if (dzmin > dz)
                        {
                            dzmin = dz;
                        }
                    }
                }

                richTextBox1.Text = "文件名：" + tinFilePath + Environment.NewLine + "zmax = " + dzmax + Environment.NewLine + "zmin = " + dzmin;
            }
        }

        private void txtb1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            string str_1;
            FolderBrowserDialog Brower_1 = new FolderBrowserDialog();
            if (Brower_1.ShowDialog() == DialogResult.OK)
            {
                str_1 = Brower_1.SelectedPath;
                savePath = System.IO.Path.GetDirectoryName(str_1);
                richTextBox1.AppendText(Environment.NewLine);
                richTextBox1.AppendText("保存路径：");
                richTextBox1.AppendText(savePath);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                IGeoDataset pGeoDataset;
                ISurface pSurface = new TinClass();
                ISpatialReference pSpatialReference;
                IFeatureClass pFeatureClass;

                pGeoDataset = (IGeoDataset)pTin;
                pSpatialReference = pGeoDataset.SpatialReference;
                pSurface = (ITinSurface)pTin;
                string strname = "由TIN生成等高线";
                CreatShapefile(savePath, strname, pSpatialReference);
                IWorkspaceFactory pWorksapaceFactory = new ShapefileWorkspaceFactory();
                IWorkspace pWorkspace = pWorksapaceFactory.OpenFromFile(savePath, 0);
                IFeatureWorkspace pFeatureWorkspace = (IFeatureWorkspace)pWorkspace;
                IFeatureClass pFeatureClass_2 = pFeatureWorkspace.OpenFeatureClass(strname);
                pFeatureClass = pFeatureClass_2;
                string strHeight = "Height";
                double doubl_1 = double.Parse(textBox1.Text);
                double doubl_2 = double.Parse(txtb1.Text);
                pSurface.Contour(doubl_1, doubl_2, pFeatureClass, strHeight, 0);
                MessageBox.Show("等值线创建完成！" + Environment.NewLine + savePath + @"\由TIN生成等高线.shp");
                this.Close();
            }
            catch
            {
                MessageBox.Show("错误1:未打开TIN文件" + Environment.NewLine + "错误2:未选择保存路径" + Environment.NewLine + "错误3:由TIN生成等高线.shp文件已经存在，请全部删除！" + Environment.NewLine + "错误4:未输入或错误输入等高线间距及基等值线");
            }
        }

        private void btnNO_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void CreatShapefile(string sPath, string sName, ISpatialReference sPatialaRef)
        {
            IFeatureWorkspace pFWS;
            IWorkspaceFactory pWorkspaceFactory;
            pWorkspaceFactory = new ShapefileWorkspaceFactory();
            pFWS = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(sPath, 0);

            IFields pFields;
            IFieldsEdit pFieldsEdit;
            pFields = new Fields();
            pFieldsEdit = (IFieldsEdit)pFields;

            IField pField;
            IFieldEdit pFieldEdit;

            pField = new Field();
            pFieldEdit = (IFieldEdit)pField;

            pFieldEdit.Name_2 = "Shape";
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;

            IGeometryDef pGeomDef;
            IGeometryDefEdit pGeoDefEdit;
            pGeomDef = new GeometryDef();
            pGeoDefEdit = pGeomDef as IGeometryDefEdit;
            pGeoDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolyline;
            pGeoDefEdit.SpatialReference_2 = new UnknownCoordinateSystemClass();
            pFieldEdit.GeometryDef_2 = pGeomDef;
            pFieldsEdit.AddField(pField);

            pField = new Field();
            pFieldEdit = pField as IFieldEdit;
            pFieldEdit.Length_2 = 30;
            pFieldEdit.Name_2 = "MiscText";
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            pFieldsEdit.AddField(pField);

            IFeatureClass pFeatureClass;
            pFeatureClass = pFWS.CreateFeatureClass(sName, pFields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
        }
    }
}
