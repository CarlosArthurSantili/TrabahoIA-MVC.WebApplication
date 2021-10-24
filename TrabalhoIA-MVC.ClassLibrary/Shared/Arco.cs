using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoIA_MVC.ClassLibrary.Shared
{
    public class Arco
    {
        private Vertice destino;
        private Vertice origem;
        private double peso;

        private bool seguro;
        private double fluxo = 0;
        public Arco(Vertice origem, Vertice destino, double peso)
        {
            this.origem = origem;
            this.destino = destino;
            this.peso = peso;
        }

        public Vertice getOrigem()
        {
            return origem;
        }

        public Vertice getDestino()
        {
            return destino;
        }

        public double getPeso()
        {
            return peso;
        }

        public bool isSeguro()
        {
            return seguro;
        }

        public void setSeguro(bool seguro)
        {
            this.seguro = seguro;
        }

        public String toString()
        {
            return this.destino.toString() + "," + this.peso;
        }

        public int compareTo(Arco t)
        {
            if (this.peso < t.getPeso())
            {
                return -1;
            }
            if (this.peso > t.getPeso())
            {
                return 1;
            }
            return 0;
        }

        public double getFluxo()
        {
            return fluxo;
        }

        public void setFluxo(double fluxo)
        {
            this.fluxo = fluxo;
        }
    }
}
