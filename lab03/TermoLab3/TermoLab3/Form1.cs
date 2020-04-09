using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ResearchSchemaODU;
using ZedGraph;

namespace TermoLab3
{
    public partial class Form1 : Form
    {
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
            pane.CurveList.Clear();

            pane.XAxis.Title.Text = xTitle;
            pane.YAxis.Title.Text = yTitle;
            pane.Title.Text = tableName;

            LineItem Curve = pane.AddCurve("func", list, Color.Red, SymbolType.None);
            Curve.Line.IsSmooth = true;
            zedGraph.Refresh();
            zedGraph.AxisChange();
            zedGraph.Invalidate();
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
            ResearchSchemaODU.Research.coumputeResult(data);
            string yTitle = "T, K";
            string xTitle = "x, см";
            string tableName = "График температурного поля вдоль стержня";
            drawGraph(zedGraph1, data.list1, xTitle, yTitle, tableName);

        }
    }
}
