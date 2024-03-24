using Entidades.Microondas;
using Model.Microondas;
using View.Microondas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace View.Microondas
{
    public partial class Form1 : Form
    {
        public Aquecimento produto;

        private int _Potencia_Maxima = 10;

        string tempo = "";
        string potencia = "";

        private List<Programa> programas = new List<Programa>();

        int indicePrograma;
        private TodosPrograma p = new TodosPrograma();

        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Exibe_Mensagem(string ex)
        {
            MessageBox.Show(ex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            tempo = this.textBox2.Text.Replace(".", ",");
            potencia = this.textBox1.Text;

            // Se tempo e potência não forem informados, executa de forma automática
            if (string.IsNullOrEmpty(tempo) && string.IsNullOrEmpty(potencia))
            {
                tempo = "0,30";
                potencia = "8";
            }

            if (Convert.ToDecimal(tempo) < (1 / 100) || Convert.ToDecimal(tempo) > 2 || Convert.ToDecimal(tempo) < 0)
            {
                try
                {
                    //throw new TrataExcecao(Excecao.Erro(2));
                }
                catch (TrataExcecao ex)
                {
                    var erro = ex.GetErros();
                    if (!string.IsNullOrWhiteSpace(erro))
                        MessageBox.Show(erro);
                }
            }

            if (int.Parse(potencia) == 0 || int.Parse(potencia) > _Potencia_Maxima)
            {
                try
                {
                   // throw new TrataExcecao(Excecao.Erro(1));
                }
                catch (TrataExcecao ex)
                {
                    var erro = ex.GetErros();
                    if (!string.IsNullOrWhiteSpace(erro))
                        MessageBox.Show(erro);
                }
            }

            Micro_ondas mc = new Micro_ondas(Convert.ToDecimal(tempo), int.Parse(potencia), this.textBox3.Text);
            try
            {
                MicroondasFuncao produtoRepository = new MicroondasFuncao(mc.Time, mc.Time, mc.Potencia, mc.Comida, '.');

                if (File.Exists(this.textBox3.Text))
                {
                    produtoRepository.Aquecido += new MicroondasFuncao.EventoAquecido(Fim_Aquecimento);

                    string[] dados = File.ReadAllLines(this.textBox3.Text);

                    this.textBox3.Text = "";
                    foreach (var item in dados)
                    {
                        var valores = item.Split(' ');

                        ThreadPool.QueueUserWorkItem(new WaitCallback((state) =>
                        {
                            if (valores.Length > 1 && valores[1] != "")
                                Processa_Potencia(mc.Potencia, mc.Time, valores[1]);
                        }));

                        produtoRepository.Aquecer();
                    }

                    // Processa arquivos
                }
                else
                {
                    produtoRepository.Aquecido += new MicroondasFuncao.EventoAquecido(Fim_Aquecimento);

                    ThreadPool.QueueUserWorkItem(new WaitCallback((state) =>
                    {
                        Processa_Potencia(mc.Potencia, mc.Time, ".");
                    }));

                    produtoRepository.Aquecer();
                }
            }
            catch (Exception ex)
            {
                Exibe_Mensagem(ex.Message);
            }

            button1.Enabled = true;
        }

        private void Processa_Potencia(int potencia, decimal tempo, string cCaracter)
        {
            int ProcPot = 0;
            do
            {
                ProcPot++;

                for (int i = 0; i < potencia; i++)
                {
                    textBox3.Text += cCaracter;
                }
            } while (ProcPot < (tempo < 1 ? (tempo * 100) : (tempo * 60)) && !cancellationTokenSource.Token.IsCancellationRequested);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                p.UsarPrograma(indicePrograma, textBox3.Text);

                programas = p.ObterProgramas();

                MicroondasFuncao produtoRepository = new MicroondasFuncao(programas[indicePrograma].Time, programas[indicePrograma].Time, programas[indicePrograma].Potencia, programas[indicePrograma].Comida, programas[indicePrograma].CaractereAquecimento);

                produtoRepository.Aquecido += new MicroondasFuncao.EventoAquecido(Fim_Aquecimento);

                ThreadPool.QueueUserWorkItem(new WaitCallback((state) =>
                {
                    Processa_Potencia(programas[indicePrograma].Potencia, programas[indicePrograma].Time, programas[indicePrograma].CaractereAquecimento.ToString());
                }));

                produtoRepository.Aquecer();
            }
            catch (TrataExcecao ex)
            {
                var erro = ex.GetErros();
                if (!string.IsNullOrWhiteSpace(erro))
                    MessageBox.Show(erro);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            indicePrograma = comboBox1.SelectedIndex;
        }

        private void search_Click(object sender, EventArgs e)
        {
            Pesquisa pesquisa = new Pesquisa();

            pesquisa.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Inserir inserir = new Inserir();
            inserir.ShowDialog();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            p.Atualizar();
            comboBox1.Items.Clear();
            foreach (var programa in p.ObterProgramas())
            {
                comboBox1.Items.Add(programa.Nome);
            }
        }

        void Fim_Aquecimento()
        {
            MessageBox.Show("Aquecido");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
            button1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Pausar")
            {
                button5.Text = "Continuar";
                cancellationTokenSource.Cancel();
            }
            else
            {
                button5.Text = "Pausar";
                cancellationTokenSource = new CancellationTokenSource();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
