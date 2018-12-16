--USE master
--GO

--DROP DATABASE DB_Planeacion
--GO

CREATE DATABASE DB_Planeacion
GO

USE DB_Planeacion
GO


CREATE TABLE cat_estatus
( 
	IdEstatus            char(18)  NOT NULL ,
	Clave                varchar(50)  NULL ,
	DesEstatus           varchar(30)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	IdTipoEstatus        smallint  NOT NULL 
)
go



ALTER TABLE cat_estatus
	ADD CONSTRAINT XPKcat_estatus PRIMARY KEY  CLUSTERED (IdEstatus ASC,IdTipoEstatus ASC)
go



CREATE TABLE cat_generales
( 
	IdGeneral            smallint  NOT NULL ,
	Clave                varchar(20)  NULL ,
	DesGeneral           varchar(100)  NULL ,
	IdLlaveClasifica     varchar(50)  NULL ,
	Referencia           varchar(50)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	IdTipoGeneral        smallint  NOT NULL 
)
go



ALTER TABLE cat_generales
	ADD CONSTRAINT XPKcat_generales PRIMARY KEY  CLUSTERED (IdGeneral ASC,IdTipoGeneral ASC)
go



CREATE TABLE cat_institutos
( 
	IdInstituto          smallint  NOT NULL ,
	DesInstituto         varchar(50)  NULL ,
	Alias                varchar(50)  NULL ,
	Matriz               char(1)  NULL ,
	IdInstitutoPadre     smallint  NULL ,
	IdTipoGenGiro        smallint  NULL ,
	IdGenGiro            smallint  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL 
)
go



ALTER TABLE cat_institutos
	ADD CONSTRAINT XPKcat_institutos PRIMARY KEY  CLUSTERED (IdInstituto ASC)
go



CREATE TABLE cat_periodos
( 
	IdPeriodo            smallint  NOT NULL ,
	DesPeriodo           varchar(100)  NULL ,
	NombreCorto          varchar(30)  NULL ,
	PeriodoIni           datetime  NULL ,
	PeriodoFin           datetime  NULL ,
	Año                  smallint  NULL ,
	NumPeriodo           char(1)  NULL ,
	IdTipoGenPeriodo     smallint  NULL ,
	IdGenPeriodo         smallint  NULL ,
	ClavePeriodo         varchar(5)  NULL ,
	NumDias              smallint  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL 
)
go



ALTER TABLE cat_periodos
	ADD CONSTRAINT XPKcat_periodos PRIMARY KEY  CLUSTERED (IdPeriodo ASC)
go



CREATE TABLE cat_tipos_estatus
( 
	IdTipoEstatus        smallint  NOT NULL ,
	DesTipoEstatus       varchar(30)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL 
)
go



ALTER TABLE cat_tipos_estatus
	ADD CONSTRAINT XPKcat_tipos_estatus PRIMARY KEY  CLUSTERED (IdTipoEstatus ASC)
go



CREATE TABLE cat_tipos_generales
( 
	IdTipoGeneral        smallint  NOT NULL ,
	DesTipo              varchar(100)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL 
)
go



ALTER TABLE cat_tipos_generales
	ADD CONSTRAINT XPKcat_tipos_generales PRIMARY KEY  CLUSTERED (IdTipoGeneral ASC)
go



CREATE TABLE eva_cat_actividades_aprendizaje
( 
	IdActividadAprendizaje integer  NOT NULL ,
	DesActividadAprendizaje varchar(1000)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL 
)
go



ALTER TABLE eva_cat_actividades_aprendizaje
	ADD CONSTRAINT XPKeva_cat_actividades_aprendizaje PRIMARY KEY  CLUSTERED (IdActividadAprendizaje ASC)
go



CREATE TABLE eva_cat_actividades_enseñanza
( 
	IdActividadEnseñanza integer  NOT NULL ,
	DesActividadEnseñanza varchar(1000)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL 
)
go



ALTER TABLE eva_cat_actividades_enseñanza
	ADD CONSTRAINT XPKeva_cat_actividades_enseñanza PRIMARY KEY  CLUSTERED (IdActividadEnseñanza ASC)
