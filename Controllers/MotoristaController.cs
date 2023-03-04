using L01_2020VA601.Data;
using L01_2020VA601.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01_2020VA601.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoristaController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public MotoristaController(ApplicationContext db)
        {
            _db = db;
        }


        // GET_ALL
        #region GET_ALL - GET
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {

            List<Motorista> motoristasList = _db.Motoristas.ToList();


            if (motoristasList.Count == 0)
            {
                return NotFound();
            }

            return Ok(motoristasList);
        }
        #endregion

        // CREAR
        #region AGREGAR - POST
        [HttpPost]
        [Route("Add")]
        public IActionResult crear([FromBody] Motorista motorista)
        {

            try
            {
                _db.Motoristas.Add(motorista);
                _db.SaveChanges();

                return Ok(motorista);

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
        public IActionResult actualizar(int id, [FromBody] Motorista motorista)
        {
            Motorista? motoristaExistente = _db.Motoristas.Find(id);

            if (motoristaExistente == null)
            {
                return NotFound();
            }

            motoristaExistente.nombreMotorista = motorista.nombreMotorista;

            _db.Entry(motoristaExistente).State = EntityState.Modified;
            _db.SaveChanges();

            return Ok(motoristaExistente);

        }

        #endregion

        // ELIMINAR
        #region ELIMINAR - DELETE 
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult EliminarMotorista(int id)
        {
            Motorista? motoristaExistente = _db.Motoristas.Find(id);

            if (motoristaExistente == null) return NotFound();

            _db.Entry(motoristaExistente).State = EntityState.Deleted;
            _db.SaveChanges();

            return Ok(motoristaExistente);

        }
        #endregion

        // FIND BY NAME 
        #region FIND - GET
        [HttpGet]
        [Route("Find")]
        public ActionResult Find(string filtro)
        {
            List<Motorista>? motoristaList = _db.Motoristas.Where((x => (x.nombreMotorista.Contains(filtro) ))).ToList();

            if (motoristaList.Any())
            {
                return Ok(motoristaList);

            }

            return NotFound();
        }
        #endregion

    }
}
