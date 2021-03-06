using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoIA_MVC.ClassLibrary.Shared;

namespace TrabalhoIA_MVC.ClassLibrary.Algoritmos
{
    public class AlgoritmoBuscaProfundidade
    {
        Grafo grafo;
        Vertice primeiroVertice;

        public AlgoritmoBuscaProfundidade(Grafo grafo, Vertice vertice)
        {
            this.grafo = grafo;
            this.primeiroVertice = vertice;
        }

        public string RealizarBusca(Vertice destino) {
            List<Vertice> resultado = new List<Vertice>();
            Stack<Vertice> pilha = new Stack<Vertice>();

            foreach (Vertice qualquer in grafo.ObterVertices())
            {
                qualquer.zerarVisitas();
                qualquer.zerarDistancia();
            }

            primeiroVertice.visitar();
            primeiroVertice.definirDistancia(0);
            pilha.Push(primeiroVertice);
            while (!(pilha.Count!=0))
            {
                Vertice vp = (Vertice)pilha.Pop();

                List<Vertice> vpAdjacentes = new List<Vertice>();
                foreach (Arco arco in vp.ObterArcos())
                {
                    vpAdjacentes.Add(arco.getDestino());
                }

                foreach (Vertice vf in vpAdjacentes)
                {
                    if (vf.obterVisitado() == 0)
                    {
                        vf.visitar();
                        vf.definirDistancia((vp.obterDistancia()) + (1));
                        pilha.Push(vf);
                    }
                }
                vp.visitar();

                if (vp.rotulo == destino.rotulo)
                {
                    string caminho = vp.rotulo + '-';
                    Vertice verticecaminho = vp;
                    while (verticecaminho.rotulo != this.primeiroVertice.rotulo)
                    {
                        caminho += verticecaminho.getCaminhoLista()[0].getOrigem().toString() + '-';
                        verticecaminho = verticecaminho.getCaminhoLista()[0].getOrigem();
                    }

                    return caminho.Remove(caminho.Length - 1);
                }
            }

            return null;
        }
    }
}
