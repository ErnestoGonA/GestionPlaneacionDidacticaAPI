using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using GestionPlaneacionDidacticaAPI.Data;
using GestionPlaneacionDidacticaAPI.Models;

namespace GestionPlaneacionDidacticaAPI.Controllers
{
    public class ApoyosController : Controller
    {
        private readonly DBContext DBLContext;

        public ApoyosController(DBContext DBPContext)
        {
            DBLContext = DBPContext;
        }

        // Obtiene todos los apoyos de la planeación
        [HttpGet]
        [Route("api/Planeaciones/Apoyos")]
        public ContentResult GetPlaneacionApoyos()
        {
            var res = from EPA in DBLContext.eva_planeacion_apoyos
                      select EPA;

            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        // LISTA DE FUENTES DE PLANEACION
        [HttpGet]
        [Route("api/Planeacion/{idPlaneacion}/Apoyos/{idAsignatura}")]
        public ContentResult GetPlaneacionApoyos(short idPlaneacion, short idAsignatura)
        {
            var res = from EPT in DBLContext.eva_planeacion_apoyos
                      where EPT.IdPlaneacion.Equals(idPlaneacion)
                      where EPT.IdAsignatura.Equals(idAsignatura)
                      select EPT;
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [HttpGet]
        [Route("api/Planeacion/{idPlaneacion}/Apoyos/{idAsignatura}/{idApoyo}")]
        public ContentResult GetApoyo(short idPlaneacion, short idAsignatura, short idApoyo)
        {
            System.Diagnostics.Debug.WriteLine("\n\n\n\n\n\n\n\n\n\n\ncPAF:  " + idPlaneacion + idAsignatura + idApoyo);

            string result;
            //var respuesta DBLContext.eva_planeacion_fuentes.Where()
            var res = from EPT in DBLContext.eva_planeacion_apoyos
                      where EPT.IdPlaneacion.Equals(idPlaneacion)
                      where EPT.IdAsignatura.Equals(idAsignatura)
                      where EPT.IdApoyoDidactico.Equals(idApoyo)
                      select EPT;
            try
            {
                result = JsonConvert.SerializeObject(res.Single());
                return Content(result, "application/json");
            }
            catch (Exception e)
            {
                eva_planeacion_apoyos ras = new eva_planeacion_apoyos();
                ras.IdApoyoDidactico = -1;
                result = JsonConvert.SerializeObject(ras);
                return Content(result, "application/json");
            }
        }

        //CREAR NUEVA FUENTE
        [HttpPost]
        [Route("api/NewApoyo/")]
        public IActionResult newApoyo([FromBody]eva_planeacion_apoyos apoyo)
        {
            if (ModelState.IsValid)
            {
                DBLContext.eva_planeacion_apoyos.Add(apoyo);
                DBLContext.SaveChanges();
                return new ObjectResult("Apoyo insertado");
            }
            return BadRequest();
        }

        //ACTUALIZAR FUENTE
        [HttpPut]
        [Route("api/UpdateApoyo/")]
        public IActionResult updateApoyo(int id, [FromBody]eva_planeacion_apoyos apoyo)
        {
            if (ModelState.IsValid)
            {
                DBLContext.Entry<eva_planeacion_apoyos>(apoyo).State = EntityState.Modified;
                DBLContext.SaveChanges();
                return new ObjectResult("Apoyo " + id + " modificado");
            }
            return BadRequest();
        }

        //ELIMINAR FUENTE
        [HttpDelete]
        [Route("api/DeleteApoyo/{idApoyo}/{idAsignatura}/{idPlaneacion}")]
        public IActionResult deleteApoyo(short idApoyo, short idAsignatura, short idPlaneacion)
        {
            if (ModelState.IsValid)
            {
                DBLContext.eva_planeacion_apoyos.Remove(DBLContext.eva_planeacion_apoyos.Where(x => x.IdApoyoDidactico == idApoyo)
                                                                                           .Where(x => x.IdAsignatura == idAsignatura)
                                                                                           .Where(x => x.IdAsignatura == idPlaneacion).Single());
                DBLContext.SaveChanges();
                return new ObjectResult("Fuente " + idApoyo + " eliminada");
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("api/Planeacion/NombresApoyosDidacticos")]
        public IActionResult GetFuentesB()
        {
            var res = from ac in DBLContext.eva_cat_apoyos_didacticos.ToList()
                      select new
                      {
                          ac.IdApoyoDidactico,
                          ac.DesApoyoDidactico
                      };
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");

        }
    }
}