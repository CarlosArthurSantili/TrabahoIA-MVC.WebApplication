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
            string path = "C:\\Users\\AL\\Documents\\Lista de adjacência - Página1.tsv";
            grafo.LerArquivo(path);

            AlgoritmoAEstrela algoritmoAestrela = new AlgoritmoAEstrela(grafo, grafo.PesquisaVertice("A0"));
            List<Vertice> resultado = algoritmoAestrela.RealizarBusca(grafo.PesquisaVertice("F1"));

            foreach (Vertice item in resultado)
            {
                System.Console.WriteLine(item.rotulo);
            }
            //AlgoritmoBuscaProfundidade algo = new AlgoritmoBuscaProfundidade(grafo, grafo.PesquisaVertice("A0"));
            //var resultado = algo.RealizarBusca(grafo.PesquisaVertice("B3"));

        }
    }
}