go



CREATE TABLE eva_cat_apoyos_didacticos
( 
	IdApoyoDidactico     smallint  NOT NULL ,
	DesApoyoDidactico    varchar(255)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL 
)
go



ALTER TABLE eva_cat_apoyos_didacticos
	ADD CONSTRAINT XPKeva_cat_apoyos_didacticos PRIMARY KEY  CLUSTERED (IdApoyoDidactico ASC)
go



CREATE TABLE eva_cat_asignaturas
( 
	IdAsignatura         smallint  NOT NULL ,
	ClaveAsignatura      varchar(150)  NULL ,
	DesAsignatura        varchar(150)  NULL ,
	Matricula            varchar(10)  NULL ,
	Actual               char(1)  NULL ,
	FechaPlanEstudios    datetime  NULL ,
	NombreCorto          varchar(100)  NULL ,
	Creditos             char(18)  NULL ,
	IdTipoGenAsignatura  smallint  NULL ,
	IdGenAsignatura      smallint  NULL ,
	IdTipoGenNivelEscolar smallint  NULL ,
	IdGenNivelEscolar    smallint  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL 
)
go



ALTER TABLE eva_cat_asignaturas
	ADD CONSTRAINT XPKeva_cat_asignaturas PRIMARY KEY  CLUSTERED (IdAsignatura ASC)
go



CREATE TABLE eva_cat_competencias
( 
	IdCompetencia        int  NOT NULL ,
	IdTipoCompetencia    smallint  NULL ,
	DesCompetencia       varchar(255)  NULL ,
	Detalle              varchar(3000)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL 
)
go



ALTER TABLE eva_cat_competencias
	ADD CONSTRAINT XPKeva_cat_competencias PRIMARY KEY  CLUSTERED (IdCompetencia ASC)
go



CREATE TABLE eva_cat_fuentes_bibliograficas
( 
	IdFuente             smallint  NOT NULL ,
	DesFuenteCompleta    varchar(255)  NULL ,
	NombreFuente         varchar(20)  NULL ,
	Autor                varchar(20)  NULL ,
	Editorial            varchar(20)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL 
)
go



ALTER TABLE eva_cat_fuentes_bibliograficas
	ADD CONSTRAINT XPKeva_cat_fuentes_bibliograficas PRIMARY KEY  CLUSTERED (IdFuente ASC)
go



CREATE TABLE eva_planeacion
( 
	IdPlaneacion         int  NOT NULL ,
	ReferenciaNorma      varchar(20)  NULL ,
	Revision             varchar(20)  NULL ,
	Actual               char(1)  NULL ,
	PlantillaOriginal    char(1)  NULL ,
	CompetenciaAsignatura varchar(20)  NULL ,
	AportacionPerfilEgreso varchar(20)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	IdAsignatura         smallint  NOT NULL ,
	IdPeriodo            smallint  NOT NULL 
)
go



ALTER TABLE eva_planeacion
	ADD CONSTRAINT XPKeva_planeacion PRIMARY KEY  CLUSTERED (IdPlaneacion ASC,IdAsignatura ASC)
go



CREATE TABLE eva_planeacion_apoyos
( 
	IdPlaneacionApoyos   smallint  NOT NULL,
	Observaciones        varchar(100)  NOT NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	IdAsignatura         smallint  NOT NULL ,
	IdPlaneacion         int  NOT NULL ,
	IdApoyoDidactico     smallint  NOT NULL 
)
go



ALTER TABLE eva_planeacion_apoyos
	ADD CONSTRAINT XPKeva_planeacion_apoyos PRIMARY KEY  CLUSTERED (IdPlaneacionApoyos ASC,IdAsignatura ASC,IdPlaneacion ASC,IdApoyoDidactico ASC)
go



CREATE TABLE eva_planeacion_aprendizaje
( 
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	IdAsignatura         smallint  NOT NULL ,
	IdPlaneacion         int  NOT NULL ,
	IdTema               smallint  NOT NULL ,
	IdCompetencia        int  NOT NULL ,
	IdActividadAprendizaje integer  NOT NULL 
)
go



