using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoIA_MVC.ClassLibrary.Shared
{
    public class Robo
    {
        string nome;
        Coordenada localizacao;
        
        public Robo(string nome, Coordenada localizacao) 
        {
            this.nome = nome;
            this.localizacao = localizacao;
        }
    }
}
