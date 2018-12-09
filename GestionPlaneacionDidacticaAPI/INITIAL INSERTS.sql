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