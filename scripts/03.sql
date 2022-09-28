/*Interacción DOS*/

/*Antes de hacer un insert en tarea, si la calificación del empleado es menor a la complejidad del 
 requerimiento no se tiene que permitir el Insert y se tiene que mostrar la leyenda “Calificación insuficiente”.*/

DELIMITER $$

CREATE TRIGGER BEFORECUIL BEFORE INSERT ON TAREA FOR 
EACH ROW BEGIN 
	-- GUARDARSE calificacion del Empleado
	-- Guardarse requerimiento de la tarea
	DECLARE unacalificacion TINYINT UNSIGNED;
	DECLARE unacomplejidad TINYINT UNSIGNED;
	SELECT
	    Calificacion,
	    complejidad INTO unacalificacion,
	    unacomplejidad
	FROM Experiencia
	    JOIN Requerimiento USING (idTecnologia)
	WHERE
	    NEW.IdRequerimiento = idRequerimiento if (calificacion < complejidad) then IF (NEW.calificacion < 0) THEN SIGNAL SQLSTATE '45000'
	SET
	    MESSAGE_TEXT = 'calificacion insuficiente';
	END IF;
	END -- consulta entre experiencia y requerimiento usando en where los campos del trigger


DELIMITER $$

CREATE TRIGGER AFTERINSERTUSUARIO 
	AFTER
	INSERT ON Empleado FOR EACH ROW
	INSERT INTO
	    Software.Experiencia (
	        Cuil,
	        IdTecnologia,
	        calificación
	    )
	SELECT
	    NEW.Cuil,
	    idTecnologia,
	    0
	FROM Tecnologia;
	end 
$ 

$
INSERT INTO
    SoftWare.Experiencia (
        Cuil,
        idTecnologia,
        Calificacion
    )
SELECT
FROM empleado
where