ALTER TABLE eva_planeacion_aprendizaje
	ADD CONSTRAINT XPKeva_planeacion_aprendizaje PRIMARY KEY  CLUSTERED (IdAsignatura ASC,IdPlaneacion ASC,IdTema ASC,IdCompetencia ASC,IdActividadAprendizaje ASC)
go



CREATE TABLE eva_planeacion_criterios_evalua
( 
	DesCriterio          varchar(100)  NULL ,
	Porcentaje           float  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	IdAsignatura         smallint  NOT NULL ,
	IdPlaneacion         int  NOT NULL ,
	IdTema               smallint  NOT NULL ,
	IdCompetencia        int  NOT NULL ,
	IdCriterio           integer  NOT NULL 
)
go



ALTER TABLE eva_planeacion_criterios_evalua
	ADD CONSTRAINT XPKeva_planeacion_criterios_evalua PRIMARY KEY  CLUSTERED (IdAsignatura ASC,IdPlaneacion ASC,IdTema ASC,IdCompetencia ASC,IdCriterio ASC)
go



CREATE TABLE eva_planeacion_enseñanza
( 
	FechaProgramada      datetime  NULL ,
	FechaRealizada       datetime  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	IdAsignatura         smallint  NOT NULL ,
	IdPlaneacion         int  NOT NULL ,
	IdTema               smallint  NOT NULL ,
	IdCompetencia        int  NOT NULL ,
	IdActividadEnseñanza integer  NOT NULL 
)
go



ALTER TABLE eva_planeacion_enseñanza
	ADD CONSTRAINT XPKeva_planeacion_enseñanza PRIMARY KEY  CLUSTERED (IdAsignatura ASC,IdPlaneacion ASC,IdTema ASC,IdCompetencia ASC,IdActividadEnseñanza ASC)
go



CREATE TABLE eva_planeacion_fuentes
( 
	Prioridad            smallint  NULL ,
	Observaciones        varchar(100)  NOT NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	IdAsignatura         smallint  NOT NULL ,
	IdPlaneacion         int  NOT NULL ,
	IdFuente             smallint  NOT NULL 
)
go



ALTER TABLE eva_planeacion_fuentes
	ADD CONSTRAINT XPKeva_planeacion_fuentes PRIMARY KEY  CLUSTERED (IdAsignatura ASC,IdPlaneacion ASC,IdFuente ASC)
go



CREATE TABLE eva_planeacion_mejora_desempeño
( 
	IdMejora             char(18)  NOT NULL ,
	DesMejora            varchar(1000)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	IdAsignatura         smallint  NOT NULL ,
	IdPlaneacion         int  NOT NULL ,
	IdTema               smallint  NOT NULL 
)
go



ALTER TABLE eva_planeacion_mejora_desempeño
	ADD CONSTRAINT XPKeva_planeacion_mejora_desempeño PRIMARY KEY  CLUSTERED (IdMejora ASC,IdAsignatura ASC,IdPlaneacion ASC,IdTema ASC)
go



CREATE TABLE eva_planeacion_subtemas
( 
	IdSubtema            smallint  NOT NULL ,
	DesSubtema           varchar(20)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	IdAsignatura         smallint  NOT NULL ,
	IdPlaneacion         int  NOT NULL ,
	IdTema               smallint  NOT NULL 
)
go



ALTER TABLE eva_planeacion_subtemas
	ADD CONSTRAINT XPKeva_planeacion_subtemas PRIMARY KEY  CLUSTERED (IdSubtema ASC,IdAsignatura ASC,IdPlaneacion ASC,IdTema ASC)
go



CREATE TABLE eva_planeacion_temas
( 
	IdTema               smallint  NOT NULL ,
	DesTema              varchar(20)  NULL ,
	Observaciones        varchar(100)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	IdPlaneacion         int  NOT NULL ,
	IdAsignatura         smallint  NOT NULL 
)
go



ALTER TABLE eva_planeacion_temas
	ADD CONSTRAINT XPKeva_planeacion_temas PRIMARY KEY  CLUSTERED (IdTema ASC,IdPlaneacion ASC,IdAsignatura ASC)
