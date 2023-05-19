using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaCadastroProd.Models;

namespace SistemaCadastroProd.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProductDAL prod;
        public ProdutoController(IProductDAL product)
        {
            prod = product;
        }
        public IActionResult Index()
        {
            List<Produto> listaProduto = new List<Produto>();
            listaProduto = prod.GetAllProdutos().ToList();
            return View(listaProduto);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Produto produto = prod.GetProduto(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Produto produto)
        {
            if (ModelState.IsValid)
            {
                prod.AddProduto(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Produto produto = prod.GetProduto(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                prod.UpdateProduto(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Produto produto = prod.GetProduto(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            prod.DeleteProduto(id);
            return RedirectToAction("Index");
        }
    }
}
