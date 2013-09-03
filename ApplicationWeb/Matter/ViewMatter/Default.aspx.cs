using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Highchart.Core;
using Highchart.UI;
using Highchart.Core.Data;
using Highchart.Core.PlotOptions;
using System.Web.UI.DataVisualization.Charting;
using Highchart.Core.Data.Chart;
using System.Collections.ObjectModel;
using System.Collections;
using LitigationDataLogic;
using LitigationClearkLogic;

public partial class Matter_ViewMatter_Default : System.Web.UI.Page
{
    #region   ********  Public Declaration *************************
    DataTable dt = new DataTable();
    MatterDetails MDetails = new MatterDetails();
    Common_Message commessage = new Common_Message();
    MatterView MV = new MatterView();
    SaveMatter SV = new SaveMatter();
    static int EMPID;
    static string USERID;


    DataSet dsSeries = new DataSet();
    ArrayList hidValues11 = new ArrayList();
    ArrayList hidXCategories11 = new ArrayList();
    ArrayList hidValues12 = new ArrayList();

    object[] yValues;
    public object hidValues1;
    object[] yValues2;
    public object hidValues2;
    public string hidXCategories1;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        bindStatic();
    }

    #region******************************Bind Chart*****************************************
    private void bindStatic()
    {
        dsSeries = MDetails.Chart_Data("1");

        if (dsSeries == null) return;

        foreach (DataRow dr in dsSeries.Tables[0].Rows)
        {
            hidXCategories11.Add((dr["stage_type_desc"]));


        }

        foreach (DataRow dr1 in dsSeries.Tables[0].Rows)
        {
            hidValues11.Add(Convert.ToInt64((DateTime.Parse(dr1["exp_start_date"].ToString()).Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds));
            //hidValues11.Add((dr1["exp_start_date"]));
            yValues = hidValues11.ToArray(typeof(string)) as object[];

            //hidValues1 = hidValues1 + dr1["value"].ToString();

        }
        foreach (DataRow dr2 in dsSeries.Tables[0].Rows)
        {

            hidValues12.Add((dr2["weighting"]));
            yValues2 = hidValues12.ToArray(typeof(object)) as object[];
            //hidValues1 = hidValues1 + dr1["value"].ToString();

        }

        //Title
        // CaseChart.Title = new Highchart.Core.Title("Consumo de energia");

        //define Axis

        CaseChart.YAxis.Add(new YAxisItem { title = new Highchart.Core.Title("Matter#") });
        CaseChart.XAxis.Add(new XAxisItem { categories = hidXCategories11.ToArray(typeof(string)) as string[] });

        //Data
        var series = new Collection<Serie>();
        series.Add(new Serie { name = "Matter Summary", data = yValues });
        var series1 = new Collection<Serie>();
        series1.Add(new Serie { name = "Matter Summary", data = yValues2 });
        //  series.Add(new Serie { name = "televis�o", data = new object[] { 4, 6, 7, 7, 8, 13, 11 } });

        //Ploting action
        CaseChart.PlotOptions = new Highchart.Core.PlotOptions.PlotOptionsScatter { dataLabels = new Highchart.Core.PlotOptions.DataLabels { enabled = true } };

        //Customize tooltip
        CaseChart.Tooltip = new ToolTip("this.x +': '+ this.y");

        //Customize legend
        CaseChart.Legend = new Highchart.Core.Legend
        {
            layout = Layout.vertical,
            borderWidth = 3,
            align = Align.right,
            y = 20,
            x = -20,
            verticalAlign = Highchart.Core.VerticalAlign.top,
            shadow = true,
            backgroundColor = "#e3e6be"
        };

        //bind datacontrol
        CaseChart.DataSource = series;
        CaseChart.DataBind();
        CaseChart.DataSource = series1;
        CaseChart.DataBind();
    }
    #endregion
}