go



CREATE TABLE eva_planeacion_temas_competencias
( 
	Observaciones        varchar(1000)  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	IdAsignatura         smallint  NOT NULL ,
	IdPlaneacion         int  NOT NULL ,
	IdTema               smallint  NOT NULL ,
	IdCompetencia        int  NOT NULL 
)
go



ALTER TABLE eva_planeacion_temas_competencias
	ADD CONSTRAINT XPKeva_planeacion_temas_competencias PRIMARY KEY  CLUSTERED (IdAsignatura ASC,IdPlaneacion ASC,IdTema ASC,IdCompetencia ASC)
go



CREATE TABLE rh_cat_personas
( 
	IdPersona            int  NOT NULL ,
	NumControl           varchar(20)  NULL ,
	Nombre               varchar(100)  NULL ,
	ApPaterno            varchar(60)  NULL ,
	ApMaterno            varchar(60)  NULL ,
	RFC                  varchar(15)  NULL ,
	CURP                 varchar(25)  NULL ,
	FechaNac             datetime  NULL ,
	TipoPersona          char(1)  NULL ,
	Sexo                 char(1)  NULL ,
	RutaFoto             varchar(255)  NULL ,
	Alias                varchar(20)  NULL ,
	IdTipoGenOcupacion   smallint  NULL ,
	IdGenOcupacion       smallint  NULL ,
	IdTipoGenEstadoCivil smallint  NULL ,
	IdGenEstadoCivil     smallint  NULL ,
	FechaReg             datetime  NULL ,
	UsuarioReg           varchar(20)  NULL ,
	FechaUltMod          datetime  NULL ,
	UsuarioMod           varchar(20)  NULL ,
	Activo               char(1)  NULL ,
	Borrado              char(1)  NULL ,
	IdInstituto          smallint  NOT NULL 
)
go



ALTER TABLE rh_cat_personas
	ADD CONSTRAINT XPKrh_cat_personas PRIMARY KEY  CLUSTERED (IdPersona ASC,IdInstituto ASC)
go




ALTER TABLE cat_estatus
	ADD CONSTRAINT R_1 FOREIGN KEY (IdTipoEstatus) REFERENCES cat_tipos_estatus(IdTipoEstatus)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go




ALTER TABLE cat_generales
	ADD CONSTRAINT R_2 FOREIGN KEY (IdTipoGeneral) REFERENCES cat_tipos_generales(IdTipoGeneral)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go




ALTER TABLE eva_planeacion
	ADD CONSTRAINT R_4 FOREIGN KEY (IdAsignatura) REFERENCES eva_cat_asignaturas(IdAsignatura)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go




ALTER TABLE eva_planeacion
	ADD CONSTRAINT R_21 FOREIGN KEY (IdPeriodo) REFERENCES cat_periodos(IdPeriodo)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go




ALTER TABLE eva_planeacion_apoyos
	ADD CONSTRAINT R_10 FOREIGN KEY (IdPlaneacion,IdAsignatura) REFERENCES eva_planeacion(IdPlaneacion,IdAsignatura)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go




ALTER TABLE eva_planeacion_apoyos
	ADD CONSTRAINT R_17 FOREIGN KEY (IdApoyoDidactico) REFERENCES eva_cat_apoyos_didacticos(IdApoyoDidactico)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go




ALTER TABLE eva_planeacion_aprendizaje
	ADD CONSTRAINT R_12 FOREIGN KEY (IdAsignatura,IdPlaneacion,IdTema,IdCompetencia) REFERENCES eva_planeacion_temas_competencias(IdAsignatura,IdPlaneacion,IdTema,IdCompetencia)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go




ALTER TABLE eva_planeacion_aprendizaje
	ADD CONSTRAINT R_18 FOREIGN KEY (IdActividadAprendizaje) REFERENCES eva_cat_actividades_aprendizaje(IdActividadAprendizaje)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go




