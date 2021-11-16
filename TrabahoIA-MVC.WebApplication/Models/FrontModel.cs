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
        //public string IdVerticeDestino { get; set; }

        public string[] Passos { get; set; }

        public string[] PosicaoRobos { get; set; }

        public FrontModel()
        {
            Grafo = new Grafo("Models\\grafo.tsv");
            idsData = new IdsData();
            PosicaoRobos = new string[] {"A12", "B12", "C12", "D12", "E12"};
            PrepareIdsLists();
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
        }

        public string[] AlgoritmoDeProfundidade(string IdVerticeDestino) 
        {
            List<string[]> rotasPossiveis = new List<string[]>();
            foreach (var robo in PosicaoRobos)
            {
                Vertice vInicial = new Vertice(robo);
                Vertice vFinal = new Vertice(IdVerticeDestino);
                AlgoritmoBuscaProfundidade x1 = new AlgoritmoBuscaProfundidade(Grafo, vInicial);
                string resultado = x1.RealizarBusca(vFinal);
                rotasPossiveis.Add(resultado.Split("-"));
            }
            string[] caminho = GetRouteWithFewestSteps(rotasPossiveis);
            return caminho;
        }

        public string[] GetRouteWithFewestSteps(List<string[]> rotasPossiveis) 
        {
            string[] menorRota = rotasPossiveis[0];
            foreach (var rota in rotasPossiveis)
            {
                if (rota.Length < menorRota.Length)
                {
                    menorRota = rota;
                }
            }
            return menorRota;
        }
    }
}
