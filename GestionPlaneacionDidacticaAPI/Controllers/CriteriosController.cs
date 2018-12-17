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

    }
}