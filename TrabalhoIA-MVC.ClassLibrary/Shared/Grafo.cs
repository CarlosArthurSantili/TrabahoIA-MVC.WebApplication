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

        //alterar parametro para string?
        public Grafo(File arquivo)
        {
            try
            {
                this.lerArquivo(arquivo);
            }
            catch (IOException e)
            {
                throw e;
            }
        }

        public void adicionarVertice(String rotulo)
        {
            Vertice novo = new Vertice(rotulo);
            vertices.Add(novo);
        }

        public List<Vertice> obterVertices()
        {
            return this.vertices;
        }

        public Vertice pesquisaVertice(String rotulo)
        {
            int indice = vertices.IndexOf(new Vertice(rotulo));
            return (indice >= 0) ? vertices[(indice)] : null;
        }

        //alterar parametro para string?
        public void gravarArquivo(File arquivo)
        {
            try
            {
                BufferedWriter escritor = new BufferedWriter(new FileWriter(arquivo));
                foreach (Vertice vertice in vertices)
                {
                    escritor.write(vertice.obterLinhaArquivo() + "\n");
                }
                escritor.close();
            }
            catch(IOException e)
            {
                throw e;
            }
            
        }
    
        /**
         * Esta funÃ§Ã£o lÃª um arquivo texto contendo o grafo representado em lista
         * de adjacÃªncia. O arquivo deve conter uma linha para vÃ©rtice, tendo como a
         * primeira informaÃ§Ã£o linha o nome do vÃ©rtice e, separados por tabulaÃ§Ã£o, 
         * os nomes e pesos dos demais vÃ©rtices com os quais existem arcos. Ex.:
         * A    B,2     C,4
         * B    A,1.3
         * C    B,2.5
         * NÃ£o devem haver caracteres de espaÃ§o.
         * Os pesos podem ser inteiros ou reais.
         * @param arquivo Objeto da classe File para o arquivo a ser lido.
         * @throws IOException 
         */
        public void lerArquivo(File arquivo) 
        {
            try
            {
                BufferedReader leitor = new BufferedReader(new FileReader(arquivo));
                List<String[]> linhas = new List<String[]>();
                String linhaAtual = leitor.readLine();
                while (linhaAtual != null)
                {
                    String[] valores = linhaAtual.Split("\t");
                    linhas.Add(valores);
                    this.adicionarVertice(valores[0]);
                    linhaAtual = leitor.readLine();
                }

                foreach (String[] linha in linhas)
                {
                    for (int i = 1; i < linha.Length; i++)
                    {
                        String[] termos = linha[i].Split(",");
                        Vertice conecta = this.pesquisaVertice(termos[0]);
                        double peso = Convert.ToDouble(termos[1]);
                        this.pesquisaVertice(linha[0]).adicionarArco(conecta, peso);
                        //System.out.println(linha[0] + " com " + termos[0] + " peso " + peso);
                    }
                }
            }
            catch (IOException e)
            {
                throw e;
            }
            
        }
    
        public List<Arco> obterTodosOsArcos()
        {
            List<Arco> resultado = new List<Arco>();
            foreach (Vertice vertice in vertices) 
            {
                foreach (Arco arco in vertice.obterArcos())
                    resultado.Add(arco);
            }
            return resultado;
        }
    }
}
