using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using GestionPlaneacionDidacticaAPI.Models;
using GestionPlaneacionDidacticaAPI.Data;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;


namespace GestionPlaneacionDidacticaAPI.Controllers
{
    
    public class PlaneacionController : ControllerBase
    {

        private readonly DBContext DBLContext;

        public PlaneacionController(DBContext DBPContext)
        {
            DBLContext = DBPContext;
        }

        
        // Obtiene todas las planeaciones
        [HttpGet]
        [Route("api/Planeaciones")]
        public ContentResult GetPlaneaciones()
        {
            var res = from EP in DBLContext.eva_planeacion
                      select EP;
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        //CREAR NUEVA PLANEACION
        [HttpPost]
        [Route("api/Planeaciones/NewPlaneacion/")]
        public IActionResult newPlaneacion([FromBody]eva_planeacion planeacion)
        {
            if (ModelState.IsValid)
            {
                DBLContext.eva_planeacion.Add(planeacion);
                DBLContext.SaveChanges();
                return new ObjectResult("Planeacion insertada");
            }
            return BadRequest();
        }

        //ACTUALIZAR PLANEACIÓN
        [HttpPut]
        [Route("api/Planeaciones/UpdatePlaneacion/{id}")]
        public IActionResult updatePlaneacion(int id, [FromBody]eva_planeacion planeacion)
        {
            if (ModelState.IsValid)
            {
                DBLContext.Entry<eva_planeacion>(planeacion).State = EntityState.Modified;
                DBLContext.SaveChanges();
                return new ObjectResult("Planeación " + id + " modificada");
            }
            return BadRequest();
        }

        //ELIMINAR PLANEACIÓN
        [HttpDelete]
        [Route("api/Planeaciones/DeletePlaneacion/{id}")]
        public IActionResult deletePlaneacion(int id)
        {
            if (ModelState.IsValid)
            {
                DBLContext.eva_planeacion.Remove(DBLContext.eva_planeacion.Find(id));
                DBLContext.SaveChanges();
                return new ObjectResult("Planeación " + id + " eliminada");
            }
            return BadRequest();
        }

        // Obtiene una planeacion por id
        [HttpGet]
        [Route("api/Planeaciones/{idPlaneacion}")]
        public ContentResult GetPlaneacion(short idPlaneacion)
        {
            var planeacion = DBLContext.eva_planeacion.Find(idPlaneacion);
            string result = JsonConvert.SerializeObject(planeacion);
            return Content(result, "application/json");
        }

        
        // Obtiene todos los temas de la planeación
        [HttpGet]
        [Route("api/Planeaciones/{id}/Temas")]
        public ContentResult GetPlaneacionTemas(short id)
        {
            var res = from EPT in DBLContext.eva_planeacion_temas
                      where EPT.IdPlaneacion.Equals(id)
                      select EPT;
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        // Obtiene un tema de la planeación
        [HttpGet]
        [Route("api/Planeacion/{idPlaneacion}/Temas/{idTema}")]
        public ContentResult GetPlaneacionTemas(short idPlaneacion,short idTema)
        {
            var res = from EPT in DBLContext.eva_planeacion_temas
                      where EPT.IdPlaneacion.Equals(idPlaneacion) && EPT.IdTema.Equals(idTema)
                      select EPT;
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

    }
}