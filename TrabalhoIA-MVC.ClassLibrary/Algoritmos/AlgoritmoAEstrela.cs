using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoIA_MVC.ClassLibrary.Shared;

namespace TrabalhoIA_MVC.ClassLibrary.Algoritmos
{
    public class AlgoritmoAEstrela
    {
        Grafo grafo;
        Vertice primeiroVertice;
        Vertice verticepai;
        Vertice verticeMinimo = null;
        int valorG = 0;
        List<Vertice> resultado;


        public AlgoritmoAEstrela(Grafo grafo, Vertice vertice)
        {
            resultado = new List<Vertice>();
            this.grafo = grafo;
            this.primeiroVertice = vertice;
        }

        public List<Vertice> RealizarBusca(Vertice destino)
        {

            
            List<Vertice> vertices = grafo.ObterVertices();

            foreach (Vertice vertice in vertices)
            {
                vertice.zerarVisitas();                
            }

            primeiroVertice.visitar();

            
            resultado.Add(primeiroVertice);
            verticepai = primeiroVertice;

            CalcularF(ref verticepai, destino);

            do
            {
                verticepai = CalculaValorMinimo(verticepai, destino);
                resultado.Add(verticepai);
            } while (verticepai != destino);         
           



            return resultado;
        }

        public int CalcularValorG(Vertice atual)
        {   
            
            return 0;
        }
        public int CalcularHeuristica(Vertice atual, Vertice destino)
        {

            int heuristica = Math.Abs((int)atual.rotulo[0] - (int)destino.rotulo[0]) +
                Math.Abs((Convert.ToInt32(atual.rotulo[1..]) - Convert.ToInt32(destino.rotulo[1..])));
            
            return heuristica;
        }

        public void CalcularF(ref Vertice atual, Vertice destino)
        {
            atual.H = CalcularHeuristica(atual, destino);
            atual.G = valorG;
            atual.F = atual.G + atual.H;
        }


        public Vertice CalculaValorMinimo(Vertice atual, Vertice destino)
        {
           Vertice verticeMinimo = null;
            
            foreach (Arco arco in atual.ObterArcos())
            {
                Vertice verticeAdjacente = (arco.getDestino());

                //nao esquecer de adicionar um if == prateleira continue
                if (verticeAdjacente.obterVisitado() == 1)
                    continue;

                if (verticeAdjacente == destino)
                    return verticeAdjacente;

                CalcularF(ref verticeAdjacente, destino);                

                if (verticeMinimo == null)
                    verticeMinimo = verticeAdjacente;
                else if (verticeAdjacente.F < verticeMinimo.F)
                {
                    verticeMinimo = verticeAdjacente;
                    verticepai = verticeAdjacente;
                }

            }

            verticepai.visitar();

            return verticeMinimo;
        }
}
}
