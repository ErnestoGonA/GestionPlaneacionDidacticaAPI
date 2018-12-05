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

        [HttpPost]
        [Route("api/Planeaciones/NewPlaneacion")]
        public IActionResult Post([FromBody]eva_planeacion planeacion)
        {
            if (ModelState.IsValid)
            {
                DBLContext.eva_planeacion.Add(planeacion);
                DBLContext.SaveChanges();
                return new ObjectResult("Planeacion insertada");
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