using ResearchSchema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Lab04_DUCHP
{
    public partial class Form1 : Form
    {
        public int jIndex = 0;
        private ZedGraphControl zedGraph1;
        int xPlotSize = 500;
        int yPlotSize = 300;


        public Form1()
        {
            InitializeComponent();

            zedGraph1 = new ZedGraphControl();
            zedGraph1.Location = new Point(250, 20);
            zedGraph1.Size = new Size(xPlotSize, yPlotSize);

            this.Controls.Add(zedGraph1);

        }

        private void drawGraph(ZedGraphControl zedGraph, PointPairList list, string xTitle, string yTitle, string tableName)
        {
            GraphPane pane = zedGraph.GraphPane;
            //pane.CurveList.Clear();
            Color color;
            pane.XAxis.Title.Text = xTitle;
            pane.YAxis.Title.Text = yTitle;
            pane.Title.Text = tableName;
            if (jIndex % 2 == 0)
                color = Color.Blue;
            else
                color = Color.Red;
            LineItem Curve = pane.AddCurve("", list, color, SymbolType.None);
            Curve.Line.IsSmooth = true;
            //pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;
            zedGraph.Refresh();
            zedGraph.AxisChange();
            zedGraph.Invalidate();
            jIndex++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SchemaDataMethod data = new SchemaDataMethod();
            try
            {
                data.k0 = double.Parse(textKbegin.Text);
                data.kN = double.Parse(textKend.Text);
                data.alpha0 = double.Parse(textAlphaBegin.Text);
                data.alphaN = double.Parse(textAlphaEnd.Text);
                data.L = double.Parse(textL.Text);
                data.t0 = double.Parse(textT0.Text);
                data.R = double.Parse(textR.Text);
                data.F0 = double.Parse(textF0.Text);
            }
            catch
            {
                throw new FormatException();
            }
            List<PointPairList> lst = Research.computeResult(data);
            string yTitle = "T, K";
            string xTitle = "t, c";
            string tableName = "График температурного поля вдоль стержня";
            List<PointPairList> lst1 = new List<PointPairList>();

            double tau = 1e-1;
            //int k = 0;
            for (int i = 0; i < lst[0].Count; i++)
            {
                if (i % 50 == 0)
                {
                    PointPairList tmp1 = new PointPairList();
                    for (int j = 0; j < lst.Count; j++)
                    {

                        tmp1.Add(j * tau, lst[j][i].Y);

                    }
                    lst1.Add(tmp1);
                }
            }


            for (int i = 0; i < lst1.Count; i ++)
            {
                //if (i % 50 == 0)
                    drawGraph(zedGraph1, lst1[i], xTitle, yTitle, tableName);
                //else
                  //  drawGraph(zedGraph1, lst[i], xTitle, yTitle, tableName, Color.Red);

            }
                

            

        }
    }
}
