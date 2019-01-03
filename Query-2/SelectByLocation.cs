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
using ESRI.ArcGIS.Geometry;

namespace Query_2
{
    public partial class SelectByLocation : Form
    {
        #region 定义变量
        private IMap currentMap;
        private IFeatureLayer currentFeatureLayer;
        public IMap CurrentMap
        {
            set { currentMap = value; }
        }
        #endregion

        public SelectByLocation()
        {
            InitializeComponent();
        }

        //关闭窗口
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //加载窗口时
        private void SelectByLocation_Load(object sender, EventArgs e)
        {
            TargetLayer.Items.Clear();
            string layerName;
            for (int i = 0; i < currentMap.LayerCount; i++)
            {
                if (currentMap.get_Layer(i) is IFeatureLayer)
                {
                    if (currentMap.get_Layer(i) is GroupLayer)
                    {
                        ICompositeLayer pCompositeLayer = currentMap.get_Layer(i) as ICompositeLayer;
                        for (int j = 0; j < pCompositeLayer.Count; j++)
                        {
                            layerName = pCompositeLayer.get_Layer(i).Name;
                            TargetLayer.Items.Add(layerName);
                            TargetLayer.Refresh();
                            SourceLayerSelect.Items.Add(layerName);
                        }
                    }
                    else
                    {
                        layerName=currentMap.get_Layer(i).Name;
                        TargetLayer.Items.Add(layerName);
                        TargetLayer.Refresh();
                        SourceLayerSelect.Items.Add(layerName);
                    }
                }
            }
            SourceLayerSelect.SelectedIndex = 0;
            MethodSelect.SelectedIndex = 0;
        }
        //勾选可见图层时
        private void VisiableOnly_CheckedChanged(object sender, EventArgs e)
        {
            TargetLayer.Items.Clear();
            string layerName;

            //当勾选时
            if (VisiableOnly.CheckState == CheckState.Checked)
            {
                for (int i = 0; i < currentMap.LayerCount; i++)
                {
                    if (currentMap.get_Layer(i) is IFeatureLayer && currentMap.get_Layer(i).Visible == true)
                    {
                        if (currentMap.get_Layer(i) is GroupLayer)
                        {
                            ICompositeLayer pCompositeLayer = currentMap.get_Layer(i) as ICompositeLayer;
                            for (int j = 0; j < pCompositeLayer.Count; j++)
                            {
                                layerName = pCompositeLayer.get_Layer(i).Name;
                                TargetLayer.Items.Add(layerName);
                                TargetLayer.Refresh();
                            }
                        }
                        else
                        {
                            layerName = currentMap.get_Layer(i).Name;
                            TargetLayer.Items.Add(layerName);
                            TargetLayer.Refresh();
                        }
                    }
                }
            }
            //未勾选时
            if (VisiableOnly.CheckState == CheckState.Unchecked)
            {
                for (int i = 0; i < currentMap.LayerCount; i++)
                {
                    if (currentMap.get_Layer(i) is IFeatureLayer)
                    {
                        if (currentMap.get_Layer(i) is GroupLayer)
                        {
                            ICompositeLayer pCompositeLayer = currentMap.get_Layer(i) as ICompositeLayer;
                            for (int j = 0; j < pCompositeLayer.Count; j++)
                            {
                                layerName = pCompositeLayer.get_Layer(i).Name;
                                TargetLayer.Items.Add(layerName);
                                TargetLayer.Refresh();
                            }
                        }
                        else
                        {
                            layerName = currentMap.get_Layer(i).Name;
                            TargetLayer.Items.Add(layerName);
                            TargetLayer.Refresh();
                        }
                    }
                }
            }
            SourceLayerSelect.SelectedIndex = 0;
        }

        #region 空间属性查找
        //根据空间位置查找
        private void SelectFeatureBySpatial()
        {
            ISpatialFilter pSF = new SpatialFilterClass();
            //设定源图层几何体为用于查询的几何体
            pSF.Geometry=GetFeatureGeometryUnion(GetFEaturreByName(currentMap,SourceLayerSelect.SelectedItem.ToString()));
            //根据选择方法采用相应的选择方法
            switch (MethodSelect.SelectedIndex)
            {
                case 0:
                    pSF.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    break;
                case 1:
                    pSF.SpatialRel = esriSpatialRelEnum.esriSpatialRelTouches;
                    break;
                case 2:
                    pSF.SpatialRel = esriSpatialRelEnum.esriSpatialRelOverlaps;
                    break;
                case 3:
                    pSF.SpatialRel = esriSpatialRelEnum.esriSpatialRelCrosses;
                    break;
                case 4:
                    pSF.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                    break;
                case 5:
                    pSF.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                    break;
            }
            //遍历所选择的目标图层（目标图层可能不止一个）
            IFeatureLayer pFeatureLayer;
            for (int i = 0; i < TargetLayer.CheckedItems.Count; i++)
            {
                pFeatureLayer=GetFEaturreByName(currentMap,(string)TargetLayer.CheckedItems[i]);
                //接口转换，使用IFeatureSelection接口选择要素
                IFeatureSelection pFeatureSelection = pFeatureLayer as IFeatureSelection;
                //SelectFeature方法通过空间查询过滤器选择要素
                pFeatureSelection.SelectFeatures((IQueryFilter)pSF, esriSelectionResultEnum.esriSelectionResultAdd, false);
            }
            IActiveView pActiveView = currentMap as IActiveView;
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, pActiveView.Extent);
            
        }

        //通过图层名查找图层
        private IFeatureLayer GetFEaturreByName(IMap pmap, string layerName)
        {
            //遍历地图中的图层
            for (int i = 0; i < pmap.LayerCount; i++)
            {
                if (pmap.get_Layer(i) is GroupLayer)
                {
                    ICompositeLayer pCompositeLayer = pmap.get_Layer(i) as ICompositeLayer;
                    for (int j = 0; j < pCompositeLayer.Count; j++)
                    {
                        if (pCompositeLayer.get_Layer(j).Name == layerName)
                            return (IFeatureLayer)pCompositeLayer.get_Layer(j);
                    }
                }
                else
                {
                    if (pmap.get_Layer(i).Name == layerName)
                        return (IFeatureLayer)pmap.get_Layer(i);
                }
            }
            return null;
        }

        //合并源图层为一集合体
        private IGeometry GetFeatureGeometryUnion(IFeatureLayer pFeatureLayer)
        {
            //IGeometyr用于存储拓扑操作后的几何体
            IGeometry pGeometry=null;
            // ITopologicalOperator进行拓扑操作
            ITopologicalOperator pTopologicalOperator;
            IFeatureCursor pCursor = pFeatureLayer.Search(null, false);
            IFeature pFeature = pCursor.NextFeature();
            while (pFeature != null)
            {
                if (pGeometry != null)
                {
                    //使用当前几何体进行拓扑操作
                    pTopologicalOperator = pGeometry as ITopologicalOperator;
                    //将当前几何体进行union操作
                    pGeometry = pTopologicalOperator.Union(pFeature.Shape);
                }
                else
                    pGeometry =pFeature.Shape;
                pFeature = pCursor.NextFeature();
            }
            return pGeometry;
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            SelectFeatureBySpatial();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectFeatureBySpatial();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentMap.ClearSelection();
            IActiveView pActiveView = currentMap as IActiveView;
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, pActiveView.Extent);
        }
    }
}
