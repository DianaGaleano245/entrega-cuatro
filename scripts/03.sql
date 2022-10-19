DELIMITER ;
USE softwarefactory;
SELECT 'Creando Triggers' AS 'Estado';
DELIMITER $$
CREATE TRIGGER befInsertTarea BEFORE INSERT ON tarea
FOR EACH ROW
BEGIN
	IF EXISTS (SELECT calificacion
				FROM experiencia E
				INNER JOIN tarea T ON E.cuil = NEW.cuil < (SELECT complejidad from requerimiento R INNER JOIN Tarea T ON R.idRequerimiento = NEW.idRequerimiento))
				THEN SIGNAL SQLSTATE "45000"
				SET MESSAGE_TEXT = "calificacion insuficiente";
	END IF;
	
END $$


DELIMITER $$
CREATE TRIGGER aftAsignar AFTER INSERT ON empleado
FOR EACH ROW 
BEGIN
	INSERT INTO experiencia(cuil, idTecnologia, calificacion)
					SELECT NEW.cuil, idTecnologia, 0
                    FROM tecnologia; 
END $$
