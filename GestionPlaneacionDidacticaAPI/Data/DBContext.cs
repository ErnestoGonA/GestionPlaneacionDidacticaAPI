﻿using System;
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
        public DbSet<eva_planeacion_subtemas> eva_planeacion_subtemas { get; set; }
        public DbSet<eva_cat_asignaturas> eva_cat_asignaturas { get; set; }
        public DbSet<cat_periodos> cat_periodos { get; set; }
        public DbSet<eva_planeacion_apoyos> eva_planeacion_apoyos { get; set; }


    }
}
