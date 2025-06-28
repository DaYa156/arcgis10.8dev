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
using ESRI.ArcGIS.Geometry;

namespace 秦淮河流域概览
{
    public partial class Form2 : System.Windows.Forms.Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string pPath, pFolder, pFileName;
        string savePath = "";
        IFeatureLayer selectLayer;
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnpath_Click(object sender, EventArgs e)
        {
            string str_1;
            FolderBrowserDialog Brower_1 = new FolderBrowserDialog();
            if (Brower_1.ShowDialog() == DialogResult.OK)
            {
                str_1 = Brower_1.SelectedPath;
                savePath = System.IO.Path.GetDirectoryName(str_1);
                richTextBox1.Text = savePath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file_1 = new OpenFileDialog();
            IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory();
            file_1.Filter = "打开shp文件|*.shp";
            file_1.Multiselect = false;
            if (file_1.ShowDialog() == DialogResult.OK)
            {
                pPath = file_1.FileName;
                pFolder = System.IO.Path.GetDirectoryName(pPath);
                pFileName = System.IO.Path.GetFileName(pPath);

                IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(pFolder, 0);
                IFeatureWorkspace pFeatureWorkspace = (IFeatureWorkspace)pWorkspace;
                IFeatureClass pFeatureClass = pFeatureWorkspace.OpenFeatureClass(pFileName);
                selectLayer = new FeatureLayerClass();
                selectLayer.FeatureClass = pFeatureClass;
                selectLayer.Name = pFeatureClass.AliasName;
                ILayer pLayer = (ILayer)selectLayer;
                if (selectLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint || selectLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryMultipoint)
                {
                    txt三维点.Text = pFileName;

                }
                else
                {
                    MessageBox.Show("请选择点图层文件！");
                }

                if (txt三维点.Text != "")
                {
                    IFields pFields = new Fields();
                    IField pField = new Field();
                    int FieldCount;

                    pFields = selectLayer.FeatureClass.Fields;
                    FieldCount = pFields.FieldCount;
                    for (int i = 0; i < FieldCount; i++)
                    {
                        pField = pFields.get_Field(i);
                        if (pField.Type == esriFieldType.esriFieldTypeDouble || pField.Type == esriFieldType.esriFieldTypeInteger)
                        {
                            cob高程.Items.Add(pField.AliasName);
                        }
                    }
                }

            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(savePath + @"\TIN生成"))
            {
                MessageBox.Show("TIN文件已经存在！");
            }
            else
            {
                if (cob高程.Text == "")
                {
                    MessageBox.Show("请选择字段！");
                }
                else
                {
                    ITinEdit pTinEdit;
                    IEnvelope pEnvelope;
                    IGeoDataset pGeodataset;
                    IField pField;
                    int index;

                    pGeodataset = (IGeoDataset)selectLayer.FeatureClass;
                    pEnvelope = pGeodataset.Extent;
                    index = selectLayer.FeatureClass.FindField(cob高程.Text);
                    pField = selectLayer.FeatureClass.Fields.get_Field(index);
                    pTinEdit = new Tin() as ITinEdit;
                    pTinEdit.InitNew(pEnvelope);
                    object obj = Type.Missing;
                    pTinEdit.AddFromFeatureClass(selectLayer.FeatureClass, null, pField, null, esriTinSurfaceType.esriTinMassPoint, ref obj);
                    if (savePath != "")
                    {
                        pTinEdit.SaveAs(savePath + @"\TIN生成", ref obj);
                        pTinEdit.Refresh();
                        MessageBox.Show("TIN构建完成!" + Environment.NewLine + savePath + @"\TIN生成");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("未选择文件保存路径！");
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnno_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
