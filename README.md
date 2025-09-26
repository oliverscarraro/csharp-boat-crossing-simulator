# Simulador de Travessia de Barco em C#

<p align="center">
  <img src="URL_DO_SEU_GIF_OU_IMAGEM_AQUI" alt="Demonstração do Simulador" width="700"/>
</p>

## Visão Geral

Este projeto é um simulador de desktop desenvolvido em **C# com Windows Forms**, criado como uma aplicação prática para as disciplinas de **Algoritmos II** e **Física Geral e Experimental I**. A aplicação calcula e visualiza a trajetória de um barco atravessando um rio com correnteza, com base em parâmetros fornecidos pelo usuário.

Além da simulação, o programa conta com um sistema de histórico que permite salvar, carregar, filtrar e ordenar simulações anteriores.

---

### ► O Desafio Físico: Composição de Movimento

O núcleo do simulador é a resolução de um problema clássico de cinemática vetorial. O movimento resultante do barco é a soma vetorial da sua velocidade relativa à água e da velocidade de arrasto da correnteza.

- **Vetor Velocidade Relativa ($V_{rel}$):** A velocidade do barco em relação à água, com um ângulo definido pelo usuário.
- **Vetor Velocidade de Arrasto ($V_{arr}$):** A velocidade da correnteza, que atua paralelamente às margens.
- **Vetor Velocidade Resultante ($V_{res}$):** A velocidade real do barco em relação às margens.

A aplicação decompõe os vetores em seus componentes `i` (eixo X) e `j` (eixo Y) para calcular a trajetória final, o tempo de travessia e a distância percorrida.

**Fórmula Vetorial:** $V_{res} = V_{rel} + V_{arr}$

---

### ► Funcionalidades

- **Simulação Parametrizada:** Permite ao usuário inserir os dados de entrada para a simulação.
- **Cálculo Físico:** Executa todos os cálculos de cinemática vetorial para determinar os resultados.
- **Visualização Gráfica:** Plota um gráfico XY que exibe a trajetória resultante do barco de uma margem à outra.
- **Exibição de Resultados:** Apresenta dados calculados como tempo de travessia, distância total, coordenadas finais e ângulo resultante.
- **Sistema de Histórico:**
    - **Salvar:** Salva os parâmetros e resultados de uma simulação em um arquivo `.txt`.
    - **Carregar:** Carrega uma simulação salva para visualização.
    - **Filtrar:** Permite filtrar o histórico com base em um intervalo de valores para cada parâmetro.
    - **Ordenar:** Organiza o histórico de simulações da mais antiga para a mais recente, e vice-versa, utilizando o algoritmo **Insertion Sort**.

---

### ► Parâmetros de Entrada

O usuário pode definir as seguintes variáveis para cada simulação:
- **Largura do Rio (m)**
- **Velocidade do Barco (m/s)** (relativa à água)
- **Velocidade da Correnteza (m/s)**
- **Ângulo do Barco em relação à Margem (graus)**

---

### ► Tecnologias Utilizadas

- **Linguagem:** C#
- **Framework:** .NET Framework com Windows Forms
- **Visualização:** `System.Windows.Forms.DataVisualization.Charting`
- **Assets Visuais:** Animação de fundo criada com **Blender** e exportada como uma sequência de imagens para ambientação da interface.

---

### ► Como Executar

O projeto foi desenvolvido como uma solução de Windows Forms no Visual Studio.

**Pré-requisitos:**
- [Visual Studio](https://visualstudio.microsoft.com/) com a carga de trabalho de ".NET desktop development".
- .NET Framework 4.7.2 ou superior.

**Passos:**
1.  Clone o repositório: `git clone https://github.com/seu-usuario/csharp-boat-crossing-simulator.git`
2.  Abra o arquivo da solução (`.sln`) no Visual Studio.
3.  Pressione `F5` ou clique em "Start" para compilar e executar a aplicação.
