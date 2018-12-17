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
    public class TemasController : ControllerBase
    {

        private readonly DBContext DBLContext;

        public TemasController(DBContext DBPContext)
        {
            DBLContext = DBPContext;
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

        [HttpGet]
        [Route("api/Asignatura/{IdAsignatura}/Planeacion/{IdPlaneacion}/Temas")]
        public ContentResult GetPlaneacionTemasAsignatura(short IdAsignatura, short IdPlaneacion)
        {
            var res = from EPT in DBLContext.eva_planeacion_temas
                      where EPT.IdAsignatura.Equals(IdAsignatura)
                      where EPT.IdPlaneacion.Equals(IdPlaneacion)
                      select EPT;
            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }


        // Obtiene un tema de la planeación
        [HttpGet]
        [Route("api/Asignatura/{IdAsignatura}/Planeacion/{IdPlaneacion}/Temas/{IdTema}")]
        public ContentResult GetPlaneacionTemas(short IdAsignatura, int IdPlaneacion, short IdTema)
        {
            var res = (from tema in DBLContext.eva_planeacion_temas
                       where tema.IdAsignatura == IdAsignatura
                       where tema.IdPlaneacion == IdPlaneacion
                       where tema.IdTema == IdTema
                       select tema).First();

            //var res = DBLContext.eva_planeacion_temas.Find(idTema);
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

                short count = 0;
                try
                {
                    count = (from tema in DBLContext.eva_planeacion_temas
                             select tema.IdTema).Max();
                }
                catch (Exception e)
                {
                    count = 0;
                }

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
        [Route("api/Asignatura/{IdAsignatura}/Planeacion/{IdPlaneacion}/Temas/{IdTema}")]
        public IActionResult DeletePlaneacionTemas(short IdAsignatura, int IdPlaneacion, short IdTema)
        {
            DBLContext.eva_planeacion_temas.Remove((from tema in DBLContext.eva_planeacion_temas
                                                    where tema.IdAsignatura == IdAsignatura
                                                    where tema.IdPlaneacion == IdPlaneacion
                                                    where tema.IdTema == IdTema
                                                    select tema).First());
            DBLContext.SaveChanges();
            return new ObjectResult("Borrado correctamente");

        }
    }
}