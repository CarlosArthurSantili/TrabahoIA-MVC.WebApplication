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
            List<Vertice> resultado = new List<Vertice>();
            List<Vertice> vertices = grafo.ObterVertices();

            foreach (Vertice vertice in vertices)
            {
                vertice.zerarVisitas();
                vertice.zerarDistancia();
            }

            primeiroVertice.visitar();
            primeiroVertice.definirDistancia(0);
            Queue<Vertice> fila = new Queue<Vertice>();
            fila.Enqueue(primeiroVertice);

            while (fila.Count() != 0)
            {
                Vertice vp = (Vertice)fila.Dequeue();
                List<Vertice> vpAdjacentes = new List<Vertice>();

                foreach (Arco arco in vp.ObterArcos())
                {
                    Vertice vpAdjacente = (arco.getDestino());
                    if (vpAdjacente.obterVisitado() == 0)
                    {
                        vpAdjacente.visitar();
                        vpAdjacente.definirDistancia((vp.obterDistancia()) + (1));
                        fila.Enqueue(vpAdjacente);

                        List<Arco> caminhoLista = vpAdjacente.getCaminhoLista();
                        caminhoLista.Add(arco);
                        vpAdjacente.setCaminhoLista(caminhoLista);
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
