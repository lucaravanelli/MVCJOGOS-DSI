using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CadastrarJogos.Models
{
    public class JogoView
    {
        public List<Jogo> Jogos { get; set; }
        public SelectList Generos { get; set; }
        public string JogoGenero { get; set; }
        public string SearchString { get; set; }
    }
}
