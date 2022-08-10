DELIMITER $$
CREATE PROCEDURE altaEmpleado(unCuil INT , unNombre VARCHAR(50) , unApellido VARCHAR(50) , unaContratacion DATE)
begin
		INSERT INTO Empleado(Cuil , Nombre , Apellido , Contratacion)
					VALUES (unCuil , unNombre , unApellido , unaContratacion);
end $$

CREATE PROCEDURE AsignarExperencia (unCuil INT, unidTecnologia TINYINT, unaCalificacion TINYINT UNSIGNED)
begin
    if (EXISTS(SELECT * 
				FROM experiencia
                WHERE unCuil = Cuil 
                OR unIdTecnologia = IdTecnologia 
                AND  Experiencia AND IdTecnologia)
    ) then 
        UPDATE Experiencia
        SET calificacion = unaCalificacion 
        WHERE Cuil = unCuil 
        AND idTecnologia = unIdTecnologia;
    END IF
end $$


CREATE PROCEDURE altaTecnologia(unIdTecnologia TINYINT , unaTecnologia VARCHAR(20) , unCostoBase DECIMAL(10,2))
begin
		INSERT INTO Tecnologia (IdTecnologia , Tecnologia , CostoBase)
					VALUES(unIdTecnologia , unaTecnologia , unCostoBase);
end$$