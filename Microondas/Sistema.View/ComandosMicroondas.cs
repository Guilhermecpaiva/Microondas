using Model.Microondas;
using View.Microondas;
using Entidades.Microondas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Microondas
{
    class ComandosMicroondas : Comandos

    {

        private readonly Aquecimento microondasFuncao;


        public ComandosMicroondas(Aquecimento produtoRepository)
        {
           
            this.microondasFuncao = produtoRepository;
        }

        public void Liga()
        {

            
        }

        public void GetParametros()
        {

        }

    }
}
