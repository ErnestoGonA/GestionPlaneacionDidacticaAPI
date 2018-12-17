using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPlaneacionDidacticaAPI.Models
{
    public class extended_eva_planeacion_enseñanza
    {
        public Int16 IdAsignatura { get; set; }
        public string DesAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public string ReferenciaNorma { get; set; }
        public Int16 IdTema { get; set; }
        public string DesTema { get; set; }
        public int IdCompetencia { get; set; }
        public string DesCompetencia { get; set; }
        public int IdActividadEnseñanza { get; set; }
        public string DesActividadEnseñanza { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaProgramada { get; set; }
        public DateTime FechaRealizada { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }

    public class typedelete_eva_planeacion_enseñanza
    {
        public Int16 IdAsignatura { get; set; }
        public string DesAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public string ReferenciaNorma { get; set; }
        public Int16 IdTema { get; set; }
        public string DesTema { get; set; }
        public int IdCompetencia { get; set; }
        public string DesCompetencia { get; set; }
        public int IdActividadEnseñanza { get; set; }
        public int IdActividadEnseñanzanew { get; set; }
        public string DesActividadEnseñanza { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaProgramada { get; set; }
        public DateTime FechaRealizada { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }
}
