using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoIA_MVC.ClassLibrary.Shared
{
    public class Vertice
    {
        private List<Arco> arcos = new List<Arco>();

        public String rotulo;
    
        private int visitado = 0;

        private double distancia = 0;

        private String caminho = "";

        private int nArvore;

        private List<Arco> caminhoLista;

        public Vertice(String rotulo)
        {
            this.rotulo = rotulo;
        }

        public void adicionarArco(Vertice destino, double peso)
        {
            this.arcos.Add(new Arco(this, destino, peso));
        }

        public bool removerConexao(Vertice destino)
        {
            foreach (Arco arcoAtual in arcos)
            {
                if (arcoAtual.getDestino() == destino)
                {
                    this.arcos.Remove(arcoAtual);
                    return true;
                }
            }
            return false;
        }

        internal void zerarCaminho()
        {
            this.caminho = "";
        }

        internal void zerarCaminhoLista()
        {
            this.caminhoLista = new List<Arco>();
        }

        public List<Arco> ObterArcos()
        {
            return this.arcos;
        }

        public String toString()
        {
            return this.rotulo;
        }

        public override bool Equals(Object o)
        {
            return o.ToString().Equals(this.rotulo);
        }

        public String obterLinhaArquivo()
        {
            String linha = this.rotulo;
            foreach (Arco arcoAtual in arcos)
            {
                linha += "\t" + arcoAtual.ToString();
            }
            return linha;
        }

        public int obterGrau()
        {
            return this.arcos.Count();
        }

        public void visitar()
        {
            this.visitado++;
        }

        public int obterVisitado()
        {
            return this.visitado;
        }

        public void zerarVisitas()
        {
            this.visitado = 0;
        }

        public void zerarDistancia()
        {
            this.distancia = 0;
        }

        public void definirDistancia(double distancia)
        {
            this.distancia = distancia;
        }

        public double obterDistancia()
        {
            return this.distancia;
        }

        public int getnArvore()
        {
            return nArvore;
        }

        public void setnArvore(int nArvore)
        {
            this.nArvore = nArvore;
        }

        public String getCaminho()
        {
            return caminho + " - " + this.rotulo;
        }

        public void setCaminho(String caminho)
        {
            this.caminho = caminho;
        }

        public List<Arco> getCaminhoLista()
        {
            if (this.caminhoLista == null)
            {
                return new List<Arco>();
            }
            else 
            {
                return this.caminhoLista;
            }
        }

        public void setCaminhoLista(List<Arco> caminhoLista)
        {
            if (caminhoLista == null)
            {
                this.caminhoLista = new List<Arco>();
            }
            else
            {
                this.caminhoLista = new List<Arco>(caminhoLista);
            }
        }
    }
}
