using cadastro_cliente_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;


namespace cadastro_cliente_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CadastroClientDbContext _context;
        public HomeController(ILogger<HomeController> logger, CadastroClientDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        //Páginas
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Adicionar(int? id)
        {

            var client_inf = _context.Clientes.SingleOrDefault(c => c.Id == id);

            return View(client_inf);

        }
        public IActionResult Editar(int? id) 
        {
            var client_inf = _context.Clientes.SingleOrDefault(c => c.Id == id);

            return View(client_inf);
        }
        public IActionResult Clientes()
        {
            var ClientesLista = _context.Clientes.ToList();
            return View(ClientesLista);
        }

        //métodos
        public IActionResult Criar_Editar_form(Cliente c)
        {   
            if(c.Id == 0 )//caso não tem id é pq não esta na tabela.se for 0 é pq nao esta na tabela
            {   
                 

                _context.Clientes.Add(c);


            }else//caso tenha id é pq esta na tabela
            {
                _context.Clientes.Update(c);
  
            }

            _context.SaveChanges();

            return RedirectToAction("Clientes");
        }

        public IActionResult Deletar(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

            _context.Clientes.Remove(cliente);

            _context.SaveChanges();

            return RedirectToAction("Clientes");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
