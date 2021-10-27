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

        public List<Vertice> RealizarBusca() {
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
                    vpAdjacentes.Add(arco.getDestino());
                }

                foreach (Vertice vf in vpAdjacentes)
                {
                    if (vf.obterVisitado() == 0)
                    {
                        vf.visitar();
                        vf.definirDistancia((vp.obterDistancia()) + (1));
                        fila.Enqueue(vf);
                    }
                }

                vp.visitar();
            }

            resultado = grafo.ObterVertices();
            return resultado;
        }
    }
}
