using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Model.Microondas
{
    public class Micro_ondas
    {
        public Micro_ondas()
        {

        }

        public decimal Time { get; set; }
        public int Potencia { get; set; }
        public string Comida { get; set; }

        public Micro_ondas(decimal time, int potencia, string comida)
        {

            this.Time = time;
            this.Potencia = potencia;
            this.Comida = comida;
        }

        //internal void Aquecer()
        //{
        //    throw new NotImplementedException();
        //}
    }
}