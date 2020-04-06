using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MarkovChains
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            State _start = new State();
            State _master1 = new State();
            State _master2 = new State();
            State _master3 = new State();
            State _check = new State();
            State _defect = new State();
            State _painting = new State();
            State _color1 = new State();
            State _color2 = new State();
            State _color3 = new State();
            State _finished = new State();

            _start.Add(_master1, 0.5f);
            _start.Add(_master2, 0.3f);
            _start.Add(_master3, 0.2f);
            _master1.Add(_master2, 0.1f);
            _master1.Add(_check, 0.9f);
            _master2.Add(_master2, 0.2f);
            _master2.Add(_check, 0.8f);
            _master3.Add(_master3, 0.2f);
            _master3.Add(_check, 0.8f);
            _check.Add(_master1, 0.05f);
            _check.Add(_defect, 0.05f);
            _check.Add(_painting, 0.9f);
            _defect.Add(_defect, 1f);
            _painting.Add(_color1, 0.5f);
            _painting.Add(_color2, 0.4f);
            _painting.Add(_finished, 0.1f);
            _color1.Add(_finished, 1f);
            _color2.Add(_color3, 1f);
            _color3.Add(_finished, 1f);

            chart1.Series.Clear();
            //AddGraph(chart1, "Start");
            AddGraph(chart1, "Master1");
            AddGraph(chart1, "Master2");
            AddGraph(chart1, "Master3");
            AddGraph(chart1, "Check");
            AddGraph(chart1, "Defect");
            AddGraph(chart1, "Color1");
            AddGraph(chart1, "Color2");
            AddGraph(chart1, "Color3");
            //AddGraph(chart1, "Finished");

            for (int i = 0; i < 120; i++)
            {
                /*MessageBox.Show($"_start: {_start.Count}; _master1: {_master1.Count}; _master2: {_master2.Count}; _master3: {_master3.Count};\n" +
                    $"_check: {_check.Count}; _defect: {_defect.Count}; _painting: {_painting.Count}; _color1: {_color1.Count};\n" +
                    $"_color2: {_color2.Count}; _color3: {_color3.Count}; _finished: {_finished.Count}", "Begin:");*/

                //AddPoints(chart1, "Start", i, _start.Count);
                AddPoints(chart1, "Master1", i, _master1.Count);
                AddPoints(chart1, "Master2", i, _master2.Count);
                AddPoints(chart1, "Master3", i, _master3.Count);
                AddPoints(chart1, "Check", i, _check.Count);
                AddPoints(chart1, "Defect", i, _defect.Count);
                AddPoints(chart1, "Color1", i, _color1.Count);
                AddPoints(chart1, "Color2", i, _color2.Count);
                AddPoints(chart1, "Color3", i, _color3.Count);
                //AddPoints(chart1, "Finished", i, _finished.Count);

                _start.Count += 100;
                _color3.Next();
                _color2.Next();
                _color1.Next();
                _defect.Next();
                _check.Next();
                _painting.Next();
                _master3.Next();
                _master2.Next();
                _master1.Next();
                _start.Next();
            }
        }

        public static void AddGraph(Chart chart, string name)
        {
            chart.Series.Add(name);
            chart.Series[name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.
            FastLine;
            chart.Series[name].BorderWidth = 1;
        }

        public static void AddPoints(Chart chart, string name, int i, int count)
        {
            chart.Series[name].Points.AddXY(i, count);
        }
    }
}
