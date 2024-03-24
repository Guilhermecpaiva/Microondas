using Model.Microondas;
using View.Microondas;
using Entidades.Microondas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Microondas
{
    public partial class Pesquisa : Form
    {
        private Programa p;
        private TodosPrograma dominio = new TodosPrograma();
        private int indicePrograma;

        public Pesquisa()
        {
            InitializeComponents();
        }

        //private void InitializeComponent()
        //{
          
        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string texto = textBox2.Text;
            p = dominio.PesquisarAlimento(texto);
            if (p != null)
            {
                ShowPrograma(p);
            }
            else
            {
                MessageBox.Show("Alimento inválido");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            indicePrograma = comboBox1.SelectedIndex;
        }

        private void ComboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (var programa in dominio.ObterProgramas())
            {
                comboBox1.Items.Add(programa.AlimentosAquecimento);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p = dominio.ExibirPrograma(indicePrograma);
            ShowPrograma(p);
        }

        private void ShowPrograma(Programa entrada)
        {
            label6.Text = p.Nome;
            label6.Visible = true;
            label7.Text = p.Potencia.ToString();
            label7.Visible = true;
            label8.Text = p.Time.ToString();
            label8.Visible = true;
            textBox1.Visible = true;
            textBox1.Text = p.Instrucoes;
            listView1.Items.Clear();
            foreach (var item in p.AlimentosAquecimento)
            {
                listView1.Items.Add(item);
            }
        }
    }
}
