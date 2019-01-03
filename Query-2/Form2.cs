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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        #region 定义变量
        private IMap currentMap;
        private IFeatureLayer currentFeatureLayer;
        private string currentFieldName;
        public IMap CurrentMap
        {
            //当前axmapc中的imap
            set
            {
                currentMap = value;
            }
        }
        #endregion

        private void UniqueList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            get_Unique.Enabled = false;
            comboBox1.Items.Clear();
            string layerName;
            for (int i = 0; i < currentMap.LayerCount; i++)
            {
                if (currentMap.get_Layer(i) is FeatureLayer)
                {
                    //如果图层是图层组类型
                    if (currentMap.get_Layer(i) is GroupLayer)
                    {
                        ICompositeLayer pCompositeLayer = currentMap.get_Layer(i) as ICompositeLayer;
                        for (int j = 0; j < pCompositeLayer.Count; j++)
                        {
                            layerName = pCompositeLayer.get_Layer(j).Name;
                            comboBox1.Items.Add(layerName);
                        }
                    }
                    //一般图层的情况
                    else
                    {
                        layerName = currentMap.get_Layer(i).Name;
                        comboBox1.Items.Add(layerName);
                    }
                }
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
        //而无法
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string layerName;
            comboBox1.Items.Clear();
            if (checkBox1.CheckState == CheckState.Checked)
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
                                comboBox1 .Items.Add(layerName);
                                comboBox1.Refresh();
                            }
                        }
                        else
                        {
                            layerName = currentMap.get_Layer(i).Name;
                            comboBox1.Items.Add(layerName);
                            comboBox1.Refresh();
                        }
                    }
                }
            }
            //未勾选时
            if (checkBox1.CheckState == CheckState.Unchecked)
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
                                comboBox1.Items.Add(layerName);
                                comboBox1.Refresh();
                            }
                        }
                        else
                        {
                            layerName = currentMap.get_Layer(i).Name;
                            comboBox1.Items.Add(layerName);
                            comboBox1.Refresh();
                        }
                    }
                }
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AttList.Items.Clear();
            UniqueList.Items.Clear();
            IField pFielf;
            
            //找到和combox中一致的图层
            for (int i = 0; i < currentMap.LayerCount; i++)
            {
                //如果图层是图层组类型
                if (currentMap.get_Layer(i) is GroupLayer)
                {
                    ICompositeLayer pCompositeLayer = currentMap.get_Layer(i) as ICompositeLayer;
                    for (int j = 0; j < pCompositeLayer.Count; j++)
                    {
                        if (pCompositeLayer.get_Layer(j).Name == comboBox1.Text)
                        {
                            currentFeatureLayer = pCompositeLayer.get_Layer(i) as IFeatureLayer;
                            break;
                        }
                    }
                }
                //一般图层的情况
                else
                {
                    if (currentMap.get_Layer(i).Name == comboBox1.Text)
                    {
                        currentFeatureLayer = currentMap.get_Layer(i) as IFeatureLayer;
                        break;
                    }
                }
            }

            //遍历属性，填充attList
            for (int i = 0; i < currentFeatureLayer.FeatureClass.Fields.FieldCount; i++)
            {
                pFielf = currentFeatureLayer.FeatureClass.Fields.get_Field(i);
                if (pFielf.Name.ToUpper() != "SHAPE")
                {
                    //写sql语句时需要将属性加上""，转义就写成："\""
                    AttList.Items.Add("\"" + pFielf.Name + "\"");
                }
            }
            label3.Text = "STELCT * FROM " + currentFeatureLayer.Name + " WHERE:";
            SQLText.Clear();
        }

        //点击属性名时改变当前字段的值
        private void AttList_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_Unique.Enabled = true;
            UniqueList.Items.Clear();
            string str = AttList.SelectedItem.ToString();
            str = str.Substring(1);
            str = str.Substring(0, str.Length - 1);
            currentFieldName = str;
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            SelectFeatureByAtt();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            SelectFeatureByAtt();
            this.Close();
        }

        private void get_Unique_Click(object sender, EventArgs e)
        {
            UniqueList.Items.Clear();
            try
            {
                /*IDataset pDataset = (IDataset)currentFeatureLayer.FeatureClass;
                //IQueryDef接口定义查询信息
                IQueryDef pQueryDef = ((IFeatureWorkspace)pDataset.Workspace).CreateQueryDef();
                //查询的表格名称
                pQueryDef.Tables = pDataset.Name;
                //SQL中distinct用来查询唯一值
                pQueryDef.SubFields = "distinct "+currentFieldName;
                ICursor pCursor = pQueryDef.Evaluate();
                IFields pFields = currentFeatureLayer.FeatureClass.Fields;
                IField pField = pFields.get_Field(pFields.FindField(currentFieldName));

                IRow pRow = pCursor.NextRow();
                while (pRow != null)
                {
                    //string类型的字段sql查询时需要加单引号
                    if (pField.Type == esriFieldType.esriFieldTypeString)
                        UniqueList.Items.Add("\'" + pRow.get_Value(0).ToString() + "\'");
                    else
                        UniqueList.Items.Add(pRow.get_Value(0).ToString());
                     pRow= pCursor.NextRow();
                }*/
                
                IQueryFilter pQF = new QueryFilterClass();
                pQF.SubFields = currentFieldName;
                IFeatureCursor pFC = currentFeatureLayer.FeatureClass.Search(pQF, false);
                IDataStatistics pDS = new DataStatisticsClass();
                pDS.Field = currentFieldName;
                pDS.Cursor = pFC as ICursor;
                
                //此处初始化IField的目的是为了判断属性的类别string或者double
                IFields pFields = currentFeatureLayer.FeatureClass.Fields;
                IField pField = pFields.get_Field(pFields.FindField(currentFieldName));

                System.Collections.IEnumerator pEnum = pDS.UniqueValues;
                pEnum.Reset();
                while (pEnum.MoveNext())
                {
                    if( pField.Type==esriFieldType.esriFieldTypeString)
                        UniqueList.Items.Add("\'" +pEnum.Current.ToString()+ "\'");
                    else
                        UniqueList.Items.Add( pEnum.Current.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region 查找条件输入
        private void button1_Click(object sender, EventArgs e)
        {
            SQLText.AppendText("= ");
        }

        private void UniqueList_DoubleClick(object sender, EventArgs e)
        {
            SQLText.AppendText(UniqueList.SelectedItem.ToString());
        }

        private void AttList_DoubleClick(object sender, EventArgs e)
        {
            SQLText.AppendText(AttList.SelectedItem.ToString()+" ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLText.AppendText("<> ");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLText.AppendText("Like ");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SQLText.AppendText("> ");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SQLText.AppendText(">= ");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SQLText.AppendText("And ");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SQLText.AppendText("< ");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SQLText.AppendText("<= ");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SQLText.AppendText("Or ");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SQLText.AppendText("_ ");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SQLText.AppendText("% ");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SQLText.AppendText("() ");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SQLText.AppendText("Not ");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SQLText.AppendText("Is ");
        }
        #endregion

        #region 属性查找
        private void SelectFeatureByAtt()
        {
            IFeatureSelection pFeatureSelection = currentFeatureLayer as IFeatureSelection;
            IQueryFilter pQF = new QueryFilterClass();
            pQF.WhereClause=SQLText.Text;
            IActiveView activeView = currentMap as IActiveView;

            switch (comboBox2.SelectedIndex)
            {
                //新建选择集的情况
                case 0:
                    currentMap.ClearSelection();
                    pFeatureSelection.SelectFeatures(pQF, esriSelectionResultEnum.esriSelectionResultNew, false);
                    break;
                //添加到当前选择集
                case 1:
                    pFeatureSelection.SelectFeatures(pQF, esriSelectionResultEnum.esriSelectionResultAdd, false);
                    break;
                //从当前选择集中删除
                case 2:
                    pFeatureSelection.SelectFeatures(pQF, esriSelectionResultEnum.esriSelectionResultXOR, false);
                    break;
                //从当前选择集中选择
                case 3:
                    pFeatureSelection.SelectFeatures(pQF, esriSelectionResultEnum.esriSelectionResultAnd, false);
                    break;
                //默认新建选择集
                default:
                     currentMap.ClearSelection();
                    pFeatureSelection.SelectFeatures(pQF, esriSelectionResultEnum.esriSelectionResultNew, false);
                    break;
            }
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, activeView.Extent);
        }
        #endregion


    }
}