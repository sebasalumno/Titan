# Titan 
Este repositorio apunta a crear una API funcional que maneje los registros e inicios de sesión de una parte web dirigida hacia empresas y de una parte movil dirigida a jovenes 
con ganas de trabajar y ganar experiencias que esten cursando modulos FP.
Asi que esta API pretende acercar a los posibles empleados a las empresas en busca de jovenes talentos,
ya que no son muchos los jovenes que cursan DUAL y empiezan formando contactos en su campo de estudio.
para eso hemos usado ASP NET CORE 3.1 el cual conectamos con la aplicación principal

Creado en la rama master.

# Requisitos
Para poder usar esta api necesitaras descargar Visual Studio (la version Comunity sirve)
https://visualstudio.microsoft.com/es/downloads/

# Uso
La api integra automaticamente Swagger para poder generar un entorno de testing adecuado.
Para mas información consultar https://swagger.io/docs/

****
Titan será la api con la que trabajaremos y moveremos la informacion tanto en la aplicación movil como en el frontend de angular.Esta api se ira actualizando a medida que avancen los sprints, consultar las tags.
****
# SPRINT 1
Se ha añadido a la api el controllador de usuarios, añadiendo los apartados de BL,Core y DAl.
se ha enlazado la dal con la base de datos y se han creado varias migraciones para añadir y pasar tablas a la base de datos usando el EntityFramework.

Para actualizar la base de datos usar el comando 
--update-database-- 
seleccionando la parte DAL de la api, y moviendose a la carpeta de DAL con el comando
--cd Titan.DAL--

También ha sido añadido el apartado del hash de la contraseña, con las entidades  IPasswordGenerator, y PasswordGenerator.
Que es usado para no pasar directamente la constraseña a la base de datos.

También se ha creado un create en el apartado de login para poder registrar usuarios en la base de datos.
****
**Contenido Extra**
Se ha añadido el script de las provincias que al ejecutarse crea la tabla de las provincias al ejecutarse.
Tambien se ha añadido la entidad de provincia para poder pasarla con el usuarioDTO.
****
