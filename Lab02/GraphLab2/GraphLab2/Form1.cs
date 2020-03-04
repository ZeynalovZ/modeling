using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ZedGraph;
using SchemaResearch;

namespace GraphLab2
{

    public partial class Form1 : Form
    {
        private ZedGraphControl zedGraph1;
        private ZedGraphControl zedGraph2;
        private ZedGraphControl zedGraph3;
        private ZedGraphControl zedGraph4;
        private ZedGraphControl zedGraph5;
        private readonly int xPlotSize = 400;
        private readonly int yPlotSize = 300;
        public Form1()
        {
            InitializeComponent();

            this.Width = 1000;
            this.Height = 600;

            zedGraph1 = new ZedGraphControl();
            zedGraph1.Location = new Point(20, 20);
            zedGraph1.Size = new Size(xPlotSize, yPlotSize);

            zedGraph2 = new ZedGraphControl();
            zedGraph2.Location = new Point(430, 20);
            zedGraph2.Size = new Size(xPlotSize, yPlotSize);

            zedGraph3 = new ZedGraphControl();
            zedGraph3.Location = new Point(840, 20);
            zedGraph3.Size = new Size(xPlotSize, yPlotSize);

            zedGraph4 = new ZedGraphControl();
            zedGraph4.Location = new Point(20, 330);
            zedGraph4.Size = new Size(xPlotSize, yPlotSize);

            zedGraph5 = new ZedGraphControl();
            zedGraph5.Location = new Point(430, 330);
            zedGraph5.Size = new Size(xPlotSize, yPlotSize);

            this.Controls.Add(zedGraph1);
            this.Controls.Add(zedGraph2);
            this.Controls.Add(zedGraph3);
            this.Controls.Add(zedGraph4);
            this.Controls.Add(zedGraph5);
        }

        private double f(double x)
        {
            return Math.Sin(x);
        }

        private void drawGraph1(ZedGraphControl zedGraph, PointPairList list, string xTitle, string yTitle, string tableName)
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
            PointPairList list = new PointPairList();
            for (double x = -50; x < 50; x += 0.01)
            {
                list.Add(x, f(x));
            }
            double R = double.Parse(textR.Text);
            double Tw = double.Parse(textTw.Text);
            double Ck = double.Parse(textCk.Text);
            double Lk = double.Parse(textLk.Text);
            double Rk = double.Parse(textRk.Text);
            double Uc0 = double.Parse(textUc0.Text);
            double I0 = double.Parse(textI0.Text);
            double L0 = double.Parse(textL0.Text);
            // work with steps
            double Tbegin = double.Parse(textTbeg.Text);
            double Tend = double.Parse(textTend.Text);
            double Tstep = double.Parse(textTstep.Text);
            ResearchConfiguration config = new ResearchConfiguration(R, Tw, Ck * 1e-6, Lk * 1e-6, Rk, Uc0, I0, L0);
            config.setTimeTable(Tbegin, Tend, Tstep);
            config = Research.computeResult(config);
            string xTitle = "t, микросекунды";
            string yTitle = "I, A";
            string tableName = "Зависимость силы тока от времени";
            drawGraph1(zedGraph1, config.list1, xTitle, yTitle, tableName);
            xTitle = "t, микросекунды";
            yTitle = "U, B";
            tableName = "Зависимость напряжения от времени";
            drawGraph1(zedGraph2, config.list2, xTitle, yTitle, tableName);
            xTitle = "t, микросекунды";
            yTitle = "I * Rp, A";
            tableName = "Доп График";
            drawGraph1(zedGraph3, list, xTitle, yTitle, tableName);
            xTitle = "t, микросекунды";
            yTitle = "I * Rp, A";
            tableName = "Еще график";
            drawGraph1(zedGraph4, list, xTitle, yTitle, tableName);
            
        }

    }
}
