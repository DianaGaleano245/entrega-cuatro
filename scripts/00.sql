DROP DATABASE IF EXISTS SoftwareFactory;
CREATE DATABASE SoftwareFactory;
USE SoftwareFactory;

CREATE TABLE Cliente(
	cuit INT NOT NULL,
	razonSocial VARCHAR(50),
	CONSTRAINT PK_Cliente PRIMARY KEY (cuit ASC),
	CONSTRAINT UQ_Cliente_razonSocial UNIQUE (razonSocial ASC)
);

CREATE TABLE Tecnologia(
	idTecnologia TINYINT NOT NULL AUTO_INCREMENT,
	tecnologia VARCHAR(20) NOT NULL,
	costoBase DECIMAL(10,2) NOT NULL,
	CONSTRAINT PK_Tecnologia PRIMARY KEY (idTecnologia ASC),
	CONSTRAINT UQ_Tecnologia_tecnologia UNIQUE (tecnologia ASC)
);

CREATE TABLE Empleado(
	cuil INT NOT NULL,
	nombre VARCHAR(50) NOT NULL,
	apellido VARCHAR(50) NOT NULL,
	contratacion DATE NOT NULL,
	CONSTRAINT PK_Empleado PRIMARY KEY (cuil ASC)
);

CREATE TABLE Experiencia(
	cuil INT NOT NULL,
	idTecnologia TINYINT NOT NULL,
	calificacion TINYINT UNSIGNED NOT NULL,
	CONSTRAINT PK_Experiencia PRIMARY KEY (cuil ASC, idTecnologia ASC),
	CONSTRAINT FK_Experiencia_Empleado FOREIGN KEY (cuil) REFERENCES Empleado (cuil) ON DELETE Restrict ON UPDATE Restrict,
	CONSTRAINT FK_Experiencia_Tecnologia FOREIGN KEY (idTecnologia) REFERENCES Tecnologia (idTecnologia) ON DELETE Restrict ON UPDATE Restrict
);

CREATE TABLE Proyecto(
	idProyecto SMALLINT NOT NULL AUTO_INCREMENT,
	cuit INT NOT NULL,
	descripcion VARCHAR(200) NOT NULL,
	presupuesto DECIMAL(10,2) NOT NULL,
	inicio DATE NOT NULL,
	fin DATE,
	CONSTRAINT PK_Proyecto PRIMARY KEY (idProyecto ASC),
	CONSTRAINT FK_Proyecto_Cliente FOREIGN KEY (cuit) REFERENCES Cliente (cuit) ON DELETE Restrict ON UPDATE Restrict
);

CREATE TABLE Requerimiento(
	idRequerimiento INT NOT NULL,
	idProyecto SMALLINT NOT NULL,
	idTecnologia TINYINT NOT NULL,
	descripcion VARCHAR(45) NOT NULL,
	complejidad TINYINT UNSIGNED NOT NULL,
	CONSTRAINT PK_Requerimiento PRIMARY KEY (idRequerimiento ASC),
	CONSTRAINT FK_Requerimiento_Proyecto FOREIGN KEY (idProyecto) REFERENCES Proyecto (idProyecto) ON DELETE Restrict ON UPDATE Restrict,
	CONSTRAINT FK_Requerimiento_Tecnologia FOREIGN KEY (idTecnologia) REFERENCES Tecnologia (idTecnologia) ON DELETE Restrict ON UPDATE Restrict
);

CREATE TABLE Tarea(
	idRequerimiento INT NOT NULL,
	cuil INT NOT NULL,
	inicio DATE NOT NULL,
	fin DATE,
	CONSTRAINT PK_Tarea PRIMARY KEY (idRequerimiento ASC, cuil ASC),
	CONSTRAINT FK_Tarea_Empleado FOREIGN KEY (cuil) REFERENCES Empleado (cuil) ON DELETE Restrict ON UPDATE Restrict,
	CONSTRAINT FK_Tarea_Requerimiento FOREIGN KEY (idRequerimiento) REFERENCES Requerimiento (idRequerimiento) ON DELETE Restrict ON UPDATE Restrict
);
