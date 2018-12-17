using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GestionPlaneacionDidacticaAPI.Models;


namespace GestionPlaneacionDidacticaAPI.Data
{
    public class DBContext : DbContext
    {

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<eva_planeacion> eva_planeacion { get; set; }
        public DbSet<eva_planeacion_temas> eva_planeacion_temas { get; set; }
        public DbSet<eva_planeacion_apoyos> eva_planeacion_apoyos { get; set; }
        public DbSet<eva_planeacion_aprendizaje> eva_planeacion_aprendizaje { get; set; }
        public DbSet<eva_planeacion_criterios_evalua> eva_planeacion_criterios_evalua { get; set; }
        public DbSet<eva_planeacion_enseñanza> eva_planeacion_enseñanza { get; set; }
        public DbSet<eva_planeacion_fuentes> eva_planeacion_fuentes { get; set; }
        public DbSet<eva_planeacion_mejora_desempeño> eva_planeacion_mejora_desempeño { get; set; }
        public DbSet<eva_planeacion_subtemas> eva_planeacion_subtemas { get; set; }
        public DbSet<eva_planeacion_temas_competencias> eva_planeacion_temas_competencias { get; set; }
        public DbSet<eva_cat_competencias> eva_cat_competencias { get; set; }
        public DbSet<eva_planeacion_criterios_evalua> eva_planeacion_criterios_evalua { get; set; }
        public DbSet<eva_cat_asignaturas> eva_cat_asignaturas { get; set; }
        public DbSet<cat_periodos> cat_periodos { get; set; }
        public DbSet<eva_planeacion_apoyos> eva_planeacion_apoyos { get; set; }
        public DbSet<eva_planeacion_fuentes> eva_planeacion_fuentes { get; set; }
        public DbSet<eva_cat_fuentes_bibliograficas> eva_cat_fuentes_bibliograficas { get; set; }
        public DbSet<eva_cat_apoyos_didacticos> eva_cat_apoyos_didacticos { get; set; }
        public DbSet<eva_planeacion_enseñanza> eva_planeacion_enseñanza { get; set; }
        public DbSet<eva_cat_actividades_enseñanza> eva_cat_actividades_enseñanza { get; set; }


    }
}
