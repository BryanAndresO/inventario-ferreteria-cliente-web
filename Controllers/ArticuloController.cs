using Microsoft.AspNetCore.Mvc;
using System.ServiceModel;
using inventario_ferreteria_cliente.Models;
using ServicioArticuloReference;

namespace inventario_ferreteria_cliente.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly ServicioArticulosClient _client;

        public ArticulosController()
        {
            var binding = new BasicHttpBinding
            {
                SendTimeout = TimeSpan.FromMinutes(5),
                ReceiveTimeout = TimeSpan.FromMinutes(5)
            };
            _client = new ServicioArticulosClient(binding, new EndpointAddress("http://10.164.184.45:7208/Service.svc"));
        }

        // Página principal
        public IActionResult Index()
        {
            return View();
        }

        // 🔍 Buscar artículo por código
        [HttpGet]
        public IActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buscar(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                ViewBag.Mensaje = "Debe ingresar un código.";
                return View();
            }

            try
            {
                var articulo = _client.ConsultarArticuloPorCodigoSoap(codigo);

                if (articulo == null)
                {
                    ViewBag.Mensaje = "No se encontró el artículo.";
                    return View();
                }

                var model = new ArticuloViewModel
                {
                    Codigo = articulo.Codigo,
                    Nombre = articulo.Nombre,
                    Categoria = articulo.Categoria,
                    Preciocompra = articulo.Preciocompra,
                    Precioventa = articulo.Precioventa,
                    Stock = articulo.Stock,
                    Proveedor = articulo.Proveedor,
                    Stockminimo = articulo.Stockminimo
                };

                return View("Detalles", model);
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = $"Error al consultar el servicio: {ex.Message}";
                return View();
            }
        }

        // 🆕 Crear nuevo artículo
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(ArticuloViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var articulo = new Articulo
                {
                    Codigo = model.Codigo,
                    Nombre = model.Nombre,
                    Categoria = model.Categoria,
                    Preciocompra = model.Preciocompra,
                    Precioventa = model.Precioventa,
                    Stock = model.Stock,
                    Proveedor = model.Proveedor,
                    Stockminimo = model.Stockminimo
                };

                var resultado = _client.InsertarArticuloSoap(articulo);

                ViewBag.Mensaje = resultado.Message;
                return View("Resultado");
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = $"Error al registrar: {ex.Message}";
                return View(model);
            }
        }
    }
}
