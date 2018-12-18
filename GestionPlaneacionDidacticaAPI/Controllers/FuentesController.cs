using GestionPlaneacionDidacticaAPI.Data;
using GestionPlaneacionDidacticaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPlaneacionDidacticaAPI.Controllers
{
    public class FuentesController : ControllerBase
    {
        private readonly DBContext DBLContext;

        public FuentesController(DBContext DBPContext)
        {
            DBLContext = DBPContext;
        }

        
        // LISTA DE FUENTES DE PLANEACION
        [HttpGet]
        [Route("api/Planeacion/{idPlaneacion}/Fuentes/{idAsignatura}")]
        public ContentResult GetPlaneacionFuentes(short idPlaneacion,short idAsignatura)
        {
            var res = from EPT in DBLContext.eva_planeacion_fuentes
                      where EPT.IdPlaneacion.Equals(idPlaneacion)
                      where EPT.IdAsignatura.Equals(idAsignatura)
                      join ap in DBLContext.eva_cat_fuentes_bibliograficas on EPT.IdFuente equals ap.IdFuente
                      join asi in DBLContext.eva_cat_asignaturas on EPT.IdAsignatura equals asi.IdAsignatura
                      join pla in DBLContext.eva_planeacion on EPT.IdPlaneacion equals pla.IdPlaneacion
                      select new
                      {
                          EPT.IdAsignatura,
                          EPT.IdPlaneacion,
                          EPT.IdFuente,
                          EPT.Observaciones,
                          EPT.Prioridad,
                          EPT.UsuarioMod,
                          EPT.UsuarioReg,
                          EPT.FechaReg,
                          EPT.FechaUltMod,
                          EPT.Activo,
                          EPT.Borrado,
                          ap.DesFuenteCompleta,
                          asi.NombreCorto,
                          pla.ReferenciaNorma
                      };
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [HttpGet]
        [Route("api/Planeacion/{idPlaneacion}/Fuentes/{idAsignatura}/{idFuente}")]
        public ContentResult GetFuente(short idPlaneacion,short idAsignatura,short idFuente)
        {
            System.Diagnostics.Debug.WriteLine("\n\n\n\n\n\n\n\n\n\n\ncPAF:  " + idPlaneacion + idAsignatura + idFuente);

            string result;
            //var respuesta DBLContext.eva_planeacion_fuentes.Where()
            var res = from EPT in DBLContext.eva_planeacion_fuentes
                      where EPT.IdPlaneacion.Equals(idPlaneacion)
                      where EPT.IdAsignatura.Equals(idAsignatura)
                      where EPT.IdFuente.Equals(idFuente)
                      select EPT;
            try
            {
                result = JsonConvert.SerializeObject(res.Single());
                return Content(result, "application/json");
            }
            catch(Exception e){
                eva_planeacion_fuentes ras = new eva_planeacion_fuentes();
                ras.IdFuente = -1;
                result = JsonConvert.SerializeObject(ras);
                return Content(result, "application/json");
            }
            


        }


        //CREAR NUEVA FUENTE
        [HttpPost]
        [Route("api/NewFuente/")]
        public IActionResult newFuente([FromBody]eva_planeacion_fuentes planeacion)
        {
            if (ModelState.IsValid)
            {
                DBLContext.eva_planeacion_fuentes.Add(planeacion);
                DBLContext.SaveChanges();
                return new ObjectResult("Fuente insertada");
            }
            return BadRequest();
        }

        //ACTUALIZAR FUENTE
        [HttpPut]
        [Route("api/UpdateFuente/")]
        public IActionResult updatePlaneacion(int id, [FromBody]eva_planeacion_fuentes planeacion)
        {
            if (ModelState.IsValid)
            {
                DBLContext.Entry<eva_planeacion_fuentes>(planeacion).State = EntityState.Modified;
                DBLContext.SaveChanges();
                return new ObjectResult("Fuente " + id + " modificada");
            }
            return BadRequest();
        }

        //ELIMINAR FUENTE
        [HttpDelete]
        [Route("api/DeleteFuente/{idFuente}/{idAsignatura}/{idPlaneacion}")]
        public IActionResult deletePlaneacion(short idFuente, short idAsignatura, short idPlaneacion)
        {
            if (ModelState.IsValid)
            {
                DBLContext.eva_planeacion_fuentes.Remove(DBLContext.eva_planeacion_fuentes.Where(x=>x.IdFuente == idFuente)
                                                                                           .Where(x => x.IdAsignatura == idAsignatura)
                                                                                           .Where(x => x.IdAsignatura == idPlaneacion).Single());
                DBLContext.SaveChanges();
                return new ObjectResult("Fuente " + idFuente + " eliminada");
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("api/Planeacion/NombresFuentes")]
        public IActionResult GetFuentesB()
        {
            var res = from ac in DBLContext.eva_cat_fuentes_bibliograficas.ToList()
                      select new
                      {
                          ac.IdFuente,
                          ac.DesFuenteCompleta
                      };
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");

        }


    }
}