ALTER TABLE eva_planeacion_criterios_evalua
	ADD CONSTRAINT R_14 FOREIGN KEY (IdAsignatura,IdPlaneacion,IdTema,IdCompetencia) REFERENCES eva_planeacion_temas_competencias(IdAsignatura,IdPlaneacion,IdTema,IdCompetencia)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go




ALTER TABLE eva_planeacion_enseñanza
	ADD CONSTRAINT R_13 FOREIGN KEY (IdAsignatura,IdPlaneacion,IdTema,IdCompetencia) REFERENCES eva_planeacion_temas_competencias(IdAsignatura,IdPlaneacion,IdTema,IdCompetencia)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go




ALTER TABLE eva_planeacion_enseñanza
	ADD CONSTRAINT R_20 FOREIGN KEY (IdActividadEnseñanza) REFERENCES eva_cat_actividades_enseñanza(IdActividadEnseñanza)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go




ALTER TABLE eva_planeacion_fuentes
	ADD CONSTRAINT R_9 FOREIGN KEY (IdPlaneacion,IdAsignatura) REFERENCES eva_planeacion(IdPlaneacion,IdAsignatura)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go




ALTER TABLE eva_planeacion_fuentes
	ADD CONSTRAINT R_16 FOREIGN KEY (IdFuente) REFERENCES eva_cat_fuentes_bibliograficas(IdFuente)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go




ALTER TABLE eva_planeacion_mejora_desempeño
	ADD CONSTRAINT R_15 FOREIGN KEY (IdTema,IdPlaneacion,IdAsignatura) REFERENCES eva_planeacion_temas(IdTema,IdPlaneacion,IdAsignatura)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go




ALTER TABLE eva_planeacion_subtemas
	ADD CONSTRAINT R_6 FOREIGN KEY (IdTema,IdPlaneacion,IdAsignatura) REFERENCES eva_planeacion_temas(IdTema,IdPlaneacion,IdAsignatura)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go




ALTER TABLE eva_planeacion_temas
	ADD CONSTRAINT R_5 FOREIGN KEY (IdPlaneacion,IdAsignatura) REFERENCES eva_planeacion(IdPlaneacion,IdAsignatura)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go




ALTER TABLE eva_planeacion_temas_competencias
	ADD CONSTRAINT R_7 FOREIGN KEY (IdTema,IdPlaneacion,IdAsignatura) REFERENCES eva_planeacion_temas(IdTema,IdPlaneacion,IdAsignatura)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go




ALTER TABLE eva_planeacion_temas_competencias
	ADD CONSTRAINT R_8 FOREIGN KEY (IdCompetencia) REFERENCES eva_cat_competencias(IdCompetencia)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go




ALTER TABLE rh_cat_personas
	ADD CONSTRAINT R_3 FOREIGN KEY (IdInstituto) REFERENCES cat_institutos(IdInstituto)
		ON DELETE CASCADE
		ON UPDATE NO ACTION
go

use DB_Planeacion
go
INSERT INTO eva_cat_asignaturas VALUES (1,'DAE', 'APP EMPRESARIALES', '123', '1', '2018-12-01', 'DAE', '20', 3, 3, 4, 1, '2018-12-01', 'Pedro', '2018-12-01', 'Pedro', 'S', 'N')
GO

INSERT INTO eva_cat_asignaturas VALUES (2,'PROLOG', 'Programación lógica y funcional', '123', '1', '2018-12-01', 'PRO', '20', 3, 3, 4, 1, '2018-12-01', 'Pedro', '2018-12-01', 'Pedro', 'S', 'N')
GO

INSERT INTO eva_cat_asignaturas VALUES (3,'ABD', 'Administración de base de datos', '123', '1', '2018-12-01', 'ABD', '20', 3, 3, 4, 1, '2018-12-01', 'Pedro', '2018-12-01', 'Pedro', 'S', 'N')
GO

INSERT INTO cat_periodos VALUES (1, 'Periodo enero-junio', 'ENE-JUN 2018', '2018-01-28', '2018-06-05', 2018, 1, 2, 2, 'EJ18', 180, '2018-12-01', 'Pedro', '2018-12-01', 'Pedro', 'S', 'N')
GO

