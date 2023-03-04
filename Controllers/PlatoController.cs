using L01_2020VA601.Data;
using L01_2020VA601.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01_2020VA601.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatoController : ControllerBase
    {

        private readonly ApplicationContext _db;

        public PlatoController(ApplicationContext db)
        {
            _db = db;
        }

        #region GET_ALL - GET
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {

            List<Plato> platosList = _db.Platos.ToList();


            if (platosList.Count == 0)
            {
                return NotFound();
            }

            return Ok(platosList);
        }
        #endregion

        // CREAR
        #region AGREGAR - POST
        [HttpPost]
        [Route("Add")]
        public IActionResult crear([FromBody] Plato plato)
        {

            try
            {
                _db.Platos.Add(plato);
                _db.SaveChanges();

                return Ok(plato);

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
        public IActionResult actualizar(int id, [FromBody] Plato plato)
        {
            Plato? platoExistente = _db.Platos.Find(id);

            if (platoExistente == null)
            {
                return NotFound();
            }

            platoExistente.nombrePlato = plato.nombrePlato;
            platoExistente.precio = plato.precio;

            _db.Entry(platoExistente).State = EntityState.Modified;
            _db.SaveChanges();

            return Ok(platoExistente);

        }

        #endregion

        // ELIMINAR
        #region ELIMINAR - DELETE 
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult EliminarMotorista(int id)
        {
            Plato? platoExistente = _db.Platos.Find(id);

            if (platoExistente == null) return NotFound();

            _db.Entry(platoExistente).State = EntityState.Deleted;
            _db.SaveChanges();

            return Ok(platoExistente);

        }
        #endregion

        // FIND BY PRICE 
        #region FIND - GET
        [HttpGet]
        [Route("Find")]
        public ActionResult Find(string filtro)
        {
            List<Plato>? platoList = _db.Platos.Where((x => (x.precio < Decimal.Parse(filtro)))).ToList();

            if (platoList.Any())
            {
                return Ok(platoList);

            }

            return NotFound();
        }
        #endregion

    }
}
