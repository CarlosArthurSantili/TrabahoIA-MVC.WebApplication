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
        }

        
        public string[] AlgoritmoDeLargura(String VerticeDestino) 
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

            
            string[] aux = GetRouteWithFewestSteps(rotasPossiveis);
            string[] caminhoEntrega = new string[aux.Length];
            int count = 0;
            for (int i = aux.Length; i > 0; i--)
            {
                caminhoEntrega[count] = aux[i - 1];
                count++;
            }
            string[] entregaERetorno = GetCaminhoEntrega(caminhoEntrega.Last());
            string[] caminhoCompleto = CreateWholePath(caminhoEntrega, entregaERetorno);

            return caminhoCompleto;
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
            string lastPosition = caminho.First();
            PosicaoRobos[robot] = lastPosition;
        }

        private string[] GetCaminhoEntrega(string robo)
        {
            Vertice vInicial = Grafo.PesquisaVertice(robo);
            Vertice vFinal = Grafo.PesquisaVertice("O11");
            AlgoritmoBuscaLargura x1 = new AlgoritmoBuscaLargura(Grafo, vInicial);
            string resultado = x1.RealizarBusca(vFinal);

            
            string[] aux = resultado.Split("-");
            string[] caminhoEntrega = new string[aux.Length*2];
            int count = 0;
            for (int i = aux.Length; i > 0; i--)
            {
                caminhoEntrega[count] = aux[i - 1];
                count++;
            }

            foreach (var item in aux)
            {
                caminhoEntrega[count] = item;
                count++;
            }
            return caminhoEntrega;
        }

        private string[] CreateWholePath(string[] caminho, string[] entregaERetorno)
        {
            string[] caminhoCompleto = new string[caminho.Length + entregaERetorno.Length];
            
            int count = 0;
            foreach (var item in caminho)
            {
                caminhoCompleto[count] = item;
                count++;
            }

            foreach (var item in entregaERetorno)
            {
                caminhoCompleto[count] = item;
                count++;
            }

            return caminhoCompleto;
        }

        public string[] AlgoritmoDeAEstrela(String VerticeDestino)
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


            string[] aux = GetRouteWithFewestSteps(rotasPossiveis);
            string[] caminhoEntrega = new string[aux.Length];
            int count = 0;
            for (int i = aux.Length; i > 0; i--)
            {
                caminhoEntrega[count] = aux[i - 1];
                count++;
            }
            string[] entregaERetorno = GetCaminhoEntrega(caminhoEntrega.Last());
            string[] caminhoCompleto = CreateWholePath(caminhoEntrega, entregaERetorno);

            return caminhoCompleto;
        }

        public string CaminhoAEstrelaToString(String VerticeDestino)
        {
            string[] caminhoRetornado = AlgoritmoDeLargura(VerticeDestino);
            string caminhoCompleto = "";
            for (int i = 0; i < caminhoRetornado.Length; i++)
            {
                if (i == (caminhoRetornado.Length - 1))
                {
                    caminhoCompleto += caminhoRetornado[i];
                }
                else
                {
                    caminhoCompleto += caminhoRetornado[i] + "-";
                }

            }

            return caminhoCompleto;
        }

        public string[] AlgoritmoDeProfundidade(String VerticeDestino)
        {
            List<string[]> rotasPossiveis = new List<string[]>();
            foreach (var robo in PosicaoRobos)
            {
                Vertice vInicial = Grafo.PesquisaVertice(robo);
                Vertice vFinal = Grafo.PesquisaVertice(VerticeDestino);

                AlgoritmoBuscaProfundidade x1 = new AlgoritmoBuscaProfundidade(Grafo, vInicial);
                string resultado = x1.RealizarBusca(vFinal);
                rotasPossiveis.Add(resultado.Split("-"));
            }


            string[] aux = GetRouteWithFewestSteps(rotasPossiveis);
            string[] caminhoEntrega = new string[aux.Length];
            int count = 0;
            for (int i = aux.Length; i > 0; i--)
            {
                caminhoEntrega[count] = aux[i - 1];
                count++;
            }
            string[] entregaERetorno = GetCaminhoEntrega(caminhoEntrega.Last());
            string[] caminhoCompleto = CreateWholePath(caminhoEntrega, entregaERetorno);

            return caminhoCompleto;
        }

        public string CaminhoProfundidadeToString(String VerticeDestino)
        {
            string[] caminhoRetornado = AlgoritmoDeLargura(VerticeDestino);
            string caminhoCompleto = "";
            for (int i = 0; i < caminhoRetornado.Length; i++)
            {
                if (i == (caminhoRetornado.Length - 1))
                {
                    caminhoCompleto += caminhoRetornado[i];
                }
                else
                {
                    caminhoCompleto += caminhoRetornado[i] + "-";
                }

            }

            return caminhoCompleto;
        }

        public string CaminhoLarguraToString(String VerticeDestino) 
        {
            string[] caminhoRetornado = AlgoritmoDeLargura(VerticeDestino);
            string caminhoCompleto = "";
            for (int i = 0; i < caminhoRetornado.Length; i++)
            {
                if (i == (caminhoRetornado.Length - 1))
                {
                    caminhoCompleto += caminhoRetornado[i];
                }
                else
                {
                    caminhoCompleto += caminhoRetornado[i] + "-";
                }
                
            }

            return caminhoCompleto;
        }

        public string GetPosicaoRobosToString() 
        {
            string posicoesRobos = "";
            for (int i = 0; i < PosicaoRobos.Length; i++)
            {
                if (i == (PosicaoRobos.Length - 1))
                {
                    posicoesRobos += PosicaoRobos[i];
                }
                else
                {
                    posicoesRobos += PosicaoRobos[i] + "-";
                }

            }

            return posicoesRobos;
        }
    }
}
