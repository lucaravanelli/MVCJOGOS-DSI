using CadastrarJogos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrarJogos.Controllers
{
    public class JogosController : Controller
    {
        private readonly Contexto _contexto;

        public JogosController(Contexto contexto)
        {
            _contexto = contexto;
        }



        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Jogos.ToListAsync());
        }

        [HttpGet]
        public IActionResult CriarJogo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarJogo(Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(jogo);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            else return View(jogo);
        }

        [HttpGet]
        public IActionResult AtualizarJogo(int? id)
        {
            if (id != null)
            {
                Jogo jogo = _contexto.Jogos.Find(id);
                return View(jogo);
            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarJogo(int? id, Jogo jogo)
        {
            if (id != null)
            {
                if (ModelState.IsValid)
                {

                    _contexto.Update(jogo);
                    await _contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else return View(jogo);
            }
            else return NotFound();
        }

        [HttpGet]
        public IActionResult ExcluirJogo(int? id)
        {
            if (id != null)
            {
                Jogo jogo = _contexto.Jogos.Find(id);
                return View(jogo);
            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirJogo(int? id, Jogo jogo)
        {
            if (id != null)
            {
                _contexto.Remove(jogo);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return NotFound();
        }
    }
}
