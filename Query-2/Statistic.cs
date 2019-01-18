using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;

namespace Query_2
{
    public partial class Statistic : Form
    {
        private IMap currentMap;
        private Hashtable layerHashtable;//哈希表存储图层名称和Featurelayer
        private IFeatureLayer currentFeatureLayer;

        public IMap CurrentMap
        {
            set { currentMap = value; }
        }

        public Statistic()
        {
            InitializeComponent();
            layerHashtable = new Hashtable();
        }

        private void Statistic_Load(object sender, EventArgs e)
        {
            IFeatureLayer pFeatureLayer;
            string layerName;
            int layerCount = 0;
            int allSelectedFeature = 0;
            layerHashtable.Clear();
            for (int i = 0; i < currentMap.LayerCount; i++)
            {
                if (currentMap.get_Layer(i) is GroupLayer)
                {
                    ICompositeLayer CompositeLayer = currentMap.get_Layer(i) as ICompositeLayer;
                    for (int j = 0; j < CompositeLayer.Count; j++)
                    {
                        layerName = CompositeLayer.get_Layer(j).Name;
                        pFeatureLayer = (IFeatureLayer)CompositeLayer.get_Layer(j);
                        if (((IFeatureSelection)pFeatureLayer).SelectionSet.Count > 0)
                        {
                            comboBox1.Items.Add(layerName);
                            layerHashtable.Add(layerName, pFeatureLayer);
                            layerCount += 1;
                            allSelectedFeature += ((IFeatureSelection)pFeatureLayer).SelectionSet.Count;
                        }
                    }
                }
                else
                {
                    layerName = currentMap.get_Layer(i).Name;
                    pFeatureLayer = (IFeatureLayer)currentMap.get_Layer(i);
                    if (((IFeatureSelection)pFeatureLayer).SelectionSet.Count > 0)
                    {
                        comboBox1.Items.Add(layerName);
                        layerHashtable.Add(layerName,pFeatureLayer);
                        layerCount += 1;
                        allSelectedFeature += ((IFeatureSelection)pFeatureLayer).SelectionSet.Count;
                    }
                }
            }
            label1.Text = "当前地图选择集共有" + layerCount + "个图层的" + allSelectedFeature + "个要素被选中。";
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            //遍历哈希表
            foreach (DictionaryEntry de in layerHashtable)
            {
                if (de.Key.ToString() == comboBox1.SelectedItem.ToString())
                {
                    currentFeatureLayer = de.Value as IFeatureLayer;
                    break;
                }
            }
            IFields pFields = currentFeatureLayer.FeatureClass.Fields; ;
            IField pField;
            for (int i = 0; i < pFields.FieldCount; i++)
            {
                pField = pFields.get_Field(i);
                if (pField.Name.ToUpper() != "OBJECTID" && pField.Name.ToUpper() != "SHAPE")
                {
                    if (pField.Type == esriFieldType.esriFieldTypeInteger || pField.Type == esriFieldType.esriFieldTypeDouble
                        || pField.Type == esriFieldType.esriFieldTypeSingle || pField.Type == esriFieldType.esriFieldTypeSmallInteger)
                    {
                        comboBox2.Items.Add(pField.Name);
                    }
                }
            }
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDataStatistics pDs = new DataStatistics();
            pDs.Field = comboBox2.SelectedItem.ToString();
            IFeatureSelection featureSelection = currentFeatureLayer as IFeatureSelection;
            ICursor pCursor = null;
            featureSelection.SelectionSet.Search(null, false, out pCursor);
            pDs.Cursor = pCursor;
            IStatisticsResults pSR = pDs.Statistics;
            count.Text = pSR.Count.ToString();
            min.Text = pSR.Minimum.ToString();
            max.Text = pSR.Maximum.ToString();
            mean.Text = pSR.Mean.ToString();
            std.Text = pSR.StandardDeviation.ToString();
            sum.Text = pSR.Sum.ToString();
        }
    }
}
