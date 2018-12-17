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
        [Route("api/Planeaciones/{idAsignatura}/{idPeriodo}")]
        public ContentResult GetPlaneaciones(short idAsignatura,short idPeriodo)
        {
            var res = (from EP in DBLContext.eva_planeacion
                      select EP).Where(item => item.IdAsignatura == idAsignatura && item.IdPeriodo == idPeriodo);
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
                var pla = DBLContext.eva_planeacion.Where(item => item.IdAsignatura == planeacion.IdAsignatura).AsNoTracking();
                int maxId = 0;
                if(pla.Count() > 0)
                {
                    maxId = DBLContext.eva_planeacion.AsNoTracking().Max(item => item.IdPlaneacion);
                }
                maxId++;
                planeacion.IdPlaneacion = maxId;
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
        public ContentResult GetPlaneacion(int idPlaneacion)
        {
            var planeacion = DBLContext.eva_planeacion.Find(idPlaneacion);
            string result = JsonConvert.SerializeObject(planeacion);
            return Content(result, "application/json");
        }


        //Exportar
        [HttpPost]
        [Route("api/ExportarPlaneacion")]
        public IActionResult exportar([FromBody]ImportarExportar source_lista)
        {
            if (ModelState.IsValid)
            {
                if (source_lista.eva_planeacion != null)
                {
                    source_lista.eva_planeacion.ForEach(item =>
                    {
                        DBLContext.eva_planeacion.Update(item);
                        DBLContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    });
                }
                if (source_lista.eva_planeacion_apoyos != null)
                {
                    source_lista.eva_planeacion_apoyos.ForEach(item =>
                    {
                        DBLContext.eva_planeacion_apoyos.Update(item);
                        DBLContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    });
                }
                if (source_lista.eva_planeacion_aprendizaje != null)
                {
                    source_lista.eva_planeacion_aprendizaje.ForEach(item =>
                    {
                        DBLContext.eva_planeacion_aprendizaje.Update(item);
                        DBLContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    });
                }
                if (source_lista.eva_planeacion_criterios_evalua != null)
                {
                    source_lista.eva_planeacion_criterios_evalua.ForEach(item =>
                    {
                        DBLContext.eva_planeacion_criterios_evalua.Update(item);
                        DBLContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    });
                }
                if (source_lista.eva_planeacion_enseñanza != null)
                {
                    source_lista.eva_planeacion_enseñanza.ForEach(item =>
                    {
                        DBLContext.eva_planeacion_enseñanza.Update(item);
                        DBLContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    });
                }
                if (source_lista.eva_planeacion_fuentes != null)
                {
                    source_lista.eva_planeacion_fuentes.ForEach(item =>
                    {
                        DBLContext.eva_planeacion_fuentes.Update(item);
                        DBLContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    });
                }
                if (source_lista.eva_planeacion_mejora_desempeño != null)
                {
                    source_lista.eva_planeacion_mejora_desempeño.ForEach(item =>
                    {
                        DBLContext.eva_planeacion_mejora_desempeño.Update(item);
                        DBLContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    });
                }
                if (source_lista.eva_planeacion_subtemas != null)
                {
                    source_lista.eva_planeacion_subtemas.ForEach(item =>
                    {
                        DBLContext.eva_planeacion_subtemas.Update(item);
                        DBLContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    });
                }
                if (source_lista.eva_planeacion_temas_competencias != null)
                {
                    source_lista.eva_planeacion_temas_competencias.ForEach(item =>
                    {
                        DBLContext.eva_planeacion_temas_competencias.Update(item);
                        DBLContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    });
                }
                DBLContext.SaveChanges();
                return new ObjectResult("Exportación correcta");
            }
            return BadRequest();
        }


        //[Route("api/Planeacion/Apoyos/{idPlaneacionApoyos}")]
        //public IActionResult DeletePlaneacionApoyos(short idPlaneacionApoyos)
        //{
        //    DBLContext.eva_planeacion_apoyos.Remove(DBLContext.eva_planeacion_apoyos.Find(idPlaneacionApoyos));
        //    DBLContext.SaveChanges();
        //    return new ObjectResult("Borrado correctamente");

        //}

        [HttpGet]
        [Route("api/Planeacion/Asignaturas")]
        public IActionResult GetAsignaturas()
        {
            var res = from ac in DBLContext.eva_cat_asignaturas.ToList()
                      select new
                      {
                          ac.IdAsignatura,
                          ac.ClaveAsignatura
                         };
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");

        }

        [HttpGet]
        [Route("api/Planeacion/Periodos")]
        public IActionResult GetPeriodos()
        {
            var res = from ac in DBLContext.cat_periodos.ToList()
                      select new
                      {
                          ac.IdPeriodo,
                          ac.NombreCorto
                      };
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");

        }

        [HttpGet]
        [Route("api/Planeacion/{idPlaneacion}/Temas/{idTema}/Subtemas/{idAsignatura}")]
        public ContentResult GetPlaneacionSubtemas(short idPlaneacion, short idTema, short idAsignatura)
        {
            var res = from EPT in DBLContext.eva_planeacion_subtemas
                      where EPT.IdPlaneacion.Equals(idPlaneacion)
                      where EPT.IdTema.Equals(idTema)
                      where EPT.IdAsignatura.Equals(idAsignatura)
                      select EPT;
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [HttpGet]
        [Route("api/Planeacion/{idPlaneacion}/{idAsignatura}/{idTema}/{idSubtema}")]
        public ContentResult GetPlaneacionSubtema(short idPlaneacion, short idTema, short idSubtema, short idAsignatura)
        {
            var res = DBLContext.eva_planeacion_subtemas.Where(x => x.IdSubtema == idSubtema)
                                                        .Where(x => x.IdTema == idTema)
                                                        .Where(x => x.IdPlaneacion == idPlaneacion)
                                                        .Where(x => x.IdAsignatura == idAsignatura).First();
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [HttpPost]
        [Route("api/Planeacion/Temas/Subtema")]
        public IActionResult PostPlaneacionTemas([FromBody]eva_planeacion_subtemas Tema)
        {
            if (ModelState.IsValid)
            {
                short count = DBLContext.eva_planeacion_subtemas.Max(tema => tema.IdSubtema);
                Tema.IdSubtema = ++count;
                DBLContext.eva_planeacion_subtemas.Add(Tema);
                DBLContext.SaveChanges();
                return new ObjectResult("Subtema insertado");
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("api/Planeacion/Temas/Subtema")]
        public IActionResult PutPlaneacionSubtemas([FromBody]eva_planeacion_subtemas Tema)
        {
            if (ModelState.IsValid)
            {
                DBLContext.Entry<eva_planeacion_subtemas>(Tema).State = EntityState.Modified;
                DBLContext.SaveChanges();
                return new ObjectResult("Actualizado correctamente");
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("api/Planeacion/Temas/Subtemas/{idSubtema}")]
        public IActionResult DeletePlaneacionSubtema(short idSubtema)
        {
            DBLContext.eva_planeacion_subtemas.Remove(DBLContext.eva_planeacion_subtemas.Find(idSubtema));
            DBLContext.SaveChanges();
            return new ObjectResult("Borrado correctamente");
        }


    }
}