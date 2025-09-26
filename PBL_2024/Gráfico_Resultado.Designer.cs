namespace PBL_2024
{
    partial class Gráfico_Resultado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gráfico_Resultado));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pn_Resultados = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.pn_Resultados.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(496, 90);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(797, 421);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(172)))), ((int)(((byte)(170)))));
            this.label12.Font = new System.Drawing.Font("Footlight MT Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(88, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 32);
            this.label12.TabIndex = 0;
            this.label12.Text = "Resultados";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.label11.Location = new System.Drawing.Point(16, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(175, 18);
            this.label11.TabIndex = 1;
            this.label11.Text = "Tempo de travessia (s):";
            // 
            // txt_1
            // 
            this.txt_1.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_1.Enabled = false;
            this.txt_1.Font = new System.Drawing.Font("Georgia", 15F);
            this.txt_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_1.Location = new System.Drawing.Point(223, 148);
            this.txt_1.Name = "txt_1";
            this.txt_1.ReadOnly = true;
            this.txt_1.Size = new System.Drawing.Size(73, 30);
            this.txt_1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.label3.Location = new System.Drawing.Point(16, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Coordenada final (x,y):";
            // 
            // txt_2
            // 
            this.txt_2.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_2.Enabled = false;
            this.txt_2.Font = new System.Drawing.Font("Georgia", 15F);
            this.txt_2.Location = new System.Drawing.Point(223, 200);
            this.txt_2.Name = "txt_2";
            this.txt_2.ReadOnly = true;
            this.txt_2.Size = new System.Drawing.Size(73, 30);
            this.txt_2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.label4.Location = new System.Drawing.Point(16, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Deslocamento total (m):";
            // 
            // txt_3
            // 
            this.txt_3.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_3.Enabled = false;
            this.txt_3.Font = new System.Drawing.Font("Georgia", 15F);
            this.txt_3.Location = new System.Drawing.Point(223, 254);
            this.txt_3.Name = "txt_3";
            this.txt_3.ReadOnly = true;
            this.txt_3.Size = new System.Drawing.Size(73, 30);
            this.txt_3.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.label5.Location = new System.Drawing.Point(16, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ângulo resultante (graus):";
            // 
            // txt_4
            // 
            this.txt_4.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_4.Enabled = false;
            this.txt_4.Font = new System.Drawing.Font("Georgia", 15F);
            this.txt_4.Location = new System.Drawing.Point(223, 310);
            this.txt_4.Name = "txt_4";
            this.txt_4.ReadOnly = true;
            this.txt_4.Size = new System.Drawing.Size(73, 30);
            this.txt_4.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 14F);
            this.label6.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.label6.Location = new System.Drawing.Point(26, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(225, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Resultados da simulação:";
            // 
            // pn_Resultados
            // 
            this.pn_Resultados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(150)))), ((int)(((byte)(148)))));
            this.pn_Resultados.Controls.Add(this.label6);
            this.pn_Resultados.Controls.Add(this.txt_4);
            this.pn_Resultados.Controls.Add(this.label5);
            this.pn_Resultados.Controls.Add(this.txt_3);
            this.pn_Resultados.Controls.Add(this.label4);
            this.pn_Resultados.Controls.Add(this.txt_2);
            this.pn_Resultados.Controls.Add(this.label3);
            this.pn_Resultados.Controls.Add(this.txt_1);
            this.pn_Resultados.Controls.Add(this.label11);
            this.pn_Resultados.Controls.Add(this.label12);
            this.pn_Resultados.Location = new System.Drawing.Point(71, 90);
            this.pn_Resultados.Name = "pn_Resultados";
            this.pn_Resultados.Size = new System.Drawing.Size(325, 421);
            this.pn_Resultados.TabIndex = 9;
            // 
            // Gráfico_Resultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 679);
            this.Controls.Add(this.pn_Resultados);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1364, 718);
            this.Name = "Gráfico_Resultado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resultado Gráfico";
            this.Load += new System.EventHandler(this.Gráfico_Resultado_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.pn_Resultados.ResumeLayout(false);
            this.pn_Resultados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txt_1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txt_2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txt_3;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txt_4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pn_Resultados;
    }
}