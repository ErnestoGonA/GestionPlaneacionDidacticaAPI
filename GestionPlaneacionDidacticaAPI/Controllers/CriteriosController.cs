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
    public class CriteriosController : ControllerBase
    {
        private readonly DBContext DBLContext;

        public CriteriosController(DBContext DBPContext)
        {
            DBLContext = DBPContext;
        }

        [HttpGet]
        [Route("api/Asignatura/{IdAsignatura}/Planeacion/{IdPlaneacion}/Temas/{IdTema}/Competencias/{IdCompetencia}/Criterios")]
        public ContentResult GetPlaneacionTemasCompetenciasCriterios(short IdAsignatura, int IdPlaneacion, short IdTema,short IdCompetencia)
        {
            var res = from EPT in DBLContext.eva_planeacion_criterios_evalua
                      where EPT.IdAsignatura.Equals(IdAsignatura)
                      where EPT.IdPlaneacion.Equals(IdPlaneacion)
                      where EPT.IdTema.Equals(IdTema)
                      where EPT.IdCompetencia.Equals(IdCompetencia)
                      select EPT;
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [HttpGet]
        [Route("api/Asignatura/{IdAsignatura}/Planeacion/{IdPlaneacion}/Temas/{IdTema}/Competencias/{IdCompetencia}/Criterios/{IdCriterio}")]
        public ContentResult GetPlaneacionTemasCompetenciasCriterios(short IdAsignatura, int IdPlaneacion, short IdTema, short IdCompetencia,short IdCriterio)
        {
            var res = (from EPT in DBLContext.eva_planeacion_criterios_evalua
                      where EPT.IdAsignatura.Equals(IdAsignatura)
                      where EPT.IdPlaneacion.Equals(IdPlaneacion)
                      where EPT.IdTema.Equals(IdTema)
                      where EPT.IdCompetencia.Equals(IdCompetencia)
                      where EPT.IdCriterio.Equals(IdCriterio)
                      select EPT).Single();
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        //CREAR NUEVA PLANEACION
        [HttpPost]
        [Route("api/criterio")]
        public IActionResult PostCriterop([FromBody]eva_planeacion_criterios_evalua Criterio)
        {
            if (ModelState.IsValid)
            {
                int count = 0;
                if (DBLContext.eva_planeacion_criterios_evalua.Find(Criterio.IdCriterio) != null)
                {
                    count = DBLContext.eva_planeacion_criterios_evalua.Max(criterio => criterio.IdCriterio);
                }

                Criterio.IdCriterio = ++count;
                DBLContext.eva_planeacion_criterios_evalua.Add(Criterio);
                DBLContext.SaveChanges();
                return new ObjectResult("Criterio insertado");
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("api/criterio")]
        public IActionResult PutCriterio([FromBody]eva_planeacion_criterios_evalua Criterio)
        {
            if (ModelState.IsValid)
            {
                DBLContext.Entry<eva_planeacion_criterios_evalua>(Criterio).State = EntityState.Modified;
                DBLContext.SaveChanges();
                return new ObjectResult("Actualizado correctamente");
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("api/Asignatura/{IdAsignatura}/Planeacion/{IdPlaneacion}/Temas/{IdTema}/Competencias/{IdCompetencia}/Criterios/{IdCriterio}")]
        public IActionResult DeletePlaneacionTemas(short IdAsignatura, int IdPlaneacion, short IdTema,short IdCompetencia, short IdCriterio)
        {
            DBLContext.eva_planeacion_criterios_evalua.Remove((from tema in DBLContext.eva_planeacion_criterios_evalua
                                                                   where tema.IdAsignatura == IdAsignatura
                                                                   where tema.IdPlaneacion == IdPlaneacion
                                                                   where tema.IdTema == IdTema
                                                                   where tema.IdCompetencia == IdCompetencia
                                                                   where tema.IdCriterio == IdCriterio
                                                                   select tema).First());
            DBLContext.SaveChanges();
            return new ObjectResult("Borrado correctamente");

        }

    }
}