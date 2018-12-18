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
    public class CompetenciasController : ControllerBase
    {
        private readonly DBContext DBLContext;

        public CompetenciasController(DBContext DBPContext)
        {
            DBLContext = DBPContext;
        }

        [HttpGet]
        [Route("api/Asignatura/{IdAsignatura}/Planeacion/{IdPlaneacion}/Temas/{IdTema}/Competencias")]
        public ContentResult GetPlaneacionTemasCompetencias(short IdAsignatura, int IdPlaneacion, short IdTema)
        {
            var res = from EPT in DBLContext.eva_planeacion_temas_competencias
                      where EPT.IdAsignatura.Equals(IdAsignatura)
                      where EPT.IdPlaneacion.Equals(IdPlaneacion)
                      where EPT.IdTema.Equals(IdTema)
                      join ap in DBLContext.eva_cat_competencias on EPT.IdCompetencia equals ap.IdCompetencia
                      join asi in DBLContext.eva_cat_asignaturas on EPT.IdAsignatura equals asi.IdAsignatura
                      join pla in DBLContext.eva_planeacion on EPT.IdPlaneacion equals pla.IdPlaneacion
                      select new
                      {
                          EPT.IdAsignatura,
                          EPT.IdPlaneacion,
                          EPT.IdCompetencia,
                          EPT.IdTema,
                          EPT.Observaciones,
                          EPT.Activo,
                          EPT.Borrado,
                          EPT.FechaReg,
                          EPT.FechaUltMod,
                          EPT.UsuarioMod,
                          EPT.UsuarioReg,
                          ap.DesCompetencia,
                          asi.NombreCorto,
                          pla.ReferenciaNorma
                      };
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [HttpGet]
        [Route("api/Asignatura/{IdAsignatura}/Planeacion/{IdPlaneacion}/Temas/{IdTema}/Competencia/{IdCompetencia}")]
        public ContentResult GetPlaneacionTemasCompetencias(short IdAsignatura, int IdPlaneacion, short IdTema, short IdCompetencia)
        {
            try
            {             
                var res = from EPT in DBLContext.eva_planeacion_temas_competencias
                          where EPT.IdAsignatura.Equals(IdAsignatura)
                          where EPT.IdPlaneacion.Equals(IdPlaneacion)
                          where EPT.IdTema.Equals(IdTema)
                          where EPT.IdCompetencia.Equals(IdCompetencia)
                          select EPT;
            
                    var result = JsonConvert.SerializeObject(res.Single());
                    return Content(result, "application/json");
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpGet]
        [Route("api/Asignatura/{IdAsignatura}/Planeacion/{IdPlaneacion}/Temas/{IdTema}/Competencias/{IdCompetencia}")]
        public ContentResult GetPlaneacionTemasCompetencia(short IdAsignatura, int IdPlaneacion, short IdTema,short IdCompetencia)
        {
            string result;
            //var respuesta DBLContext.eva_planeacion_fuentes.Where()
            var res = from EPT in DBLContext.eva_planeacion_temas_competencias
                      where EPT.IdAsignatura.Equals(IdAsignatura)
                      where EPT.IdPlaneacion.Equals(IdPlaneacion)
                      where EPT.IdTema.Equals(IdTema)
                      where EPT.IdCompetencia.Equals(IdCompetencia)
                      select EPT;
            try
            {
                result = JsonConvert.SerializeObject(res.Single());
                return Content(result, "application/json");
            }
            catch (Exception e)
            {
                eva_planeacion_temas_competencias ras = new eva_planeacion_temas_competencias();
                ras.IdCompetencia = -1;
                var result2 = JsonConvert.SerializeObject(ras);
                return Content(result2, "application/json");
            }
            
        }

        [HttpPost]
        [Route("api/Competencia")]
        public IActionResult PostCompetencia([FromBody]eva_planeacion_temas_competencias planeacion)
        {
            if (ModelState.IsValid)
            {
                DBLContext.eva_planeacion_temas_competencias.Add(planeacion);
                DBLContext.SaveChanges();
                return new ObjectResult("competencia insertada");
            }
            return BadRequest();
        }
        
        [HttpPut]
        [Route("api/competencia")]
        public IActionResult PutCompetencia(int id, [FromBody]eva_planeacion_temas_competencias planeacion)
        {
            if (ModelState.IsValid)
            {
                DBLContext.Entry<eva_planeacion_temas_competencias>(planeacion).State = EntityState.Modified;
                DBLContext.SaveChanges();
                return new ObjectResult("Competencia " + id + " modificada");
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("api/Asignatura/{IdAsignatura}/Planeacion/{IdPlaneacion}/Temas/{IdTema}/Competencias/{IdCompetencia}")]
        public IActionResult DelteCompetencia(short IdAsignatura, int IdPlaneacion, short IdTema, short IdCompetencia)
        {
            if (ModelState.IsValid)
            {
                DBLContext.eva_planeacion_temas_competencias.Remove((from EPT in DBLContext.eva_planeacion_temas_competencias
                                                                     where EPT.IdAsignatura.Equals(IdAsignatura)
                                                                     where EPT.IdPlaneacion.Equals(IdPlaneacion)
                                                                     where EPT.IdTema.Equals(IdTema)
                                                                     where EPT.IdCompetencia.Equals(IdCompetencia)
                                                                     select EPT).Single());
                DBLContext.SaveChanges();
                return new ObjectResult("Competencia eliminada");
            }
            return BadRequest();
        }




        [HttpGet]
        [Route("api/CatCompetencias")]
        public IActionResult GetCatCompetencias()
        {
            var res = from ac in DBLContext.eva_cat_competencias.ToList()
                      select new
                      {
                          ac.IdCompetencia,
                          ac.DesCompetencia
                      };
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");

        }


    }
}
