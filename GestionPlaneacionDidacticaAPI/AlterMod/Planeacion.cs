using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GestionPlaneacionDidacticaAPI.AlterMod
{
    public class eva_planeacion
    {
        [Key]
        [Required]
        public int IdPlaneacion { get; set; }
        public Int16 IdAsignatura { get; set; }
        public string ReferenciaNorma { get; set; }
        public string Revision { get; set; }
        public string Actual { get; set; }
        public string CompetenciaAsignatura { get; set; }
        public string AportacionPerfilEgreso { get; set; }
        public Int16 IdPeriodo { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Borrado { get; set; }
        public string Activo { get; set; }
    }
    public class eva_planeacion_temas
    {
        [Key]
        [Required]
        public Int16 IdTema { get; set; }
        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public string DesTema { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }
    public class eva_planeacion_subtemas
    {
        [Key]
        [Required]
        public Int16 IdSubtema { get; set; }
        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdTema { get; set; }
        public string DesSubtema { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }
    public class eva_planeacion_fuentes
    {
        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdFuente { get; set; }
        public Int16 Prioridad { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }
    public class eva_planeacion_apoyos
    {
        [Key]
        [Required]
        public Int16 IdPlaneacionApoyos { get; set; }
        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdApoyoDidactico { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Borrado { get; set; }
    }
    public class eva_planeacion_temas_competencias
    {
        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdTema { get; set; }
        public int IdCompetencia { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }
    public class eva_planeacion_aprendizaje
    {
        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdTema { get; set; }
        public int IdCompetencia { get; set; }
        public int IdActividadAprendizaje { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }
    public class eva_planeacion_enseñanza
    {
        public Int16 IdAsignatura { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdTema { get; set; }
        public int IdCompetencia { get; set; }
        public int IdActividadEnseñanza { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaProgramada { get; set; }
        public DateTime FechaRealizada { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }
    public class eva_planeacion_criterios_evalua
    {
        [Key]
        [Required]
        public int IdCriterio { get; set; }
        public Int16 IdAsignatura { get; set; }
        public Int16 IdTema { get; set; }
        public int IdPlaneacion { get; set; }
        public int IdCompetencia { get; set; }
        public string DesCriterio { get; set; }
        public float Porcentaje { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }
    public class eva_planeacion_mejora_desempeño
    {
        [Key]
        [Required]
        public int IdMejora { get; set; }
        public int IdPlaneacion { get; set; }
        public Int16 IdTema { get; set; }
        public string DesMejora { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }
    public class eva_cat_fuentes_bibliograficas
    {
        [Key]
        [Required]
        public Int16 IdFuente { get; set; }
        public string DesFuenteCompetencia { get; set; }
        public string Activo { get; set; }
        public string NombreFuente { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Borrado { get; set; }
    }
    public class eva_cat_apoyos_didacticos
    {
        [Key]
        [Required]
        public Int16 IdApoyoDidactico { get; set; }
        public string DesApoyoDidactico { get; set; }
        public string Activo { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Borrado { get; set; }
    }
    public class eva_cat_actividades_aprendizaje
    {
        [Key]
        [Required]
        public int IdActividadAprendizaje { get; set; }
        public string DesActividadAprendizaje { get; set; }
        public string Activo { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Borrado { get; set; }
    }
    public class eva_cat_actividades_enseñanza
    {
        [Key]
        [Required]
        public int IdActividadEnseñanza { get; set; }
        public string DesActividadEnseñanza { get; set; }
        public string Activo { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Borrado { get; set; }
    }
    public class cat_tipos_estatus
    {
        [Key]
        [Required]
        public Int16 IdTipoEstatus { get; set; }
        public string DesTipoEstatus { get; set; }
        public string Activo { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Borrado { get; set; }
    }
    public class cat_estatus
    {
        [Key]
        [Required]
        public Int16 IdEstatus { get; set; }
        public Int16 IdTipoEstatus { get; set; }
        public string Clave { get; set; }
        public string DesEstatus { get; set; }
        public string Activo { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Borrado { get; set; }
    }
    public class cat_tipos_generales
    {
        [Key]
        [Required]
        public Int16 IdTipoGeneral { get; set; }
        public string DesTipo { get; set; }
        public string Activo { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Borrado { get; set; }
    }
    public class cat_generales
    {
        [Key]
        [Required]
        public Int16 IdGeneral { get; set; }
        public Int16 IdTipoGeneral { get; set; }
        public string Clave { get; set; }
        public string DesGeneral { get; set; }
        public string IdLlaveClasifica { get; set; }
        public string Referencia { get; set; }
        public string Activo { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Borrado { get; set; }
    }
    public class cat_periodos
    {
        [Key]
        [Required]
        public Int16 IdPeriodo { get; set; }
        public string DesPeriodo { get; set; }
        public string NombreCorto { get; set; }
        public DateTime PeriodoIni { get; set; }
        public DateTime PeriodoFin { get; set; }
        public Int16 Año { get; set; }
        public string NumPeriodo { get; set; }
        public Int16 IdTipoGenPeriodo { get; set; }
        public Int16 IdGenPeriodo { get; set; }
        public string ClavePeriodo { get; set; }
        public Int16 NumDias { get; set; }
        public string Activo { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Borrado { get; set; }
    }
    public class rh_cat_personas
    {
        [Key]
        [Required]
        public int IdPersona { get; set; }
        public Int16 IdInstituto { get; set; }
        public string NumControl { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public DateTime FechaNac { get; set; }
        public string TipoPersona { get; set; }
        public string Sexo { get; set; }
        public string RutaFoto { get; set; }
        public string Alias { get; set; }
        public Int16 IdTipoGenOcupacion { get; set; }
        public Int16 IdGenOcupacion { get; set; }
        public Int16 IdTipoGenEstadoCivil { get; set; }
        public Int16 IdGenEstadoCivil { get; set; }
        public string Activo { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Borrado { get; set; }
    }

    public class eva_cat_asignaturas
    {
        [Key]
        [Required]
        public Int16 IdAsignatura { get; set; }
        public string ClaveAsignatura { get; set; }
        public string DesAsignatura { get; set; }
        public string Matricula { get; set; }
        public string Actual { get; set; }
        public DateTime FechaPlanEstudios { get; set; }
        public string NombreCorto { get; set; }
        public string Creditos { get; set; }
        public Int16 IdTipoGenAsignatura { get; set; }
        public Int16 IdGenAsignatura { get; set; }
        public Int16 IdTipoGenNivelEscolar { get; set; }
        public Int16 IdGenNivelEscolar { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }

    public class eva_cat_competencias
    {
        [Key]
        [Required]
        public Int32 IdCompetencia { get; set; }
        public Int16 IdTipoCompetencia { get; set; }
        public string DesCompetencia { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
    }
}
