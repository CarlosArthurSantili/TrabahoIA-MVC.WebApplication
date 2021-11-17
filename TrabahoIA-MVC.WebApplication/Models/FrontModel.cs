using Microsoft.JSInterop;
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

        public string[] Passos { get; set; }
        public string[] PosicaoRobos { get; set; }
        public string[] CaminhoCompleto { get; set; }
        public string VerticeDestino { get; set; }

        public string AlgoritmoEscolhido { get; set; }

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

        
        public void AlgoritmoDeLargura(String VerticeDestino) 
        {
            List<string[]> rotasPossiveis = new List<string[]>();
            foreach (var robo in PosicaoRobos)
            {
                Vertice vInicial = Grafo.PesquisaVertice(robo);
                Vertice vFinal = Grafo.PesquisaVertice(VerticeDestino);
                
                AlgoritmoBuscaLargura x1 = new AlgoritmoBuscaLargura(Grafo, vInicial);
                string resultado = x1.RealizarBusca(vFinal);
                rotasPossiveis.Add(resultado.Split("-"));
            }

            string[] caminhoEntrega = new string[] { };
            string[] aux = GetRouteWithFewestSteps(rotasPossiveis);
            for (int i = aux.Length; i < 0; i--)
            {
                caminhoEntrega.Append(aux[i]);
            }
            string[] entregaERetorno = GetCaminhoEntrega(caminhoEntrega.Last());
            string[] caminhoCompleto = CreateWholePath(caminhoEntrega, entregaERetorno);

            this.CaminhoCompleto = caminhoCompleto;
        }

        public string[] GetRouteWithFewestSteps(List<string[]> rotasPossiveis) 
        {
            int count = -1;
            string[] menorRota = rotasPossiveis[0];
            foreach (var rota in rotasPossiveis)
            {
                count++;
                if (rota.Length < menorRota.Length)
                {
                    menorRota = rota;
                }
            }
            UpdateRobotsPositions(menorRota, count);
            return menorRota;
        }

        private void UpdateRobotsPositions(string[] caminho, int robot)
        {
            string lastPosition = caminho.Last();
            PosicaoRobos[robot] = lastPosition;
        }

        private string[] GetCaminhoEntrega(string robo)
        {
            Vertice vInicial = Grafo.PesquisaVertice(robo);
            Vertice vFinal = Grafo.PesquisaVertice("O11");
            AlgoritmoBuscaLargura x1 = new AlgoritmoBuscaLargura(Grafo, vInicial);
            string resultado = x1.RealizarBusca(vFinal);

            string[] caminhoEntrega = new string[] { };
            string[] aux = resultado.Split("-");
            for (int i = aux.Length; i < 0; i--)
            {
                caminhoEntrega.Append(aux[i]);
            }
            foreach (var item in aux)
            {
                caminhoEntrega.Append(item);
            }
            return caminhoEntrega;
        }

        private string[] CreateWholePath(string[] caminho, string[] entregaERetorno)
        {
            string[] caminhoCompleto = caminho;
            foreach (var item in entregaERetorno)
            {
                caminhoCompleto.Append(item);
            }
            return caminhoCompleto;
        }
    }
}
