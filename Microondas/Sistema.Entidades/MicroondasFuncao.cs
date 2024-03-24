using Model.Microondas;
using View.Microondas;
using Entidades.Microondas;
using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;



namespace Entidades.Microondas
{

    public class MicroondasFuncao : Aquecimento
    {
        public bool Saindo { get; set; }

        private string _textoFinal = "";
        private decimal _tempoAtual;

        private decimal _tempoTotal;
        private int _potencia;
        private string _texto;
        private char _caracter;

        public MicroondasFuncao()
        {

        }

        public MicroondasFuncao(bool condicao)
        {
            this.Saindo = condicao;
        }

        public MicroondasFuncao(decimal tempoAtual, decimal tempoTotal, int potencia, string texto, char caracter)
        {
            this._tempoAtual = tempoAtual;
            this._tempoTotal = tempoTotal;
            this._potencia = potencia;
            this._texto = texto;
            this._caracter = caracter;

        }

        public void Aquecer()
        {
            try
            {
                do
                {
                    Thread.Sleep(1000);

                    _tempoAtual++;

                } while (_tempoAtual < (_tempoTotal < 1 ? (_tempoTotal * 100) : (_tempoTotal * 60)));
            }
            catch (ThreadAbortException abortException)
            {
                System.Windows.Forms.MessageBox.Show(((string)abortException.ExceptionState));
            }

            this.Aquecido();
        }

        public string GetTextoFinal()
        {
            return _texto + _textoFinal;
        }

        public string getTexto()
        {
            return _texto + _textoFinal;
        }

        public delegate void EventoAquecido();
        public event EventoAquecido Aquecido;


    }
}
