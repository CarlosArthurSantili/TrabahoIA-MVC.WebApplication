using java.io;
using System;
using System.Collections.Generic;
using TrabalhoIA_MVC.ClassLibrary.Algoritmos;
using TrabalhoIA_MVC.ClassLibrary.Shared;

namespace TesteLeituraGrafo
{
    class Program
    {
        static void Main(string[] args)
        {
            Grafo grafo = new Grafo();
            string path = "C:\\Users\\luizp\\OneDrive\\Documentos\\Ciência da computação\\6º Fase\\Inteligência Artificial\\Lista de adjacência - Página1.tsv";
            grafo.LerArquivo(path);

            AlgoritmoBuscaProfundidade algo = new AlgoritmoBuscaProfundidade(grafo, grafo.PesquisaVertice("A0"));
            var resultado = algo.RealizarBusca(grafo.PesquisaVertice("A2"));

        }
    }
}
