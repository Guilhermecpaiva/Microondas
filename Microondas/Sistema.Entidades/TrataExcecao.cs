using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Microondas
{
    class MyException : Exception
    {


        private string _MyExceptionMessage;



        public string ExceptionMessage
        {
            get { return _MyExceptionMessage; }
            set { _MyExceptionMessage = value; }
        }



        
        public MyException(Exception excep)
        {
            ExceptionMessage = excep.Message;
        }

     

        public MyException(string excepmsg)
        {
            ExceptionMessage = excepmsg;
        }


    }
}
