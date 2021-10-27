using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoIA_MVC.ClassLibrary.Shared
{
    public class Grafo
    {
        private List<Vertice> vertices = new List<Vertice>();

        public Grafo()
        {

        }

        public Grafo(String caminhoArquivo)
        {
            try
            {
                this.LerArquivo(caminhoArquivo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AdicionarVertice(String rotulo)
        {
            Vertice novo = new Vertice(rotulo);
            vertices.Add(novo);
        }

        public List<Vertice> ObterVertices()
        {
            return this.vertices;
        }

        public Vertice PesquisaVertice(String rotulo)
        {
            foreach (Vertice vertice in vertices)
            {
                if (vertice.rotulo == rotulo)
                    return vertice;
            }
            return null;
        }

        public void LerArquivo(string caminhoArquivo) 
        {
            //ler arquivo com grafos
            try
            {
                /*
                 
                 */
                var arquivo = File.ReadAllLines(caminhoArquivo);
                List<String[]> linhas = new List<String[]>();

                foreach (string linha in arquivo)
                {
                    String[] valores = linha.Split("\t");
                    linhas.Add(valores);
                    this.AdicionarVertice(valores[0]);
                }


                foreach (string linha in arquivo)
                {
                    String[] termos = linha.Split("\t");
                    
                    double peso = 1.0;
                    String[] arcos = termos[1].Split(",");

                    foreach (var arco in arcos)
                    {
                        Vertice conecta = this.PesquisaVertice(arco);
                        this.PesquisaVertice(termos[0]).adicionarArco(conecta, peso);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    
        public List<Arco> ObterTodosOsArcos()
        {
            List<Arco> resultado = new List<Arco>();
            foreach (Vertice vertice in vertices) 
            {
                foreach (Arco arco in vertice.ObterArcos())
                    resultado.Add(arco);
            }
            return resultado;
        }
    }
}
