Respuesta:
/*Realizar los SP para dar de alta todas las tablas, menos la tabla Experiencia*/
DELIMITER $$
CREATE PROCEDURE altaEmpleado(unCuil INT , unNombre VARCHAR(50) , unApellido VARCHAR(50) , unaContratacion DATE)
begin
		INSERT INTO Empleado(Cuil , Nombre , Apellido , Contratacion)
					VALUES (unCuil , unNombre , unApellido , unaContratacion);
end $$

CREATE PROCEDURE altaCliente(unCuit INT , unaRazonSocial VARCHAR(59))
begin
		INSERT INTO Cliente(Cuit , RazonSocial)
					VALUES(unCuit , unaRazonSocial);
end$$

CREATE PROCEDURE altaTarea(unIdRequerimiento INT , unCuil INT , unInicio DATE , unFin DATE)
begin
		INSERT INTO Tarea(Requerimiento , Cuil , Inicio , Fin)
					VALUES(unIdRequerimiento , unCuil , unInicio , unFin);
end $$ 

CREATE PROCEDURE altaProyecto(unIdProyecto SMALLINT , unCuit INT , unaDescripcion varchar(200) , unPresupuesto DECIMAL(10,2) , 
									unInicio DATE , unFinal DATE)
begin
		INSERT INTO Proyecto(IdProyecto , Cuit , Descripcion , Presupuesto , Inicio , Final)
					VALUES(unIdProyecto , unCuit , unaDescripcion , unPresupuesto , unInicio , unFinal);
end$$

CREATE PROCEDURE altaRequerimiento(unIdRequerimiento INT , unIdProyecto SMALLINT , 
										unIdTecnologia TINYINT , unaDescripcion VARCHAR (45) , unaComplejidad TINYINT UNSIGNED)
begin
		INSERT INTO Requerimiento(IdRequerimiento , IdProyecto , IdTecnologia , Descripcion , Complejidad)
					VALUES(unIdRequerimiento , unIdProyecto , unIdTecnologia , unaDescripcion , unaComplejidad);
end$$

CREATE PROCEDURE altaTecnologia(unIdTecnologia TINYINT , unaTecnologia VARCHAR(20) , unCostoBase DECIMAL(10,2))
begin
		INSERT INTO Tecnologia (IdTecnologia , Tecnologia , CostoBase)
					VALUES(unIdTecnologia , unaTecnologia , unCostoBase);
end$$

/*Realizar el SP asignarExperiencia que recibe como parámetros cuil, idTecnologia y una calificación. 
El SP tiene que crear un registro en caso de que no exista o actualizarlo en caso de que si exista*/
DELIMITER $$
CREATE PROCEDURE AsignarExperencia (unCuil INT, unidTecnologia TINYINT, unaCalificacion TINYINT UNSIGNED)
begin
    if (EXISTS(SELECT * 
				FROM experiencia
                WHERE Cuil + idTecnologia 
                OR Empleado + Experiencia )
    ) then
end $$

/*Crear los SP finalizarTarea que reciba como parámetro un idRequerimiento, 
un cuil y una fecha de fin. El SP deberá actualizar la fecha de fin solamente si no tenía valor previo.*/
DELIMITER $$
CREATE PROCEDURE FinalizarTarea (unIdRequerimiento INT , unCuil INT , unFinal DATE)
begin
		DECLARE resultado FLOAT;
        
        
end$$

/*Realizar la SF complejidadPromedio que reciba como parámetro un idProyecto y devuelva un float representando el promedio de  complejidad de los
 requerimientos para el Proyecto pasado por parámetro.*/
 DELIMITER $$
 CREATE FUNCTION complejidadPromedio (unidProyecto SMALLINT
										) RETURNS FLOAT
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
CREATE FUNCTION sueldoMensual   (unCuil INT) RETURNS DECIMAL (10,2)
Begin
    DECLARE resultado DECIMAL (10,2);

    SELECT  TIMESTAMPDIFF(YEAR, Contratacion , CURDATE() ) AS años_transcurridos;
			TIMESTAMPDIFF(MONTH,Contratacion  , CURDATE() ) AS años_transcurridos;  
    FROM    Empleado
    WHERE   idProyecto = unIdProyecto
    AND      BETWEEN cotaInferior AND cotaSuperior;
    
    RETURN  resultado;
END

/*Realizar el SF costoProyecto que recibe como parámetro un idProyecto y devuelva el costo en DECIMAL (10,2).
COSTO PROYECTO = SUMATORIA (complejidad del requerimiento * costo base de la tecnología del Requerimiento). */
DELIMITER $$
CREATE FUNCTION costoProyecto (unIdProyecto SMALLINT) returns DECIMAL (10,2)

BEGIN
	DECLARE costoProyecto decimal (10,2);
    
	SELECT  SUM(Complejidad * CostoBase) into costoProyecto
	FROM    Requerimiento
    INNER JOIN Requerimiento , Tecnologia 
	WHERE	idTecnologia = idRequerimieto;
    
    RETURN costoProyecto;
END $$


