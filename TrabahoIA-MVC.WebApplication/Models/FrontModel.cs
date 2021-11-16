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

        public Dictionary<string, string> IdsDictionary { get; set; }
        public List<string> ShelvesList { get; set; }
        public List<string> UnreachbleIds { get; set; }
        public List<string> RobotInitialIds { get; set; }

        public AlgoritmoBuscaProfundidade algoritmoBuscaProfundidade;
        public Grafo Grafo { get; set; }
        public Vertice VerticeInicial { get; set; }
        public Vertice VerticeFinal { get; set; }
        public string[] Passos { get; set; }
        public List<string> teste { get; set; }

        public FrontModel()
        {
            idsData = new IdsData();
            PrepareIdsLists();
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

        public void PrepareIdsLists() 
        {
            IdsDictionary = new Dictionary<string, string>();
            IdsDictionary = idsData.GetIdsDictionary();
            ShelvesList = new List<string>();
            ShelvesList = idsData.GetShelvesIds();
            UnreachbleIds = new List<string>();
            UnreachbleIds = idsData.GetUnreachableIds();
            RobotInitialIds = new List<string>();
            RobotInitialIds = idsData.GetRobotInitialPlaces();
            teste = new List<string>();
            Teste();
        }
    }
}
