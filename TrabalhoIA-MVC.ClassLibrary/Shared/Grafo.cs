using java.io;
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
        private List<Vertice> vertices;// = new List();

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
            int indice = vertices.IndexOf(new Vertice(rotulo));
            return (indice >= 0) ? vertices[(indice)] : null;
        }

        public void GravarArquivo(string caminhoArquivo)
        {
            try
            {
                BufferedWriter escritor = new BufferedWriter(new FileWriter(caminhoArquivo));
                foreach (Vertice vertice in vertices)
                {
                    escritor.write(vertice.obterLinhaArquivo() + "\n");
                }
                escritor.close();
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
    
        public void LerArquivo(string caminhoArquivo) 
        {
            //ler arquivo com grafos
            try
            {
                /*
                 
                 */
                BufferedReader leitor = new BufferedReader(new FileReader(caminhoArquivo));
                List<String[]> linhas = new List<String[]>();
                String linhaAtual = leitor.readLine();
                while (linhaAtual != null)
                {
                    String[] valores = linhaAtual.Split("\t");
                    linhas.Add(valores);
                    this.AdicionarVertice(valores[0]);
                    linhaAtual = leitor.readLine();
                }
                
                foreach (String[] linha in linhas)
                {
                    for (int i = 1; i < linha.Length; i++)
                    {
                        String[] termos = linha[i].Split(",");
                        Vertice conecta = this.PesquisaVertice(termos[0]);
                        double peso = Convert.ToDouble(termos[1]);
                        this.PesquisaVertice(linha[0]).adicionarArco(conecta, peso);
                        //System.out.println(linha[0] + " com " + termos[0] + " peso " + peso);
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
