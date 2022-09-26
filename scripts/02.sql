use SoftwareFactory;
/*Administrador: puede ver todo desde cualquier lado, dar de alta Proyectos, Tecnologías, Clientes y Empleados. También puede actualizar todo respecto a la tabla Proyecto.*/
    DROP USER IF EXISTS 'Adminitrador'@'%';
    CREATE USER 'Administrador'@'%' IDENTIFIED BY 'passAdminitrador';
    GRANT ALL ON SofwareFactory.Proyectos TO 'Adminitrador'@'%';
    GRANT SELECT , UPDATE  ON SoftwareFactory.Tecnologia TO 'Adminitrador'@'%';
    GRANT ALL ON SoftWareFactory.Cliente TO 'Adminitrador'@'%';
    GRANT SELECT, UPDATE  ON SoftwareFactory.Empleado TO 'Adminitrador'@'%';
    GRANT INSERT, SELECT, UPDATE(*)
    ON SoftwareFactory.Proyecto TO 'Adminitrador'@'%';

/*PM: desde la red 10.3.45.xxx puede
Ver todas las tablas.
Insertar (todo) y modificar (la calificación) de las Experiencias.
Dar de alta Empleados.
Insertar Requerimientos.
Insertar Tareas y modificar solo su fin.*/
    DROP USER IF EXISTS 'PM'@'10.3.45.%';
    CREATE USER 'PM'@'10.3.45.%' IDENTIFIED BY 'passPM';
    GRANT INSERT , SELECT ON SoftwareFactory.Empleado TO 'PM'@'10.3.45.%';
    GRANT SELECT, UPDATE (Calificacion) ON SoftwareFactory.Experiencia
    GRANT INSERT ON SoftWareFactory.Requerimiento TO 'PM'@'10.3.45.%';
    GRANT SELECT, UPDATE (fin) ON SoftwareFactory.Tarea

/*Empleado:  desde la red 10.3.45.xxx puede ver todas las tablas.*/
    DROP USER IF EXISTS 'Empleado'@'10.3.45.%';
    CREATE USER 'Empleado'@'10.3.45.%' IDENTIFIED BY 'passEmpleado';
    GRANT SELECT ON SoftWareFactory.* TO 'Empleado'@'10.3.45.%';