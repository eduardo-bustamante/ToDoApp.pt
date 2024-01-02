using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ToDoApp.pt.Models;

namespace ToDoApp.pt.Controllers
{
    public class HomeController : Controller
    {
        private ToDoContext context;

        public HomeController(ToDoContext ctx) => context = ctx;

        public IActionResult Index(string id)
        {
            var filtros = new Filtros(id);
            ViewBag.Filtros = filtros;

            ViewBag.Categorias = context.Categorias.ToList();
            ViewBag.Situacoes = context.Situacoes.ToList();
            ViewBag.FiltrosPrevisao = Filtros.FiltroPrevisaoValores;

            IQueryable<ToDo> query = context.ToDos.Include(t => t.Categoria).Include(t => t.Situacao);


            if (filtros.TemCategoria)
            {
                query = query.Where(t => t.CategoriaId == id);
            }

            if (filtros.TemSituacao)
            {
                query = query.Where(t => t.SituacaoId == id);
            }

            if (filtros.TemPrevisao)
            {
                var hoje = DateTime.Today;
                if (filtros.EPassado)
                {
                    query = query.Where(t => t.Vencimento < hoje);

                }
                else if (filtros.EFuturo)
                {
                    query = query.Where(t => t.Vencimento > hoje);

                }
                else if (filtros.EHoje)
                {
                    query = query.Where(t => t.Vencimento == hoje);

                }

            }

            var tarefas = query.OrderBy(t => t.Vencimento).ToList();

            return View(tarefas);
        }
        [HttpGet]
        public IActionResult Adicionar()
        {
            ViewBag.Categorias = context.Categorias.ToList();
            ViewBag.Situacoes = context.Situacoes.ToList();

            var tarefas = new ToDo { SituacaoId = "aberto" };
            return View(tarefas);

        }

        [HttpPost]
        public IActionResult Adicionar(ToDo tarefas)
        {
            if (ModelState.IsValid)
            {
                context.ToDos.Add(tarefas);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categorias = context.Categorias.ToList();
                ViewBag.Situacoes = context.Situacoes.ToList();
                return View(tarefas);
            }
        }

        [HttpPost]
        public IActionResult Filtro(string[] filtro)
        {
            string id = string.Join('-', filtro);

            return RedirectToAction("Index", new { ID = id });
        }

        [HttpPost]
        public IActionResult Realizado([FromRoute] string id, ToDo selecionado)
        {
            selecionado = context.ToDos.Find(selecionado.Id);

            if (selecionado != null)
            {
                selecionado.SituacaoId = "concluido";
                context.SaveChanges();
            }

            return RedirectToAction("Index", new { ID = id });
        }

        [HttpPost]
        public IActionResult DeleteRealizado(string id)
        {
            var paraApagar = context.ToDos.Where(t => t.SituacaoId == "concluido").ToList();

            foreach (var tarefas in paraApagar)
            {
                context.ToDos.Remove(tarefas);
            }
            context.SaveChanges();

            return RedirectToAction("Index", new { ID = id });


        }

    }
}
