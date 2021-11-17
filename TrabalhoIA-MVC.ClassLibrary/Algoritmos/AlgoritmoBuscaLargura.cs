using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoIA_MVC.ClassLibrary.Shared;

namespace TrabalhoIA_MVC.ClassLibrary.Algoritmos
{
    public class AlgoritmoBuscaLargura
    {
        Grafo grafo;
        Vertice primeiroVertice;

        public AlgoritmoBuscaLargura(Grafo grafo, Vertice vertice)
        {
            this.grafo = grafo;
            this.primeiroVertice = vertice;
        }

        public string RealizarBusca(Vertice destino)
        {
            List<Vertice> vertices = grafo.ObterVertices();

            foreach (Vertice vertice in vertices)
            {
                vertice.zerarVisitas();
                vertice.zerarDistancia();
                vertice.zerarCaminho();
                vertice.zerarCaminhoLista();
            }

            primeiroVertice.visitar();
            primeiroVertice.definirDistancia(0);
            Queue<Vertice> fila = new Queue<Vertice>();
            fila.Enqueue(primeiroVertice);

            while (fila.Count() != 0)
            {
                Vertice verticeAtual = (Vertice)fila.Dequeue();

                foreach (Arco arco in verticeAtual.ObterArcos())
                { 
                    Vertice verticeAtualAdjacente = (arco.getDestino());
                    if (verticeAtualAdjacente.obterVisitado() == 0)
                    {
                        verticeAtualAdjacente.visitar();
                        verticeAtualAdjacente.definirDistancia((verticeAtual.obterDistancia()) + (1));
                        fila.Enqueue(verticeAtualAdjacente);

                        List<Arco> caminhoLista = verticeAtualAdjacente.getCaminhoLista();
                        caminhoLista.Add(arco);
                        verticeAtualAdjacente.setCaminhoLista(caminhoLista);
                    }
                }

                verticeAtual.visitar();
                if (verticeAtual.rotulo == destino.rotulo)
                {
                    string caminho = verticeAtual.rotulo + '-';
                    Vertice verticecaminho = verticeAtual;
                    while (verticecaminho.rotulo != this.primeiroVertice.rotulo)
                    {
                        try
                        {
                            caminho += verticecaminho.getCaminhoLista()[0].getOrigem().toString() + '-';
                            verticecaminho = verticecaminho.getCaminhoLista()[0].getOrigem();
                        }
                        catch (Exception e)
                        {
                            break;
                        }
                    }
                    return caminho.Remove(caminho.Length - 1);
                }
            }

            return null;

        }
    }
}
