﻿using System;
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
        public ContentResult GetPlaneacion(int idPlaneacion)
        {
            var planeacion = DBLContext.eva_planeacion.Find(idPlaneacion);
            string result = JsonConvert.SerializeObject(planeacion);
            return Content(result, "application/json");
        }

        // Obtiene todos los temas de la planeación
        [HttpGet]
        [Route("api/Planeaciones/Temas")]
        public ContentResult GetPlaneacionTemas()
        {
            var res = from EPT in DBLContext.eva_planeacion_temas
                      select EPT;
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        // Obtiene todos los temas de la planeación
        [HttpGet]
        [Route("api/Planeacion/{id}/Temas")]
        public ContentResult GetPlaneacionTemas(int id)
        {
            var res = from EPT in DBLContext.eva_planeacion_temas
                      where EPT.IdPlaneacion.Equals(id)
                      select EPT;
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        // Obtiene un tema de la planeación
        [HttpGet]
        [Route("api/Planeacion/{IdPlaneacion}/Temas/{idTema}")]
        public ContentResult GetPlaneacionTemas(short idPlaneacion,short idTema)
        {
            var res = DBLContext.eva_planeacion_temas.Find(idTema);
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        //CREAR NUEVA PLANEACION
        [HttpPost]
        [Route("api/Planeacion/Temas")]
        public IActionResult PostPlaneacionTemas([FromBody]eva_planeacion_temas Tema)
        {
            if (ModelState.IsValid)
            {
                short count = DBLContext.eva_planeacion_temas.Max(tema => tema.IdTema);
                Tema.IdTema = ++count;
                DBLContext.eva_planeacion_temas.Add(Tema);
                DBLContext.SaveChanges();
                return new ObjectResult("Tema insertado");
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("api/Planeacion/Temas")]
        public IActionResult PutPlaneacionTemas([FromBody]eva_planeacion_temas Tema)
        {
            if (ModelState.IsValid)
            {
                DBLContext.Entry<eva_planeacion_temas>(Tema).State = EntityState.Modified;
                DBLContext.SaveChanges();
                return new ObjectResult("Actualizado correctamente");
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("api/Planeacion/Temas/{idTema}")]
        public IActionResult DeletePlaneacionTemas(short idTema)
        {
            DBLContext.eva_planeacion_temas.Remove(DBLContext.eva_planeacion_temas.Find(idTema));
            DBLContext.SaveChanges();
            return new ObjectResult("Borrado correctamente");
            
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

    }
}