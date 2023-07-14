# PruebaBienestar

El proyecto contiene: BackEnd .Net Core, FrontEnd Angular y la BD SQL Server con EF Core para mapear la BD.

Procedimiento para levantar proyectos:

1. Ajustar la cadena de conexión a la Base de Datos en el archivo "appsettings.json" - Bienestar.Negocio
2. Ejecutar el comando: Update-database, en el Package Manager Console para crear la Base de Datos. El archivo de Migración se ubica en el proyecto Bienestar.Data
3.

NOTA: por temas de seguridad en los servidores locales, se instaló el complemento CORS en el Browser de trabajo 