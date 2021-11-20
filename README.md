# Titan
Api ASP NET CORE 3.1 de la aplicación principal

Creado en la rama master.

Titan será la api con la que trabajaremos y moveremos la informacion tanto en la aplicación movil como en el frontend de angular.Esta api se ira actualizando a medida que avancen los sprints .

SPRINT 1
Se ha añadido a la api el controllador de usuarios, añadiendo los apartados de BL,Core y DAl.
se ha enlazado la dal con la base de datos y se han creado varias migraciones para añadir y pasar tablas a la base de datos usando el EntityFramework.

Para actualizar la base de datos usar el comando 
--update-database-- 
seleccionando la parte DAL de la api, y moviendose a la carpeta de DAL con el comando
--cd Titan.DAL--

También ha sido añadido el apartado del hash de la contraseña, con las entidades  IPasswordGenerator, y PasswordGenerator.
Que es usado para no pasar directamente la constraseña a la base de datos.

También se ha creado un create en el apartado de login para poder registrar usuarios en la base de datos.

**Contenido Extra**
Se ha añadido el script de las provincias que al ejecutarse crea la tabla de las provincias al ejecutarse.
Tambien se ha añadido la entidad de provincia para poder pasarla con el usuarioDTO.