INSERT INTO cat_periodos VALUES (2, 'Periodo agosto-diciembre', 'AGO-DIC 2018', '2018-01-28', '2018-06-05', 2018, 1, 2, 2, 'AD18', 180, '2018-12-01', 'Pedro', '2018-12-01', 'Pedro', 'S', 'N')
GO

INSERT INTO eva_planeacion(IdPlaneacion,ReferenciaNorma,Revision,Actual,PlantillaOriginal,CompetenciaAsignatura,AportacionPerfilEgreso,FechaReg,UsuarioReg,FechaUltMod,UsuarioMod,Activo,Borrado,IdAsignatura,IdPeriodo) 
 VALUES(1,'ISO','2018','S','S','Empresariales','Empresariales','2018-01-28','Ernesto','2018-01-28','Ernesto','S','N',1,1)
GO

INSERT INTO eva_planeacion_temas(IdAsignatura,IdPlaneacion,IdTema,DesTema,Observaciones,FechaReg,UsuarioReg,FechaUltMod,UsuarioMod,Activo,Borrado)
	VALUES (1,1,1,'Servicios web','Servicios web','2018-01-28','Ernesto','2018-01-28','Ernesto','S','N')
GO

INSERT INTO eva_cat_competencias VALUES (1,1, 'Competencia prolog', 'Ninguna', '2018-12-10','Reyes', '2018-12-10', 'Reyes', 'S', 'N')
GO

INSERT INTO eva_cat_competencias VALUES (2,1, 'Competencia dae', 'Ninguna', '2018-12-10','Reyes', '2018-12-10', 'Reyes', 'S', 'N')
GO

INSERT INTO eva_cat_actividades_aprendizaje VALUES (1,'Exposicion en equipo','2018-12-10','Reyes', '2018-12-10', 'Reyes', 'S', 'N')
GO
INSERT INTO eva_cat_actividades_aprendizaje VALUES (2,'Cuestionario','2018-12-10','Reyes', '2018-12-10', 'Reyes', 'S', 'N')
GO
INSERT INTO eva_cat_actividades_aprendizaje VALUES (3,'Investigacion documental','2018-12-10','Reyes', '2018-12-10', 'Reyes', 'S', 'N')
GO
INSERT INTO eva_cat_actividades_aprendizaje VALUES (4,'Debate en clase','2018-12-10','Reyes', '2018-12-10', 'Reyes', 'S', 'N')
GO

INSERT INTO eva_planeacion_subtemas VALUES(
	1,'Introduccion','2018-09-11','Bryan','2018-09-11','Bryan','S','N',1,1,1
)
go

INSERT INTO eva_planeacion_subtemas VALUES(
	2,'Desarrollo','2018-09-11','Bryan','2018-09-11','Bryan','S','N',1,1,1
)
go

INSERT INTO eva_planeacion_subtemas VALUES(
	3,'Aplicacion','2018-09-11','Bryan','2018-09-11','Bryan','S','N',1,1,1
)
go

insert into eva_cat_fuentes_bibliograficas values(
	1,'Intro I','Introducción I','Juan','SA DE CV','2018-09-11','Bryan','2018-09-11','bryan','S','N'
);
insert into eva_cat_fuentes_bibliograficas values(
	2,'Intro II','Introducción II','Juan','SA DE CV','2018-09-11','Bryan','2018-09-11','bryan','S','N'
);

insert into eva_cat_fuentes_bibliograficas values(
	3,'Intro III','Introducción III','Juan','SA DE CV','2018-09-11','Bryan','2018-09-11','bryan','S','N'
);

insert into eva_planeacion_fuentes values (
	1,'Intro 1','2018-09-11','Bryan','2018-09-11','bryan','S','N',1,1,1
);

insert into eva_planeacion_fuentes values (
	2,'Intro 2','2018-09-11','Bryan','2018-09-11','bryan','S','N',1,1,2
);

insert into eva_planeacion_fuentes values (
	3,'Intro 3','2018-09-11','Bryan','2018-09-11','bryan','S','N',1,1,3
);

