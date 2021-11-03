using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoIA_MVC.ClassLibrary.Algoritmos;
using TrabalhoIA_MVC.ClassLibrary.Shared;

namespace TrabahoIA_MVC.WebApplication.Models
{
    public class FrontModel
    {
        private readonly IdsData idsData;

        public List<string> IdsList { get; set; }
        public AlgoritmoBuscaProfundidade algoritmoBuscaProfundidade;
        public string[] Passos { get; set; }
        public Grafo Grafo { get; set; }
        public Vertice VerticeInicial { get; set; }
        public Vertice VerticeFinal { get; set; }

        public List<string> teste { get; set; }

        public FrontModel()
        {
            idsData = new IdsData();
            IdsList = new List<string>();
            teste = new List<string>();
            IdsList = idsData.GetIdsList();
            Teste();
        }

        public void Teste()
        {
            teste.Add("A0");
            teste.Add("A1");
            teste.Add("A2");
            teste.Add("A3");
            teste.Add("A4");
            teste.Add("A5");
        }

        public void ProcessarCaminho()
        {
            algoritmoBuscaProfundidade = new AlgoritmoBuscaProfundidade(Grafo, VerticeInicial);
            Passos = algoritmoBuscaProfundidade.RealizarBusca(VerticeFinal).Split('-');
        }

        /*
         @functions
{
    void WalkThrough()
    {
        string lastId = Model.teste[0];
        foreach (var passo in Model.teste)
        {
            if (Html.Raw($@"document.getElementById(@lastId)"))
            {
                document.getElementById(@lastId).innerHTML('@lastId');
            }
            if (Html.Raw($@"document.getElementById(@passo)"))
            {
                document.getElementById(@passo).innerHTML('X');
                lastId = passo;
            }
        }
    }
}
         */
    }
}
