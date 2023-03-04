using L01_2020VA601.Data;
using L01_2020VA601.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01_2020VA601.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        private readonly ApplicationContext _db;

        public PedidoController(ApplicationContext db)
        {
            _db = db;
        }


        // GET_ALL
        #region GET_ALL - GET
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {

            List<Pedido> pedidosLista = _db.Pedidos.ToList();


            if (pedidosLista.Count == 0)
            {
                return NotFound();
            }

            return Ok(pedidosLista);
        }
        #endregion

        // CREAR
        #region AGREGAR - POST
        [HttpPost]
        [Route("Add")]
        public IActionResult crear([FromBody] Pedido pedido)
        {

            try
            {
                _db.Pedidos.Add(pedido);
                _db.SaveChanges();

                return Ok(pedido);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        // ACTUALIZAR
        #region ACTUALIZAR - POST

        [HttpPut]
        [Route("Actualizar/{id}")]
        public IActionResult actualizar(int id, [FromBody] Pedido pedido)
        {
            Pedido? pedidoExistente = _db.Pedidos.Find(id);

            if (pedidoExistente == null)
            {
                return NotFound();
            }

            pedidoExistente.motoristaId = pedido.motoristaId;
            pedidoExistente.clienteId = pedido.clienteId;
            pedidoExistente.platoId = pedido.platoId;
            pedidoExistente.cantidad = pedido.cantidad;
            pedidoExistente.precio = pedido.precio;


            _db.Entry(pedidoExistente).State = EntityState.Modified;
            _db.SaveChanges();

            return Ok(pedidoExistente);

        }

        #endregion

        // ELIMINAR
        #region ELIMINAR - DELETE 
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult EliminarMotorista(int id)
        {
            Pedido? pedidoExistente = _db.Pedidos.Find(id);

            if (pedidoExistente == null) return NotFound();

            _db.Entry(pedidoExistente).State = EntityState.Deleted;
            _db.SaveChanges();

            return Ok(pedidoExistente);

        }
        #endregion

        // FIND BY CLIENTE 
        #region FIND by cliente - GET 
        [HttpGet]
        [Route("FindByClient")]
        public ActionResult FindByClient(int filtro)
        {
            List<Pedido>? pedidosList = _db.Pedidos.Where(x => x.clienteId == filtro).ToList();

            if (pedidosList.Any())
            {
                return Ok(pedidosList);

            }

            return NotFound();
        }
        #endregion

        // FIND BY CLIENTE 
        #region FIND by cliente - GET 
        [HttpGet]
        [Route("FindByMotorista")]
        public ActionResult FindByMotorista(int filtro)
        {
            List<Pedido>? pedidosList = _db.Pedidos.Where(x => x.motoristaId == filtro).ToList();

            if (pedidosList.Any())
            {
                return Ok(pedidosList);

            }

            return NotFound();
        }
        #endregion

    }
}
