using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Microondas
{
    public class RegrasDenegocio
    {

        public RegrasDenegocio()
        {
        }

        public string Erro(int erro)
        {

                string mensagem = "";

            switch (erro)
            {
                case 1: mensagem = "Potencia deve ser menor ou igual a 10 e maior que 1"; break;
                case 2: mensagem = "Valor Inválido. O tempo deve ser menor ou igual a 2 minutos e maior ou igual a 1 segundo"; break;
                case 3: mensagem = "Alimento inválido"; break;


            }


            return mensagem;


        }



    }



}
