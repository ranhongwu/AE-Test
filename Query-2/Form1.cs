using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;

namespace Query_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region 封装方法
        private void ClearAllData()
        {
            if (axMapControl1.Map != null && axMapControl1.LayerCount > 0)
            {
                IMap pMap = new MapClass();
                axMapControl1.DocumentFilename = "";
            }
        }
        #endregion

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path;
            string name;

            OpenFileDialog pOFD = new OpenFileDialog();
            pOFD.Filter = "mxd文档（*.mxd）|*.mxd";
            pOFD.Multiselect = false;
            pOFD.CheckFileExists = true;
            pOFD.ShowDialog();

            string fullpath=pOFD.FileName;
            int index = pOFD.FileName.LastIndexOf('\\');
            path=fullpath.Substring(0,index);
            name = fullpath.Substring(index);

            if (fullpath == "") return;
            if(axMapControl1.CheckMxFile(fullpath))
            {
                ClearAllData();
                axMapControl1.LoadMxFile(fullpath);
            }
            else
                return;
        }

        private void 根据属性信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.CurrentMap = axMapControl1.Map;
            fm2.ShowDialog();
        }

        private void 根据空间位置选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectByLocation pSelectByLocationFron = new SelectByLocation();
            pSelectByLocationFron.CurrentMap = axMapControl1.Map;
            pSelectByLocationFron.ShowDialog();
        }

        private void 清除选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axMapControl1.Map.ClearSelection();
            axMapControl1.Refresh();
        }

        private void 地图选择集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectionSet SelectSetForm = new SelectionSet();
            SelectSetForm.CurrentMap = axMapControl1.Map;
            SelectSetForm.ShowDialog();
        }
    }
}
