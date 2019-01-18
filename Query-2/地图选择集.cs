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
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;

namespace Query_2
{
    public partial class SelectionSet : Form
    {
        #region 定义变量
        private IMap currentMap;
        private IFeatureLayer currentFeatureLayer;
        public IMap CurrentMap
        {
            set { currentMap = value; }
        }
        #endregion

        public SelectionSet()
        {
            InitializeComponent();
        }

        //加载窗体时生成treeView中的节点信息
        private void SelectionSet_Load(object sender, EventArgs e)
        {
            IFeatureLayer pFeatureLayer;
            string layerName;
            TreeNode pTreeNode;

            //得到TreeView控件中的节点（选择的图层）
            for (int i = 0; i < currentMap.LayerCount; i++)
            {
                if (currentMap.Layer[i] is GroupLayer)
                {
                    ICompositeLayer pCompositeLayer = currentMap.get_Layer(i) as ICompositeLayer;
                    for (int j = 0; j < pCompositeLayer.Count; j++)
                    {
                        layerName = pCompositeLayer.get_Layer(j).Name;
                        pFeatureLayer = pCompositeLayer.get_Layer(j) as IFeatureLayer;
                        //若图层中选择的要素不为空
                        if (((IFeatureSelection)pFeatureLayer).SelectionSet.Count > 0)
                        {
                            pTreeNode = new TreeNode(layerName);
                            //Tag属性存储当前图层的IFeatureLayer接口信息
                            pTreeNode.Tag = pFeatureLayer;
                            treeView1.TopNode.Nodes.Add(pTreeNode);
                        }
                    }
                }
                else
                {
                    layerName = currentMap.get_Layer(i).Name;
                    pFeatureLayer = currentMap.get_Layer(i) as IFeatureLayer;
                    if (((IFeatureSelection)pFeatureLayer).SelectionSet.Count > 0)
                    {
                        pTreeNode = new TreeNode(layerName);
                        pTreeNode.Tag = pFeatureLayer;
                        treeView1.TopNode.Nodes.Add(pTreeNode);
                    }
                }
            }
            treeView1.TopNode.Expand();
            label1.Text = "当前共选择了 " + currentMap.SelectionCount + " 个要素";
        }

        //点击treeView节点时dataGridView显示选择图层的属性表
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            currentFeatureLayer = e.Node.Tag as IFeatureLayer;
            IFeatureSelection pFeatureSelection = currentFeatureLayer as IFeatureSelection;
            ISelectionSet pSelectionSet=pFeatureSelection.SelectionSet;
            label1.Text = "当前图层选择了" + pSelectionSet.Count + "个要素";
            
            //遍历要素的属性字段
            IFields pFields = currentFeatureLayer.FeatureClass.Fields;
            for (int i = 0; i < pFields.FieldCount; i++)
            {
                dataGridView1.Columns.Add(pFields.get_Field(i).Name, pFields.get_Field(i).AliasName);
            }

            //遍历选择集，建立行.遍历各要素首先要想到Icursor接口
            ICursor pCursor;
            pSelectionSet.Search(null, false, out pCursor);
            IFeatureCursor pFeatureCursor = pCursor as IFeatureCursor;
            //获取游标的第一个元素
            IFeature pFeature = pFeatureCursor.NextFeature();
            //strs用于暂存每一行数据
            string[] sres;
            while (pFeature != null)
            {
                //设置str数组的大小
                sres = new string[pFields.FieldCount];
                for (int i = 0; i < pFields.FieldCount; i++)
                {
                    sres[i] = pFeature.get_Value(i).ToString();
                }
                dataGridView1.Rows.Add(sres);
                pFeature = pFeatureCursor.NextFeature();
            }
        }

        //点击某一行时，主窗体的地图定位到选择的要素范围
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取当前点击的行
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            //获取objectID
            int objectID = Convert.ToInt32(row.Cells[0].Value);
            IFeature pFeature = currentFeatureLayer.FeatureClass.GetFeature(objectID);
            IEnvelope pEnvelope = new EnvelopeClass();
            pEnvelope = pFeature.Extent;
            IActiveView pActiveView = currentMap as IActiveView;
            pActiveView.Extent = pEnvelope;
            pActiveView.Refresh();
        }


    }
}
