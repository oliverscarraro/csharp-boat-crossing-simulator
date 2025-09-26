using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBL_2024
{
    public partial class Gráfico_Resultado : Form
    {
        //Trazendo os resultados do Form1
        private double tempoTravessia, tempoTravessiaMin, tempPerpen,
            coordenadaX, coordenadaY, distanciaTotal,
            angResGrau, AngGrauTravessiaPerpen;

        private void Gráfico_Resultado_Load_1(object sender, EventArgs e)
        {
            txt_1.Text = $"{tempoTravessia:F2}";
            txt_2.Text = $"({coordenadaX:F0}, {coordenadaY:F0})";
            txt_3.Text = $"{distanciaTotal:F2}";
            txt_4.Text = $"{angResGrau:F2}°";
            DesenharGrafico();
        }

        private List<PointF> pontos = new List<PointF>();

        private void lb_1_Click(object sender, EventArgs e)
        {
            KineBoat.formStatic.WindowState = FormWindowState.Maximized;

            this.Close();
        }
        public Gráfico_Resultado(double tempTrav, double tempTravMin, double tempPerpen, List<PointF> points, double distT, double angR, double angP)
        {
            InitializeComponent();

            this.tempoTravessia = tempTrav;
            this.tempoTravessiaMin = tempTravMin;
            this.tempPerpen = tempPerpen;
            this.distanciaTotal = distT;
            this.pontos = points;
            this.coordenadaX = pontos.Last().X;
            this.coordenadaY = pontos.Last().Y;
            this.angResGrau = angR;
            this.AngGrauTravessiaPerpen = angP;
        }

        private void DesenharGrafico()
        {
            float CalcularIntervaloAmigavel(double min, double max, int maxMarcasDesejadas = 10)
            {
                double range = Math.Abs(max - min);

                // Calcula um intervalo ideal aproximado
                double intervaloBruto = range / maxMarcasDesejadas;

                // Ajusta o intervalo para valores amigáveis (múltiplos de 1, 2, 5 ou 10)
                float potenciaBase = (float)Math.Pow(10, Math.Floor(Math.Log10(intervaloBruto)));

                if (intervaloBruto <= potenciaBase)
                    return potenciaBase;
                if (intervaloBruto <= 2 * potenciaBase)
                    return 2 * potenciaBase;
                if (intervaloBruto <= 5 * potenciaBase)
                    return 5 * potenciaBase;

                return 10 * potenciaBase;
            }

            // Limpa o gráfico inicial
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            // Cria a área do gráfico
            ChartArea CA = chart1.ChartAreas.Add("CA");
            Series S1 = chart1.Series.Add("S1");
            S1.ChartType = SeriesChartType.Point;

            // Adiciona os pontos
            foreach (PointF ponto in pontos)
                S1.Points.AddXY(ponto.X, ponto.Y);

            // ___EIXO X___ 
            // Calcula os limites arredondados para o eixo X
            float minX = (float)Math.Floor(pontos.Select(p => p.X).Min());
            float maxX = (float)Math.Ceiling(pontos.Select(p => p.X).Max());

            // Ajusta os valores do eixo para intervalos amigáveis
            float intervaloX = CalcularIntervaloAmigavel(minX, maxX);

            // Ajusta o mínimo e máximo do eixo X com base no intervalo
            CA.AxisX.Interval = intervaloX;
            CA.AxisX.Minimum = Math.Floor(minX / intervaloX) * intervaloX;
            CA.AxisX.Maximum = Math.Ceiling(maxX / intervaloX) * intervaloX;

            // Formata os rótulos para evitar muitas casas decimais
            CA.AxisX.LabelStyle.Format = intervaloX < 1 ? "F1" : "F0";

            // Configura o título do eixo X
            CA.AxisX.Title = "Coordenada X (m)";
            CA.AxisX.TitleFont = new Font("Georgia", 12, FontStyle.Bold); // Fonte personalizada
            CA.AxisX.TitleForeColor = Color.Black; // Cor do título

            // ___EIXO Y___
            double intervaloY = CalcularIntervaloAmigavel(CA.AxisY.Minimum, CA.AxisY.Maximum);

            CA.AxisY.Interval = intervaloY;
            CA.AxisY.Minimum = Math.Floor(pontos.Select(p => p.Y).Min() / intervaloY) * intervaloY;
            CA.AxisY.Maximum = Math.Ceiling(pontos.Select(p => p.Y).Max() / intervaloY) * intervaloY;

            // Configura o título do eixo Y
            CA.AxisY.Title = "Coordenada Y (m)";
            CA.AxisY.TitleFont = new Font("Georgia", 12, FontStyle.Bold); // Fonte personalizada
            CA.AxisY.TitleForeColor = Color.Black; // Cor do título


            // ___ADICIONAIS___
            // Configura a origem em (0,0)
            CA.AxisX.Crossing = 0; // Faz o eixo X cruzar no valor Y=0
            CA.AxisY.Crossing = 0; // Faz o eixo Y cruzar no valor X=0

            // Melhora a aparência das grades
            CA.AxisX.MajorGrid.LineColor = Color.LightGray;
            CA.AxisY.MajorGrid.LineColor = Color.LightGray;
            CA.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            CA.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            // Remove intervalos automáticos extras
            CA.AxisX.IsMarginVisible = false;
            CA.AxisY.IsMarginVisible = false;
        }
    }
}
