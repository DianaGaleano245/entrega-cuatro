 delimiter $$
 USE softwarefactory $$
 SELECT 'spsf' AS 'Estado' $$

/*Realizar los SP para dar de alta todas las tablas, menos la tabla Experiencia*/
DELIMITER $$
drop PROCEDURE if exists altaEmpleado $$
CREATE PROCEDURE altaEmpleado(unCuil INT , unNombre VARCHAR(50) , unApellido VARCHAR(50) , unaContratacion DATE)
begin
		INSERT INTO Empleado(Cuil , Nombre , Apellido , Contratacion)
					VALUES (unCuil , unNombre , unApellido , unaContratacion);
end $$

DELIMITER $$
drop PROCEDURE if exists altaCliente $$
CREATE PROCEDURE altaCliente(unCuit INT , unaRazonSocial VARCHAR(59))
begin
		INSERT INTO Cliente(cuit, razonSocial)
					VALUES(unCuit, unaRazonSocial);
end $$

DELIMITER $$
drop PROCEDURE if exists clientePorCuit $$
CREATE PROCEDURE clientePorCuit (unCuit INT)
begin
	select * 
	from cliente
	where cuit = unCuit;
end $$

DELIMITER $$
drop PROCEDURE if exists altaTarea $$
CREATE PROCEDURE altaTarea(unIdRequerimiento INT , unCuil INT , unInicio DATE , unFin DATE)
begin
		INSERT INTO Tarea(Requerimiento , Cuil , Inicio , Fin)
					VALUES(unIdRequerimiento , unCuil , unInicio , unFin);
end $$ 

DELIMITER $$
drop PROCEDURE if exists altaProyecto $$
CREATE PROCEDURE altaProyecto(unIdProyecto SMALLINT , unCuit INT , unaDescripcion varchar(200) , unPresupuesto DECIMAL(10,2) , 
									unInicio DATE , unFinal DATE)
begin
		INSERT INTO Proyecto(IdProyecto , Cuit , Descripcion , Presupuesto , Inicio , Final)
					VALUES(unIdProyecto , unCuit , unaDescripcion , unPresupuesto , unInicio , unFinal);
end $$

DELIMITER $$
drop PROCEDURE if exists altaRequerimiento $$
CREATE PROCEDURE altaRequerimiento(unIdRequerimiento INT , unIdProyecto SMALLINT , 
										unIdTecnologia TINYINT , unaDescripcion VARCHAR (45) , unaComplejidad TINYINT UNSIGNED)
begin
		INSERT INTO Requerimiento(IdRequerimiento , IdProyecto , IdTecnologia , Descripcion , Complejidad)
					VALUES(unIdRequerimiento , unIdProyecto , unIdTecnologia , unaDescripcion , unaComplejidad);
end $$

DELIMITER $$
drop PROCEDURE if exists altaTecnologia $$
CREATE PROCEDURE altaTecnologia(unIdTecnologia TINYINT , unaTecnologia VARCHAR(20) , unCostoBase DECIMAL(10,2))
begin
		INSERT INTO Tecnologia (IdTecnologia , Tecnologia , CostoBase)
					VALUES(unIdTecnologia , unaTecnologia , unCostoBase);
end $$

/*Realizar el SP asignarExperiencia que recibe como parámetros cuil, idTecnologia y una calificación. 
El SP tiene que crear un registro en caso de que no exista o actualizarlo en caso de que si exista*/
DELIMITER $$
drop PROCEDURE if exists AsignarExperiencia $$
CREATE PROCEDURE AsignarExperiencia (unCuil INT, unidTecnologia TINYINT, unaCalificacion TINYINT UNSIGNED)
begin
    if (EXISTS(SELECT * 
				FROM experiencia
                WHERE Cuil = idTecnologia 
                OR Empleado = Experiencia )
    ) then 

		UPDATE Experiencia
		SET calificacion = unaCalificacion
		WHERE idTecnologia = unIdTecnologia
		AND Cuil = unCuil;
	else
		INSERT INTO Experiencia (cuil, idTecnologia, calificacion)
                    VALUES (unCuil, unIdTecnologia, unaCalificacion);
	END if;
end $$

/*Crear los SP finalizarTarea que reciba como parámetro un idRequerimiento, 
un cuil y una fecha de fin. El SP deberá actualizar la fecha de fin solamente si no tenía valor previo.*/
DELIMITER $$
drop PROCEDURE if exists FinalizarTarea $$
CREATE PROCEDURE FinalizarTarea (unIdRequerimiento INT , unCuil INT , unFinal DATE)
begin
        UPDATE  Tarea
		SET     fin = unFinal
		WHERE   fin is NULL
		AND IdRequerimiento = unIdRequerimiento
		AND Cuil = unCuil;
end $$

/*Realizar la SF complejidadPromedio que reciba como parámetro un idProyecto y devuelva un float representando el promedio de  complejidad de los
requerimientos para el Proyecto pasado por parámetro.*/
DELIMITER $$
DROP FUNCTION if exists complejidadPromedio $$ 
CREATE FUNCTION complejidadPromedio (unidProyecto SMALLINT) RETURNS FLOAT reads sql data
begin
		DECLARE Resultado FLOAT;
        
        SELECT AVG (complejidad) INTO Resultado
        FROM Requerimiento
        WHERE idProyecto = unidProyecto;
        RETURN Resultado; 
end $$

/*Realizar la SF sueldoMensual que en base a un cuil devuelva el sueldo a pagar (DECIMAL (10,2))para el mes en curso.
SUELDO MENSUAL = Antigüedad en años * 1000 + SUMATORIA de (calificación de la exp. * costo base de la tecnología). */
DELIMITER $$
DROP FUNCTION if EXISTS sueldoMensual $$
CREATE FUNCTION sueldoMensual   (unCuil INT) RETURNS DECIMAL (10,2) reads sql data
Begin
    DECLARE sueldoApagar DECIMAL (10,2);

    SELECT  TIMESTAMPDIFF(YEAR, contratacion , CURDATE()) * 1000 + sum(calificacion * CostoBase) INTO sueldoApagar
	from experiencia E

    INNER JOIN empleado EM on E.cuil = EM.cuil
	INNER JOIN Teconologia T on E.idTecnologia = T.idTecnologia
	WHERE EM.cuil = unCuil;

    RETURN  sueldoApagar;
END $$

/*Realizar el SF costoProyecto que recibe como parámetro un idProyecto y devuelva el costo en DECIMAL (10,2).
COSTO PROYECTO = SUMATORIA (complejidad del requerimiento * costo base de la tecnología del Requerimiento). */
DELIMITER $$
DROP FUNCTION if EXISTS costoProyecto $$
CREATE FUNCTION costoProyecto (unIdProyecto SMALLINT) returns DECIMAL (10,2) reads sql data

BEGIN
	DECLARE costo decimal (10,2);
    
	SELECT  SUM(Complejidad * CostoBase) into costo
	FROM requerimiento R
    INNER JOIN tecnologia T ON R.idTecnologia = T.idTecnologia 
	WHERE	idProyecto = unIdProyecto;
    
    RETURN costoProyecto;
END $$
