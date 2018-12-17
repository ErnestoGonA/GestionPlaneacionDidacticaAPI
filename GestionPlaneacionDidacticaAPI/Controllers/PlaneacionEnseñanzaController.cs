using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestionPlaneacionDidacticaAPI.Data;
using GestionPlaneacionDidacticaAPI.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace GestionPlaneacionDidacticaAPI.Controllers
{
    public class PlaneacionEnsenanzaController : Controller
    {
        private readonly DBContext _context;
        public PlaneacionEnsenanzaController(DBContext context)
        {
            _context = context;
        }

        [Route("api/PlaneacionEnseñanza")]
        [HttpGet]
        public ContentResult GetPlaneacionEnsenanza()
        {
            var res = from epe in _context.eva_planeacion_enseñanza
                      select new
                      {
                          epe.FechaProgramada,
                          epe.FechaRealizada,
                          epe.FechaReg,
                          epe.UsuarioReg,
                          epe.FechaUltMod,
                          epe.UsuarioMod,
                          epe.Activo,
                          epe.Borrado,
                          epe.IdAsignatura,
                          epe.IdPlaneacion,
                          epe.IdTema,
                          epe.IdCompetencia,
                          epe.IdActividadEnseñanza
                      };

            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [Route("api/PlaneacionEnseñanzaExtended")]
        [HttpGet]
        public ContentResult GetPlaneacionEnsenanzaExtended()
        {
            var res = from epe in _context.eva_planeacion_enseñanza
                      join ecae in _context.eva_cat_actividades_enseñanza on epe.IdActividadEnseñanza equals ecae.IdActividadEnseñanza
                      join eptc in _context.eva_planeacion_temas_competencias on new { epe.IdAsignatura, epe.IdPlaneacion, epe.IdTema, epe.IdCompetencia } equals new { eptc.IdAsignatura, eptc.IdPlaneacion, eptc.IdTema, eptc.IdCompetencia }
                      join ept in _context.eva_planeacion_temas on new { eptc.IdTema, eptc.IdPlaneacion, eptc.IdAsignatura } equals new { ept.IdTema, ept.IdPlaneacion, ept.IdAsignatura }
                      join ep in _context.eva_planeacion on new { ept.IdPlaneacion, ept.IdAsignatura } equals new { ep.IdPlaneacion, ep.IdAsignatura }
                      join eca in _context.eva_cat_asignaturas on new { ep.IdAsignatura } equals new { eca.IdAsignatura }
                      join ecc in _context.eva_cat_competencias on new { eptc.IdCompetencia } equals new { ecc.IdCompetencia }

                      select new
                      {
                          epe.FechaProgramada,
                          epe.FechaRealizada,
                          epe.FechaReg,
                          epe.UsuarioReg,
                          epe.FechaUltMod,
                          epe.UsuarioMod,
                          epe.Activo,
                          epe.Borrado,
                          epe.IdAsignatura,
                          eca.DesAsignatura,
                          epe.IdPlaneacion,
                          ep.ReferenciaNorma,
                          epe.IdTema,
                          ept.DesTema,
                          epe.IdCompetencia,
                          ecc.DesCompetencia,
                          epe.IdActividadEnseñanza,
                          ecae.DesActividadEnseñanza
                      };

            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [Route("api/PlaneacionEnseñanza/NewPlaneacionEnseñanza")]
        [HttpPost]
        public IActionResult PostPlaneacionEnseñanza([FromBody]eva_planeacion_enseñanza planeacion)
        {
            if (ModelState.IsValid)
            {
                _context.eva_planeacion_enseñanza.Add(planeacion);
                _context.SaveChanges();
                return new ObjectResult("Correcto!");
            }
            return BadRequest();
        }

        [HttpGet("api/OnePlaneacionEnseñanza/{IdAsignatura}/{IdPlaneacion}/{IdTema}/{IdCompetencia}/{IdActividadEnseñanza}")]
        public ActionResult<string> OnePlaneacionEnseñanza( short IdAsignatura,int IdPlaneacion, short IdTema, int IdCompetencia, int IdActividadEnseñanza)
        {
            var edificio = _context.eva_planeacion_enseñanza.Find(IdAsignatura,IdPlaneacion,IdTema,IdCompetencia,IdActividadEnseñanza);
            if (edificio == null) { return new ObjectResult("No encontrado"); }
            string result = JsonConvert.SerializeObject(edificio);
            Console.WriteLine("IdAsignatura: "+ IdAsignatura);
            Console.WriteLine("IdPlaneacion: " + IdPlaneacion);
            Console.WriteLine("IdTema: " + IdTema);
            Console.WriteLine("IdCompetencia: " + IdCompetencia);
            Console.WriteLine("IdActividadEnseñanza: " + IdActividadEnseñanza);
            return Content(result, "application/json");
        }

        [HttpGet("api/OnePlaneacionEnseñanzaExtended/{IdAsignatura}/{IdPlaneacion}/{IdTema}/{IdCompetencia}/{IdActividadEnseñanza}")]
        public ActionResult<string> OnePlaneacionEnseñanzaExtended(short IdAsignatura, int IdPlaneacion, short IdTema, int IdCompetencia, int IdActividadEnseñanza)
        {
            var res = (from epe in _context.eva_planeacion_enseñanza
                      join ecae in _context.eva_cat_actividades_enseñanza on epe.IdActividadEnseñanza equals ecae.IdActividadEnseñanza
                      join eptc in _context.eva_planeacion_temas_competencias on new { epe.IdAsignatura, epe.IdPlaneacion, epe.IdTema, epe.IdCompetencia } equals new { eptc.IdAsignatura, eptc.IdPlaneacion, eptc.IdTema, eptc.IdCompetencia }
                      join ept in _context.eva_planeacion_temas on new { eptc.IdTema, eptc.IdPlaneacion, eptc.IdAsignatura } equals new { ept.IdTema, ept.IdPlaneacion, ept.IdAsignatura }
                      join ep in _context.eva_planeacion on new { ept.IdPlaneacion, ept.IdAsignatura } equals new { ep.IdPlaneacion, ep.IdAsignatura }
                      join eca in _context.eva_cat_asignaturas on new { ep.IdAsignatura } equals new { eca.IdAsignatura }
                      join ecc in _context.eva_cat_competencias on new { eptc.IdCompetencia } equals new { ecc.IdCompetencia }
                      where epe.IdAsignatura.Equals(IdAsignatura) && epe.IdPlaneacion.Equals(IdPlaneacion) && epe.IdTema.Equals(IdTema) && epe.IdCompetencia.Equals(IdCompetencia) && epe.IdCompetencia.Equals(IdCompetencia) 
                      select new
                      {
                          epe.FechaProgramada,
                          epe.FechaRealizada,
                          epe.FechaReg,
                          epe.UsuarioReg,
                          epe.FechaUltMod,
                          epe.UsuarioMod,
                          epe.Activo,
                          epe.Borrado,
                          epe.IdAsignatura,
                          eca.DesAsignatura,
                          epe.IdPlaneacion,
                          ep.ReferenciaNorma,
                          epe.IdTema,
                          ept.DesTema,
                          epe.IdCompetencia,
                          ecc.DesCompetencia,
                          epe.IdActividadEnseñanza,
                          ecae.DesActividadEnseñanza
                      }).First();

            string result = JsonConvert.SerializeObject(res);
            return Content(result, "application/json");
        }

        [HttpDelete]
        [Route("api/DeletePlaneacionEnseñanza/{IdAsignatura}/{IdPlaneacion}/{IdTema}/{IdCompetencia}/{IdActividadEnseñanza}")]
        public IActionResult deletePlaneacionEnseñanza(short IdAsignatura, int IdPlaneacion, short IdTema, int IdCompetencia, int IdActividadEnseñanza)
        {
            if (ModelState.IsValid)
            {
                _context.eva_planeacion_enseñanza.Remove(_context.eva_planeacion_enseñanza.Find(IdAsignatura,IdPlaneacion,IdTema,IdCompetencia,IdActividadEnseñanza));
                _context.SaveChanges();
                return new ObjectResult("Planeación eliminada");
            }
            return BadRequest();
        }

        //[HttpPut]
        [HttpPut("api/UpdatePlaneacionEnseñanza/{IdAsignatura}/{IdPlaneacion}/{IdTema}/{IdCompetencia}/{IdActividadEnseñanza}")]
        public IActionResult editPlaneacionEnseñanza(short IdAsignatura, int IdPlaneacion, short IdTema, int IdCompetencia, int IdActividadEnseñanza, [FromBody]eva_planeacion_enseñanza tepe)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("epe= "+tepe.IdPlaneacion);
                _context.eva_planeacion_enseñanza.Remove(_context.eva_planeacion_enseñanza.Find(IdAsignatura, IdPlaneacion, IdTema, IdCompetencia, IdActividadEnseñanza));
                _context.SaveChanges();
      
                eva_planeacion_enseñanza epe = new eva_planeacion_enseñanza();
                epe.IdActividadEnseñanza = tepe.IdActividadEnseñanza;
                epe.IdAsignatura = tepe.IdAsignatura;
                epe.IdCompetencia = tepe.IdCompetencia;
                epe.IdPlaneacion = tepe.IdPlaneacion;
                epe.IdTema = tepe.IdTema;
                epe.Activo = tepe.Activo;
                epe.Borrado = tepe.Borrado;
                epe.FechaProgramada = tepe.FechaProgramada;
                epe.FechaRealizada = tepe.FechaRealizada;
                epe.FechaReg = tepe.FechaReg;
                epe.FechaUltMod = tepe.FechaUltMod;
                epe.UsuarioMod = tepe.UsuarioMod;
                epe.UsuarioReg = tepe.UsuarioReg;

                _context.eva_planeacion_enseñanza.Add(epe);
                _context.SaveChanges();
                return new ObjectResult("Actualizacion Completa");
            }
            return BadRequest();

        }

    }
}