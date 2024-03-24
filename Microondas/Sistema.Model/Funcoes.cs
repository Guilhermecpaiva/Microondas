using Model.Microondas;
using View.Microondas;
using Entidades.Microondas;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;

namespace Model.Microondas
{

    class TodosPrograma
    {
        private List<Programa> listaProgramas = new List<Programa>();
        private List<Programa> programas = new List<Programa>();
        private Micro_ondas repositorioMicroOndas = new Micro_ondas();

        public TodosPrograma()
        {
            programas = ObterDados();
        }

        public List<Programa> ObterProgramas()
        {
            return programas;
        }

        public void UsarPrograma(int indice, string texto)
        {
            if (programas[indice].Comida.Contains(texto))
            {
               
            }
           
        }

        public Programa ExibirPrograma(int indice)
        {
            return programas[indice];
        }

        public Programa PesquisarAlimento(string texto)
        {
            foreach (var programa in programas)
            {
                if (programa.Comida.Contains(texto))
                {
                    return programa;
                }
            }
            return null;
        }

        private static List<Programa> ObterDados()
        {
            var json = File.ReadAllText("Programas.json");
            var programas = JsonConvert.DeserializeObject<List<Programa>>(json);
            return programas;
        }

        public void CadastrarPrograma(Programa programa)
        {
            try
            {
                List<Programa> programas;

                if (File.Exists("Programas.json"))
                {
                    var json = File.ReadAllText("Programas.json");
                    programas = JsonConvert.DeserializeObject<List<Programa>>(json);
                }
                else
                {
                    programas = new List<Programa>();
                }

                programas.Add(programa);
                var convertedJson = JsonConvert.SerializeObject(programas, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText("Programas.json", convertedJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar programa: {ex.Message}");
               
            }
        }


        internal void Atualizar()
        {
            var json = File.ReadAllText("Programas.json");
            var programas = JsonConvert.DeserializeObject<List<Programa>>(json);
            this.programas = programas;
        }
    }
}
