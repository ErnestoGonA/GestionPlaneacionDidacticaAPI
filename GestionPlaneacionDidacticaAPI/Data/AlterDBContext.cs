using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GestionPlaneacionDidacticaAPI.AlterMod;

namespace GestionPlaneacionDidacticaAPI.Data
{
    public class AlterDBContext : DbContext
    {
        public AlterDBContext(DbContextOptions<AlterDBContext> options) : base(options)
        {
        }

        public DbSet<eva_planeacion> eva_planeacion { get; set; }
        public DbSet<eva_planeacion_temas> eva_planeacion_temas { get; set; }
        public DbSet<eva_planeacion_subtemas> eva_planeacion_subtemas { get; set; }
        public DbSet<eva_cat_asignaturas> eva_cat_asignaturas { get; set; }
        public DbSet<cat_periodos> cat_periodos { get; set; }
        public DbSet<eva_planeacion_apoyos> eva_planeacion_apoyos { get; set; }
        public DbSet<eva_planeacion_enseñanza> eva_planeacion_enseñanza { get; set; }
        public DbSet<eva_cat_actividades_enseñanza> eva_cat_actividades_enseñanza { get; set; }
        public DbSet<eva_planeacion_temas_competencias> eva_planeacion_temas_competencias { get; set; }
        public DbSet<eva_cat_competencias> eva_cat_competencias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<eva_planeacion_enseñanza>()
                .HasKey(c => new
                {
                    c.IdAsignatura,
                    c.IdPlaneacion,
                    c.IdTema,
                    c.IdCompetencia,
                    c.IdActividadEnseñanza
                });

            modelBuilder.Entity<eva_planeacion_temas_competencias>()
                .HasKey(c => new
                {
                    c.IdAsignatura,
                    c.IdPlaneacion,
                    c.IdTema,
                    c.IdCompetencia,
                });

            modelBuilder.Entity<eva_planeacion_temas>()
                .HasKey(c => new
                {
                    c.IdAsignatura,
                    c.IdPlaneacion,
                    c.IdTema,
                });

            modelBuilder.Entity<eva_planeacion>()
                .HasKey(c => new
                {
                    c.IdAsignatura,
                    c.IdPlaneacion
                });
        }
    }
}
