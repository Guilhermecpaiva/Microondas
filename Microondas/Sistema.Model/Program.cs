using Entidades.Microondas;
using Model.Microondas;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Model.Microondas
{
    public class Programa : Micro_ondas
    {
        public char CaractereAquecimento { get; set; }
        public string Instrucoes { get; set; }
        public string Nome { get; set; }

        public List<string> AlimentosAquecimento = new List<string>();

        Thread thread = null;

        public Programa()
        {

        }

        public Programa(decimal tempo, List<string> alimentos, int potencia, char caractereAquecimento, string nome)
        {
            this.Time = tempo;
            this.AlimentosAquecimento = alimentos;
            this.Potencia = potencia;
            this.CaractereAquecimento = caractereAquecimento;
            this.Nome = nome;
        }

        public Programa(decimal tempo, List<string> alimentos, int potencia, char caractereAquecimento, string nome, string instrucoes)
        {
            this.Time = tempo;
            this.AlimentosAquecimento = alimentos;
            this.Potencia = potencia;
            this.CaractereAquecimento = caractereAquecimento;
            this.Nome = nome;
            this.Instrucoes = instrucoes;
        }

        public void AquecerPrograma(string texto)
        {
            MicroondasFuncao micro = new MicroondasFuncao(this.Time, this.Time, this.Potencia, texto, this.CaractereAquecimento);
            micro.Aquecer();
        }
    }
}
