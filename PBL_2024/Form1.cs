using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL_2024
{
    public partial class KineBoat : Form
    {
        //Declarando componentes vitais para a animação (dicionario dos frames e timer):
        private List<Image> frames = new List<Image>();
        private int currentFrame = 0;
        private Timer animationTimer;

        //Declaração de de outras variáveis
        private string caminhoFinal = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SimulaçõesPBL");
        private bool camposCalculados = false;

        //Criando referecia para o desse form para outro
        public static KineBoat formStatic = null;

        //CÁLCULO ------------------------------------------------------------------------------------------------------

        //declaração de variáveis do cálculo:
        private double vRel, vArr, tempoTravessia, tempoTravessiaMin, tempPerpen,
            coordenadaX, coordenadaY, distanciaTotal,
            angResGrau, AngRadTravessiaPerpen, AngGrauTravessiaPerpen;

        private List<PointF> pontos = new List<PointF>();

        public KineBoat()
        {
            InitializeComponent();

            //ajuda a combater o flickering (piscadas irritantes que podem surgir)
            this.DoubleBuffered = true;

            //chama a função da animação
            LoadFrames();

            //cria o timer
            animationTimer = new Timer();
            animationTimer.Interval = 150; // Define intervalo de 150 ms entre cada frame
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();

            //para o usuário teclar enter e ir para a proxima pergunta
            txt_R1.KeyDown += EnterConfirmar;
            txt_R2.KeyDown += EnterConfirmar;
            txt_R3.KeyDown += EnterConfirmar;
            txt_R4.KeyDown += EnterConfirmar;

            // seleciona arquivos
            if (!Directory.Exists(caminhoFinal))
            {
                Directory.CreateDirectory(caminhoFinal);
            }
            else
            {
                string[] Arquivos = Directory.GetFiles(caminhoFinal);

                foreach (string arquivo in Arquivos)
                {
                    lsb_Historico.Items.Add(Path.GetFileName(arquivo));
                }
            }

            foreach (Control control in tlp1_LimitarDados.Controls)
            {
                if (control is TextBox textBox)
                {
                    // Armazena o valor inicial na propriedade Tag
                    textBox.Tag = textBox.Text;
                }
            }


            foreach (Control control in tlp1_LimitarDados.Controls)
            {
                if (control is TextBox textBox)
                {
                    string placeholder = textBox.Text;

                    textBox.ForeColor = Color.Gray;

                    textBox.Enter += (sender, e) =>
                    {
                        if (textBox.ForeColor == Color.Gray)
                        {
                            textBox.Text = string.Empty;
                            textBox.ForeColor = Color.Black;
                        }
                    };

                    textBox.Leave += (sender, e) =>
                    {
                        if (string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            textBox.Text = placeholder;
                            textBox.ForeColor = Color.Gray;

                        }
                    };
                }
            }
        }

        //função que adiciona cada foto (ou frame) ao dicionário criado
        private void LoadFrames()
        {
            // Adiciona cada frame dos recursos na lista de frames (os frames eu exportei do blender e joguei eles na parte dos recursos dessa solução)
            frames.Add(Properties.Resources._0001);
            frames.Add(Properties.Resources._0002);
            frames.Add(Properties.Resources._0003);
            frames.Add(Properties.Resources._0004);
            frames.Add(Properties.Resources._0005);
            frames.Add(Properties.Resources._0006);
            frames.Add(Properties.Resources._0007);
            frames.Add(Properties.Resources._0008);
            frames.Add(Properties.Resources._0009);
            frames.Add(Properties.Resources._0010);
            frames.Add(Properties.Resources._0011);
            frames.Add(Properties.Resources._0012);
            frames.Add(Properties.Resources._0013);
            frames.Add(Properties.Resources._0014);
            frames.Add(Properties.Resources._0015);
            frames.Add(Properties.Resources._0016);
            frames.Add(Properties.Resources._0017);
            frames.Add(Properties.Resources._0018);
            frames.Add(Properties.Resources._0019);
            frames.Add(Properties.Resources._0020);
            frames.Add(Properties.Resources._0021);
            frames.Add(Properties.Resources._0022);
            frames.Add(Properties.Resources._0023);
            frames.Add(Properties.Resources._0024);
            frames.Add(Properties.Resources._0025);
            frames.Add(Properties.Resources._0026);
            frames.Add(Properties.Resources._0027);
            frames.Add(Properties.Resources._0028);
            frames.Add(Properties.Resources._0029);
            frames.Add(Properties.Resources._0030);
        }

        //função que referente ao timer da animação:
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (frames.Count == 0) return;

            // Define o próximo quadro como fundo do formulário
            this.BackgroundImage = frames[currentFrame];
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Avança para o próximo quadro
            currentFrame = (currentFrame + 1) % frames.Count; // Loop infinito
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //esconde o panel de calculo no inicio:
            pn_Calcular.Hide();

            //esconde o panel de historico no inicio:
            pn_Historico.Hide();

            //esconde o panel de resultados no inicio:
            pn_Resultados.Hide();
        }

        //função referente ao botão Limpar dados:
        private void lb_3_Click(object sender, EventArgs e)
        {
            txt_R1.Text = string.Empty;
            txt_R2.Text = string.Empty;
            txt_R3.Text = string.Empty;
            txt_R4.Text = string.Empty;

            camposCalculados = false;
        }

        #region Funções Referentes aos botões de início

        private void lb_1_Click(object sender, EventArgs e)
        {
            Showpn_Calcular();
        }

        //função que controla a exibição do panel de cálculo:
        private void Showpn_Calcular()
        {
            // Oculta o painel de conteúdo se já estiver visível
            if (pn_Calcular.Visible)
            {
                pn_Calcular.Visible = false;
            }
            else
            {
                // Se não estiver visível, mostre
                pn_Calcular.Visible = true;
            }
        }

        private void lb_4_Click(object sender, EventArgs e)
        {
            Showpn_Historico();
        }

        //Função para exibir o panel de historico
        private void Showpn_Historico()
        {
            if (pn_Historico.Visible)
            {
                pn_Historico.Visible = false;
            }
            else
            {
                pn_Historico.Visible = true;
            }
        }

        //Evento de clique do botão Salvar dados:
        private void lb_2_Click(object sender, EventArgs e)
        {
            SaveFileDialog salvarCadastro = criarSaveDialogBox();

            if (!string.IsNullOrEmpty(txt_R1.Text) && !string.IsNullOrEmpty(txt_R4.Text)
                && !string.IsNullOrEmpty(txt_R3.Text) && !string.IsNullOrEmpty(txt_R2.Text))
            {
                SalvarDados(salvarCadastro);
            }
            else
            {
                MessageBox.Show("Preencha todos os campos para salvar!");
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            pn_Resultados.Visible = false;
        }

        #endregion

        #region Painel Calcular

        //Clique do botão exibir resultado:
        private void btn_Calcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_R1.Text) || string.IsNullOrEmpty(txt_R2.Text) ||
                    string.IsNullOrEmpty(txt_R3.Text) || string.IsNullOrEmpty(txt_R4.Text))
                    throw new Exception("Campos vazios. Insira valores válidos.");

                // Converte os valores das caixas de seleção para números
                double largura = Convert.ToDouble(txt_R1.Text);
                vRel = Convert.ToDouble(txt_R2.Text);
                vArr = Convert.ToDouble(txt_R3.Text);
                double angBarcoMargemGrau = Convert.ToDouble(txt_R4.Text);

                bool OutOfRange(double valor, double min, double max) => (valor < min) || (valor > max);

                if (OutOfRange(largura, 20, 100) || OutOfRange(vRel, 2, 10) ||
                    OutOfRange(vArr, 1, 4) || OutOfRange(angBarcoMargemGrau, 20, 160))
                    throw new Exception("Dados inválidos. Insira valores válidos");

                // Caso os valores forem válidos, calcula os resultados
                calcularResultados(largura, vRel, vArr, angBarcoMargemGrau);

                //esconde esse form
                formStatic = this;

                //coloca o novo form em tela cheia e exibe
                pn_Resultados.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (vRel < vArr)
            {
                label8.Visible = true;
                txt_5.Visible = true;

                label9.Visible = false;
                label10.Visible = false;

                txt_6.Visible = false;
                txt_7.Visible = false;

                lbl_textoinfoPerpen.Visible = true;
                lbl_VelocidadesIguais.Visible = false;
            }
            else if (vRel == vArr)
            {
                label8.Visible = true;
                txt_5.Visible = true;

                label9.Visible = false;
                label10.Visible = false;

                txt_6.Visible = false;
                txt_7.Visible = false;

                lbl_VelocidadesIguais.Visible = true;
                lbl_textoinfoPerpen.Visible = false;
            }
            else
            {
                label9.Visible = true;
                label10.Visible = true;

                txt_6.Visible = true;
                txt_7.Visible = true;

                lbl_VelocidadesIguais.Visible = false;
                lbl_textoinfoPerpen.Visible = false;
            }

            if (txt_4.Text == "90,00" || txt_4.Text == "90")
            {
                label8.Visible = true;
                txt_5.Visible = true;

                label9.Visible = false;
                label10.Visible = false;

                txt_6.Visible = false;
                txt_7.Visible = false;

                lbl_infoTravessiaJaPerpen.Visible = true;
            }
            else
            {

                lbl_infoTravessiaJaPerpen.Visible = false;
            }

            string input = txt_R4.Text.Replace(',', '.');

            // Tenta converter o valor para decimal
            decimal result;

            if (decimal.TryParse(input, out result))
            {
                // Arredonda o valor para duas casas decimais, se necessário
                result = Math.Round(result, 2);

                // Verifica se o valor convertido é igual a 90.00
                if (result == 90.00m)
                {
                    label8.Visible = false;
                    txt_5.Visible = false;
                    lbl_InfoTempMin.Visible = true;
                }
                else
                {
                    lbl_InfoTempMin.Visible = false;
                }
            }
        }

        // Para o enter pressionar o botão de Exibir resultado:
        private void EnterConfirmar(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Calcular_Click(sender, e); // Chama o cálculo ao pressionar Enter
                e.SuppressKeyPress = true;
            }
        }

        #endregion

        #region Painel Histórico

        private void btn_Carregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (pn_Calcular.Visible == false || pn_Resultados.Visible == false)
                {
                    pn_Calcular.Visible = true;
                    pn_Resultados.Visible = true;
                }


                if (lsb_Historico.SelectedItem == null)
                    throw new Exception("Selecione um item do Histórico para realizar essa ação");

                string fileName = lsb_Historico.SelectedItem.ToString(); // Obtém o caminho do arquivo selecionado

                string fileContent = File.ReadAllText(Path.Combine(caminhoFinal, fileName)); // Lê o conteúdo do arquivo

                string[] resultados = fileContent.Split(';');

                // Carrega o conteúdo do arquivo nas TextBoxes (exemplo)
                txt_R1.Text = resultados[0];
                txt_R2.Text = resultados[1];
                txt_R3.Text = resultados[2];
                txt_R4.Text = resultados[3];// Coloca o conteúdo em uma TextBox chamada textBoxContent


                calcularResultados(Double.Parse(resultados[0]), Double.Parse(resultados[1]), Double.Parse(resultados[2]), Double.Parse(resultados[3]));

                txt_1.Text = $"{resultados[4]}";
                txt_2.Text = $"{resultados[5]}, {resultados[6]}";
                txt_3.Text = $"{resultados[7]}";
                txt_4.Text = $"{resultados[8]}° ";
                txt_5.Text = $"{resultados[9]}";
                txt_6.Text = $"{resultados[10]}";
                txt_7.Text = $"{resultados[11]}";

                // habilitar visualização dos resultados
                foreach (Control control in pn_Resultados.Controls)
                    control.Visible = true;

                if (Convert.ToDouble(txt_R2.Text) < Convert.ToDouble(txt_R3.Text))
                {
                    label8.Visible = true;
                    txt_5.Visible = true;

                    label9.Visible = false;
                    label10.Visible = false;

                    txt_6.Visible = false;
                    txt_7.Visible = false;

                    lbl_textoinfoPerpen.Visible = true;
                    lbl_VelocidadesIguais.Visible = false;
                }
                else if (Convert.ToDouble(txt_R2.Text) == Convert.ToDouble(txt_R3.Text))
                {
                    label8.Visible = true;
                    txt_5.Visible = true;

                    label9.Visible = false;
                    label10.Visible = false;

                    txt_6.Visible = false;
                    txt_7.Visible = false;

                    lbl_VelocidadesIguais.Visible = true;
                    lbl_textoinfoPerpen.Visible = false;

                }
                else
                {
                    label9.Visible = true;
                    label10.Visible = true;

                    txt_6.Visible = true;
                    txt_7.Visible = true;

                    lbl_VelocidadesIguais.Visible = false;
                    lbl_textoinfoPerpen.Visible = false;
                }

                if (resultados[8] == "90,00" || resultados[8] == "90")
                {
                    label9.Visible = false;
                    label10.Visible = false;

                    txt_6.Visible = false;
                    txt_7.Visible = false;

                    lbl_infoTravessiaJaPerpen.Visible = true;
                }
                else
                {
                    lbl_infoTravessiaJaPerpen.Visible = false;
                }

                string input = txt_R4.Text.Replace(',', '.');

                // Tenta converter o valor para decimal
                decimal result;

                if (decimal.TryParse(input, out result))
                {
                    // Arredonda o valor para duas casas decimais, se necessário
                    result = Math.Round(result, 2);

                    // Verifica se o valor convertido é igual a 90.00
                    if (result == 90.00m)
                    {
                        label8.Visible = false;
                        txt_5.Visible = false;
                        lbl_InfoTempMin.Visible = true;
                    }
                    else
                    {
                        label8.Visible = true;
                        txt_5.Visible = true;

                        lbl_InfoTempMin.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o arquivo: {ex.Message}");
            }


        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsb_Historico.SelectedItem == null)
                    throw new Exception("Selecione um item do Histórico para realizar essa ação");

                string fileName = lsb_Historico.SelectedItem.ToString(); // Obtém o caminho do arquivo selecionado

                string filePath = Path.Combine(caminhoFinal, fileName); // Lê o conteúdo do arquivo

                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir esse arquivo?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    File.Delete(filePath);

                    lsb_Historico.Items.Remove(lsb_Historico.SelectedItem);
                }
                else
                {
                    MessageBox.Show("Ação cancelada");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar excluir o arquivo: {ex.Message}");
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {
            //cria uma nova instância para exibir o form:
            Gráfico_Resultado graficoForm = new Gráfico_Resultado(tempoTravessia, tempoTravessiaMin, tempPerpen,
            pontos, distanciaTotal,
            angResGrau, AngGrauTravessiaPerpen);

            graficoForm.WindowState = FormWindowState.Maximized;
            graficoForm.Show();            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<string> arquivos = lsb_Historico.Items.Cast<string>().ToList();

                if (comboBox1.SelectedItem.ToString() == "Mais antigo")
                {
                    InsertionSortMaisAntigo(arquivos);
                }
                else if (comboBox1.SelectedItem.ToString() == "Mais recente")
                {
                    InsertionSortMaisRecente(arquivos);
                }

                lsb_Historico.Items.Clear();
                foreach (var arquivo in arquivos)
                {
                    lsb_Historico.Items.Add(arquivo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao ordenar arquivos: {ex.Message}");
            }
        }

        public void InsertionSortMaisAntigo(List<string> lista)
        {
            for (int i = 1; i < lista.Count; i++)
            {
                string key = lista[i];
                int j = i - 1;


                while (j >= 0 && string.Compare(ExtrairDataHora(lista[j]), ExtrairDataHora(key)) > 0)
                {
                    lista[j + 1] = lista[j];
                    j--;
                }
                lista[j + 1] = key;
            }
        }

        public void InsertionSortMaisRecente(List<string> lista)
        {
            for (int i = 1; i < lista.Count; i++)
            {
                string key = lista[i];
                int j = i - 1;


                while (j >= 0 && string.Compare(ExtrairDataHora(lista[j]), ExtrairDataHora(key)) < 0)
                {
                    lista[j + 1] = lista[j];
                    j--;
                }
                lista[j + 1] = key;
            }
        }

        private string ExtrairDataHora(string arquivo)
        {
            string nomeSemExtensao = Path.GetFileNameWithoutExtension(arquivo);

            int index = arquivo.IndexOf("-") + 2;
            return arquivo.Substring(index, 19);
        }

        private void pcb_Funil_Click(object sender, EventArgs e)
        {
            pnl_Filtrar.Visible = !pnl_Filtrar.Visible;
        }

        #endregion

        #region Painel Filtro

        private void btn_AplicarBusca_Click(object sender, EventArgs e)
        {
            try
            {
                double LarguraMin = Convert.ToDouble(txt_LargMin.Text);
                double VbarcoMin = Convert.ToDouble(txt_limVbmin.Text);
                double VcorrentezaMin = Convert.ToDouble(txt_limVcorrmin.Text);
                double AngInicialMin = Convert.ToDouble(txt_Angmin.Text);

                double LarguraMax = Convert.ToDouble(txt_Largmax.Text);
                double VbarcoMax = Convert.ToDouble(txt_limVbmax.Text);
                double VcorrentezaMax = Convert.ToDouble(txt_limVcorrmax.Text);
                double AngInicialMax = Convert.ToDouble(txt_Angmax.Text);

                List<string> arquivosFiltrados = new List<string>();

                string[] arquivos = Directory.GetFiles(caminhoFinal);

                foreach (string arquivo in arquivos)
                {
                    try
                    {
                        string conteudo = File.ReadAllText(arquivo);

                        string[] valoresString = conteudo.Split(';');

                        if (valoresString.Length < 4) continue;

                        double largura = Convert.ToDouble(valoresString[0].Replace(",", "."));
                        double vbarco = Convert.ToDouble(valoresString[1].Replace(",", "."));
                        double vcorrenteza = Convert.ToDouble(valoresString[2].Replace(",", "."));
                        double angulo = Convert.ToDouble(valoresString[3].Replace(",", "."));

                        double valorTemp = Convert.ToDouble(valoresString[4].Replace(",", "."));
                        double valorDesloc = Convert.ToDouble(valoresString[7].Replace(",", "."));
                        double valorAng = Convert.ToDouble(valoresString[8].Replace(",", "."));

                        if ((largura >= LarguraMin && largura <= LarguraMax) &&
                            (vbarco >= VbarcoMin && vbarco <= VbarcoMax) &&
                            (vcorrenteza >= VcorrentezaMin && vcorrenteza <= VcorrentezaMax) &&
                            (angulo >= AngInicialMin && angulo <= AngInicialMax))
                        {
                            arquivosFiltrados.Add(Path.GetFileName(arquivo));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao processar o arquivo {arquivo}: {ex.Message}");
                    }
                }

                lsb_Historico.Items.Clear();
                if (arquivosFiltrados.Count > 0)
                {
                    lsb_Historico.Items.AddRange(arquivosFiltrados.ToArray());
                }
                else
                {
                    MessageBox.Show("Nenhum arquivo encontrado que atenda aos critérios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Insira dados em um formato válido: {ex.Message}");
            }

        }

        private void btn_Redefinir_Click(object sender, EventArgs e)
        {
            foreach (Control control in tlp1_LimitarDados.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = textBox.Tag.ToString();
                    textBox.ForeColor = Color.Gray;
                }
            }

        }

        #endregion

        #region Funções para salvar arquivos

        //Função para salvar arquivo txt com informações:
        private SaveFileDialog criarSaveDialogBox()
        {
            // cria uma instancia do sistema de arquivos para salvar o arquivo
            SaveFileDialog salvarCadastro = new SaveFileDialog();
            //define o titulo
            salvarCadastro.Title = "Salvar Cadastro de Simulação";
            //Define as extensões permitidas
            salvarCadastro.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //define o indice do filtro
            salvarCadastro.FilterIndex = 1;

            //Atribui um valor padrão ao nome do arquivo
            salvarCadastro.FileName = "Simulação - " + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

            //Define a extensão padrão como .txt
            salvarCadastro.DefaultExt = ".txt";
            //define o diretório padrão como pasta "Documents"            
            salvarCadastro.InitialDirectory = caminhoFinal;
            //restaura o diretorio atual antes de fechar a janela
            salvarCadastro.RestoreDirectory = true;

            return salvarCadastro;
        }

        private void SalvarDados(SaveFileDialog save)
        {
            //Se o usuário pressionar o botão Salvar
            if (save.ShowDialog() == DialogResult.OK)
            {
                //Cria um stream usando o nome do arquivo
                FileStream fs = new FileStream(save.FileName, FileMode.Create);

                //Cria um escrito que irá escrever no stream
                StreamWriter writer = new StreamWriter(fs);

                //escreve o conteúdo da caixa de texto no stream
                writer.Write(txt_R1.Text + ';');
                writer.Write(txt_R2.Text + ';');
                writer.Write(txt_R3.Text + ';');
                writer.Write(txt_R4.Text + ';');

                writer.Write(tempoTravessia.ToString("F2") + ';');
                writer.Write(coordenadaX.ToString("F0") + ";");  // Formato "F0" para número inteiro
                writer.Write(coordenadaY.ToString("F0") + ";");  // Formato "F0" para número inteiro
                writer.Write(distanciaTotal.ToString("F2") + ";"); // Formato "F2" para duas casas decimais
                writer.Write(angResGrau.ToString("F2") + ";"); // Formato "F2" para duas casas decimais
                writer.Write(tempoTravessiaMin.ToString("F2") + ";"); // Formato "F2" para duas casas decimais
                writer.Write(tempPerpen.ToString("F2") + ";"); // Formato "F2" para duas casas decimais
                writer.Write(AngGrauTravessiaPerpen.ToString("F2")); // Formato "F2" para duas casas decimais

                //fecha o escrito e o stream
                writer.Close();

                MessageBox.Show($"Simulação Concluida!\nArquivo final: {Path.GetFileName(save.FileName)}");

                string[] Arquivos = Directory.GetFiles(caminhoFinal);

                lsb_Historico.Items.Clear();

                foreach (string arquivo in Arquivos)
                {
                    lsb_Historico.Items.Add(Path.GetFileName(arquivo));
                }
            }
            else
            {
                //exibe mensagem informando que a operação foi cancelada
                MessageBox.Show("Operação cancelada");
            }
        }

        #endregion

        #region Função para calcular

        //função referente ao cálculo:
        private void calcularResultados(double largura, double vRel, double vArr, double angBarcoMargemGrau)
        {
            //Conversão do ângulo em graus para radianos (valor usado na biblioteca Math para calcular Cos, Sen e Tan)
            double angBarcoMargemRad = angBarcoMargemGrau * (Math.PI / 180);

            //Calculo das compenentes I e J do vetor da velocidade resultante
            double vetorVrelComponenteI = vRel * Math.Cos(angBarcoMargemRad);
            double vetorVrelComponenteJ = vRel * Math.Sin(angBarcoMargemRad);

            //Calculo da velocidade resultante (soma entre a vRel e a vArr, no caso acontece apenas a soma dos componentes I do vetor)
            double vetorVresComponenteI = vetorVrelComponenteI + vArr;

            //Calcular o ângulo do movimento resultante do movimento
            double angResRad = Math.Atan2(vetorVrelComponenteJ, vetorVresComponenteI);
            angResGrau = angResRad * (180 / Math.PI);

            //Calculo do tempo de travessia e das coordenadas do movimento (quanto se deslocou em X e em Y)
            tempoTravessia = largura / vetorVrelComponenteJ;

            pontos.Clear();

            // Calcula os pontos do movimento
            int numPassos = 10; // Número de pontos a serem calculados
            for (int i = 0; i <= numPassos; i++)
            {
                // Define o tempo atual de forma precisa
                double t = i * tempoTravessia / numPassos;

                // Calcula as coordenadas
                double coordenadaX = vetorVresComponenteI * t;
                double coordenadaY = vetorVrelComponenteJ * t;

                // Adiciona o ponto à lista
                pontos.Add(new PointF((float)coordenadaX, (float)coordenadaY));
            }

            coordenadaX = pontos.Last().X;
            coordenadaY = pontos.Last().Y;

            distanciaTotal = Math.Sqrt(Math.Pow(coordenadaX, 2) + Math.Pow(coordenadaY, 2));

            //Calculo do tempo de travessia perpendicular
            double vRes = Math.Sqrt(Math.Pow(vRel, 2) - Math.Pow(vArr, 2));
            tempPerpen = largura / vRes;
            AngRadTravessiaPerpen = Math.Acos(-vArr / vRel);
            AngGrauTravessiaPerpen = AngRadTravessiaPerpen * (180 / Math.PI);

            //Calculo para o tempo mínimo de travessia
            tempoTravessiaMin = largura / vRel;

            txt_1.Text = $"{tempoTravessia:F2}";
            txt_2.Text = $"({coordenadaX:F0}, {coordenadaY:F0})";
            txt_3.Text = $"{distanciaTotal:F2}";
            txt_4.Text = $"{angResGrau:F2}";
            txt_5.Text = $"{tempoTravessiaMin:F2}";
            txt_6.Text = $"{tempPerpen:F2}";
            txt_7.Text = $"{AngGrauTravessiaPerpen:F2}°";

            camposCalculados = true;
            lb_2.Enabled = true;
        }

        #endregion

    }
}