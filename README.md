# BackendLogicalData

Este proyecto es el back-end de la aplicación que está construida con **.NET CORE 6** y **SQL Server 2022**, utilizando **EntityFramework** para el manejo de bases de datos. Otras herramientas como Swagger se utilizan para la documentación y prueba de la API.

## Requisitos

- **Visual Studio 2022** (o superior)
- **SQL Server 2022**
- **.NET CORE 6 SDK**

## Ejecución del Proyecto

### 1. Preparación de la Base de Datos

Antes de ejecutar el proyecto, es necesario crear la base de datos y sus tablas en **SQL Server**. Para ello:

- Ejecute el script SQL proporcionado para crear la estructura de la base de datos. Esto incluye todas las tablas necesarias para el correcto funcionamiento del back-end.

### 2. Configuración de la Cadena de Conexión

Una vez que la base de datos está lista, es importante configurar la cadena de conexión:

- Diríjase al archivo `appSettings.json` que se encuentra en la raíz del proyecto.
- Localice la sección que contiene la cadena de conexión a la base de datos y actualícela con los detalles de su propio servidor SQL.
- Ejecutar el proyecto BackendTestLogicalData

  Ejemplo de la cadena de conexión:
  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=SU_SERVIDOR;Database=PruebaLogicalData;Trusted_Connection=True;TrustServerCertificate=True;"
  }
   ```

### Contacto
 - Correo: jirgort@gmail.com
 - Celular: 63432660
