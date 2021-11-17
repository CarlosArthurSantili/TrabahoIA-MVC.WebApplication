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
        List<Vertice> listaFechada;
        List<Vertice> listaAberta;
       

        public AlgoritmoAEstrela(Grafo grafo, Vertice vertice)
        {
            
            verticepai = null;
            listaFechada = new List<Vertice>();
            listaAberta = new List<Vertice>();
            this.grafo = grafo;
            this.primeiroVertice = vertice;
        }

        public string RealizarBusca(Vertice destino)
        {

                      

            listaAberta.Add(primeiroVertice);
            

            while (listaAberta.Count != 0 && !listaFechada.Exists(x => x.rotulo == destino.rotulo))
            {
                verticepai = listaAberta[0];               
                listaAberta.RemoveAll(x => x.rotulo == verticepai.rotulo);
                listaFechada.Add(verticepai);
                


                foreach (Arco arco in verticepai.ObterArcos())
                {
                    Vertice verticeAdjacente = (arco.getDestino());
                    if (!listaFechada.Any(item => item.rotulo == verticeAdjacente.rotulo))
                    {
                        if (!listaAberta.Any(item => item.rotulo == verticeAdjacente.rotulo))
                        {
                            verticeAdjacente.setPai(verticepai);
                            CalcularF(ref verticeAdjacente, destino);
                            listaAberta.Add(verticeAdjacente);
                            listaAberta = listaAberta.OrderBy(node => node.rotulo).ToList<Vertice>();
                        }
                    }
                }
            }
              

            Vertice temp = listaFechada.Find(item=> item.rotulo == verticepai.rotulo);
            if (temp == null) return null;
            string caminho = "";
            do
            {
                caminho += temp.rotulo + '-';
                temp = temp.getPai();
            } while (temp != primeiroVertice && temp != null);
            return caminho += primeiroVertice.rotulo;


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
            atual.G = atual.getPai().G + 1;
            atual.F = atual.G + atual.H;
        }


       }
}
